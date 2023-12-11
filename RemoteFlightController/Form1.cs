using System.Text;
using System.Net;
using System.Net.Sockets;
// Json de/serialising.
using System.Web.Script.Serialization;
using System.Threading;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
// file handling (Blackbox).
using System.IO; 
// packages for needle colour fill.
using System.Windows.Media;
using System.Drawing;
// package for creating the gauges.
using LiveCharts.WinForms;
using System.Reflection;
using static _30051129_RemoteFlightController.RemoteFlightController;



namespace _30051129_RemoteFlightController
{
    public partial class RemoteFlightController : Form
    {

        private TcpClient tcpClient;
        private    Thread listenThread;

        // Initialise Delegates.
        private delegate void UpdateTelemetryDelegate( TelemetryUpdate telemObj );

        private delegate void UpdateWarningDelegate( int warning );
        private delegate void SendTelemetryDelegate( ControlsUpdate controls );

        // Initialise Events.
        private event UpdateTelemetryDelegate updateTelemetryDelegate;         
        private event UpdateWarningDelegate   updateWarningDelegate;
        private event SendTelemetryDelegate   sendTelemetry;

        // Initialising telemetry guages.
        AngularGauge GaugeAltitude = new AngularGauge();
           AngularGauge GaugeSpeed = new AngularGauge();
           AngularGauge GaugePitch = new AngularGauge();
          AngularGauge GaugeEpitch = new AngularGauge();
          AngularGauge GaugeVspeed = new AngularGauge();
        AngularGauge GaugeThrottle = new AngularGauge();

        // time and date for blackbox.
        static DateTime now = DateTime.Now;
        static string date = $"{now.Day}/{now.Month}/{now.Year}";
        static string time = $"{now.Hour}:{now.Minute}:{now.Second}";

        // Workaround suggested by intelisense.
        [Obsolete]

        
        // Constructor
        public RemoteFlightController()
        {
            InitializeComponent();
            // finds the user's IP address and places it into the IP input field.
            System.Diagnostics.Process.Start("C:\\Users\\will0\\Documents\\Yeat 2\\Event Driven Programming\\Assignment 2\\FlightSimulator.exe");
            string hostname = Dns.GetHostName();
            string IP = Dns.GetHostByName(hostname).AddressList[0].ToString();
            textBoxIP.Text = IP;

            // Add events to their delegate.
            updateTelemetryDelegate += new UpdateTelemetryDelegate(UpdateTelemetryGauges);
            updateWarningDelegate   += new UpdateWarningDelegate(updateWarnings);
            sendTelemetry += new SendTelemetryDelegate(SendData);

            // Sets the Pitch label to its correct value.
            labelEpitchDegrees.Text = trackBarPitch.Value.ToString();

            BuildNeedles();
        }
        
        

        #region Handlers

        /// <summary>
        /// Connect Button: onClick: connects to Flight Sim, starts a thread that runs method ReceiveData.
        /// writes to blackbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
        
            try
            {
                IPAddress ip = IPAddress.Parse(textBoxIP.Text);
                int port = Convert.ToInt32(textBoxPort.Text);

                tcpClient.Connect(ip, port);
                _ = MessageBox.Show($"Connected to: {ip}");

                // writes to blackbox
                using (StreamWriter sw = File.AppendText(CSVpath + "\\Blackbox.csv"))
                {
                    
                    sw.WriteLine("\nRemote Flight Controller, Connected");
                    sw.WriteLine($",{date},{time}");

                }

                labelConnectOrNot.Text = "Connected";               
                listenThread = new Thread(new ThreadStart(ReceiveData));
                listenThread.Start();
            }
            catch
            {
                MessageBox.Show("Did not connect. Click 'Help' button for instructions");
            }
           
        }

        /// <summary>
        /// Disconnect Button: Aborts the thread, closes client, updates Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                listenThread?.Abort();
                    tcpClient.Close();
                 labelConnectOrNot.Text = "Disconnected";
            }
            catch (Exception)
            {
                labelConnectOrNot.Text = "Disconnected";
            }

        }


        /// <summary>
        /// Close Button: runs Form1_FormClosing moethod and closes form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Form1_FormClosing(null, null);
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                listenThread?.Abort();
                    tcpClient.Close();
                         this.Close();
            }
            catch (Exception)
            {

            }
        }
      
        private void TrackBar_Scroll(Object sender, EventArgs e)
        {
            
            ControlsUpdate controls = new ControlsUpdate();

            
                    controls.Throttle = trackBarThrottle.Value;
            labelThrottlePercent.Text = controls.Throttle.ToString(); 
               controls.ElevatorPitch = trackBarPitch.Value;
              labelEpitchDegrees.Text = controls.ElevatorPitch.ToString();

            updateDataGridViewControls(controls);

            if (this.InvokeRequired)
            {
                
                this.Invoke(new SendTelemetryDelegate(SendData), new object[] { controls });
                MessageBox.Show("here");
            }
            else
            { 
                sendTelemetry?.Invoke(controls);
            }

        }
        #endregion Handlers






        #region Receive and Send Data

        // Blueprint for receiving data from the Fight Simulator. Originally a Struct.
        public class TelemetryUpdate
        {
            public double Altitude { get; set; } = Math.Min(0, 100000);
            //Altitude in ft.
            public double Speed { get; set; } = Math.Min(0, 1000);
            //Plane's speed in Knts.
            public double Pitch { get; set; } = Math.Min(-100, 100);
            //Plane's pitch in degrees relative to horizon. Positive
            //is planes pointing upwards, negative plane points
            //downwards.
            public double VerticalSpeed { get; set; } = Math.Min(0, 1000);
            //Plane's vertical speed in Feet per minute.
            public double Throttle { get; set; } = Math.Min(0, 100);
            //Current throttle setting as a percentage (i.e., 0% no
            //throttle, 100% full throttle).
            public double ElevatorPitch { get; set; } = Math.Min(-5, 5);
            //Current Elevator Pitch in degrees. Positive creates
            //upwards lift, negative downwards.
            public    int WarningCode { get; set; } = 0;
            //Warning code: 0 - No Warnings; 1 - Too Low (less than
            //1000ft); 2 - Stall.
        }

        
        /// <summary>
        /// Collects and serialises the stream of data coming from the Flight Simulator.
        /// </summary>
        private void ReceiveData()
        {
            try
            {

                while (tcpClient.Connected)
                {
                    // collects byte data from the stream
                    byte[]        buffer = new byte[254]; // makes a list of bytes
                    // makes a network stream
                    NetworkStream stream = tcpClient.GetStream();
                    // reads the bytes
                    int        bytesRead = stream.Read(buffer, 0, buffer.Length);

                    if (bytesRead > 0) // if there is data.
                    {
                        // encodes
                        string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        // serialises

                        JavaScriptSerializer serialiszer = new JavaScriptSerializer();
                         TelemetryUpdate telemetryUpdate = serialiszer.Deserialize<TelemetryUpdate>(receivedData);


                        // writes telemetry to blackbox.
                        try
                        {
                            using (StreamWriter sw = File.AppendText(CSVpath + "\\Blackbox.csv"))
                            {
                                sw.WriteLine("Flight telemetry");
                                sw.WriteLine(
                                    $",,,{telemetryUpdate.Altitude}," +
                                    $"{telemetryUpdate.Speed},{telemetryUpdate.Pitch}," +
                                    $"{telemetryUpdate.VerticalSpeed},{telemetryUpdate.Throttle}," +
                                    $"{telemetryUpdate.ElevatorPitch},{telemetryUpdate.WarningCode}"
                                    );
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Blackbox Malfunction");
                        }


                        // updates telemetry gauges and the warnings.
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new UpdateTelemetryDelegate(UpdateTelemetryGauges), new object[] { telemetryUpdate });
                            this.Invoke(new UpdateWarningDelegate(updateWarnings),          new object[] { telemetryUpdate.WarningCode });   
                        }
                        else
                        {
                            updateTelemetryDelegate?.Invoke(telemetryUpdate);
                            updateWarningDelegate?.Invoke(telemetryUpdate.WarningCode); // This can be done on one delegeate;

                        }                        
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        }

        // Blueprint for pilot controls. was a struct.
        public class ControlsUpdate
        {
            public double Throttle      { get; set; } = 0;
            //Current throttle setting as a percentage (i.e. 0% no
            //throttle, 100% full throttle).
            public double ElevatorPitch { get; set; } = 0;
            //Current Elevator Pitch in degrees. Positive creates
            //upwards lift, negative downwards.
        }


        /// <summary>
        /// Serialises and sends data to the Flight Simulator.
        /// </summary>
        /// <param name="C"></param>
        private void SendData(ControlsUpdate C)
        {
            // creates a network stream
            NetworkStream stream;
            // prepares data as a Json.
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                          string              message = javaScriptSerializer.Serialize(C);
            
            stream = tcpClient.GetStream();
            // converts to bytes
            byte[] buffer = new byte[254];
                   buffer = Encoding.ASCII.GetBytes(message);
            // sends
            stream.Write(buffer, 0, buffer.Length);

            // updates blackbox
            try
            {
                using (StreamWriter sw = File.AppendText(CSVpath + "\\Blackbox.csv"))
                {
                    sw.WriteLine("Remote Flight Controller");
                    sw.WriteLine($",,{C.Throttle},{C.ElevatorPitch}");

                }
            }
            catch
            {
                MessageBox.Show("Blackbox Malfunction");
            }
        }
        #endregion Receive and Send Data






        // List of strings for warnings:                   0,           1,        2.
        List<string> warningList = new List<string> { "No Warning", "Low Alt", "Stalled" };

        /// <summary>
        /// Updates red warning label on the GUI.
        /// </summary>
        /// <param name="warning"></param>

        private void updateWarnings(int warning)
        {
            switch (warning)
            {
                case 0:
                    labelWarnings.Text = warningList[0];
                    break;
                case 1:
                    labelWarnings.Text = warningList[1];
                    break;
                case 2:
                    labelWarnings.Text = warningList[2];
                    break;
            }
        }

        /// <summary>
        /// Adds rows of received telemetry on the bottom Data Grid
        /// </summary>
        /// <param name="telemObj"></param>

        private void updateDataGridView(TelemetryUpdate telemObj)
        {
            dataGridViewTelemetry.Rows.Add(telemObj.Altitude,
                                            telemObj.Speed,
                                            telemObj.Pitch,
                                            telemObj.VerticalSpeed,
                                            telemObj.Throttle,
                                            telemObj.ElevatorPitch,
                                            telemObj.WarningCode
                                            );

        }

        /// <summary>
        /// Adds row of sent telemetry on the right-side Data Grid.
        /// </summary>
        /// <param name="C"></param>
        private void updateDataGridViewControls(ControlsUpdate C)
        {
            dataGridViewControls.Rows.Add(
                                           C.Throttle,
                                           C.ElevatorPitch
                                          );
        }

        /// <summary>
        /// Makes both Data grid Views continue to scroll with the latest telemetry row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewTelemetry_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridViewTelemetry.FirstDisplayedScrollingRowIndex = dataGridViewTelemetry.Rows.Count - 1;
        }

        /// <summary>
        /// Upadtes the Green numbers on the gauges.
        /// </summary>
        /// <param name="telemObj"></param>
        private void UpdateTelemetryGauges(TelemetryUpdate telemObj)
        {

            labelAltitudeGauge.Text = telemObj.Altitude.ToString("F0");
               labelSpeedGauge.Text = telemObj.Speed.ToString("F0");
               labelPitchGauge.Text = telemObj.Pitch.ToString("F0");
              labelEpitchGauge.Text = telemObj.ElevatorPitch.ToString("F0");
           labelVertSpeedGauge.Text = telemObj.VerticalSpeed.ToString("F0");
            labelThrottleGauge.Text = telemObj.Throttle.ToString("F0");

            // makes controller trackbar match flight sim trackbars.
            trackBarPitch.Value = (int)telemObj.ElevatorPitch;
            trackBarThrottle.Value = (int)telemObj.Throttle;

            UpdateNeedles(telemObj);


            updateDataGridView(telemObj);

        }

        // Finds the path of this project.
        static string assemblyPath = Assembly.GetExecutingAssembly().Location;
        string CSVpath = Path.GetDirectoryName(assemblyPath);

        

        /// <summary>
        /// Updates the gauge value. it is this method that animates the needle.
        /// </summary>
        /// <param name="t"></param>
        private void UpdateNeedles(TelemetryUpdate t)
        {
            GaugeAltitude.Value = t.Altitude;
               GaugePitch.Value = t.Pitch;
              GaugeEpitch.Value = t.ElevatorPitch;
               GaugeSpeed.Value = t.Speed;
              GaugeVspeed.Value = t.VerticalSpeed;
            GaugeThrottle.Value = t.Throttle;
        }
        /// <summary>
        /// Method Holds all the code for building the needles.
        /// </summary>
        private void BuildNeedles()
        {
            // this is the color for the needle fill.
            System.Windows.Media.Brush brush = new SolidColorBrush(Colors.White);

            #region Location

            GaugeAltitude.Location = pictureBoxAltitude.Location;
               GaugePitch.Location = pictureBoxPitch.Location;
              GaugeEpitch.Location = pictureBoxEpitch.Location;
               GaugeSpeed.Location = pictureBoxSpeed.Location;
              GaugeVspeed.Location = pictureBoxVspeed.Location;
            GaugeThrottle.Location = pictureBoxThrottle.Location;
            #endregion Location


            #region Add
            this.Controls.Add(GaugeAltitude);
            this.Controls.Add(GaugePitch);
            this.Controls.Add(GaugeEpitch);
            this.Controls.Add(GaugeSpeed);
            this.Controls.Add(GaugeVspeed);
            this.Controls.Add(GaugeThrottle);
            #endregion Add


            #region Width
            GaugeAltitude.Width = pictureBoxAltitude.Width;
               GaugePitch.Width = pictureBoxPitch.Width;
              GaugeEpitch.Width = pictureBoxEpitch.Width;
               GaugeSpeed.Width = pictureBoxSpeed.Width;
              GaugeVspeed.Width = pictureBoxVspeed.Width;
            GaugeThrottle.Width = pictureBoxThrottle.Width;
            #endregion Width


            #region Height
            GaugeAltitude.Height = pictureBoxAltitude.Height;
               GaugePitch.Height = pictureBoxPitch.Height;
              GaugeEpitch.Height = pictureBoxEpitch.Height;
               GaugeSpeed.Height = pictureBoxSpeed.Height;
              GaugeVspeed.Height = pictureBoxVspeed.Height;
            GaugeThrottle.Height = pictureBoxThrottle.Height;
            #endregion Height

            #region Background Image
            GaugeAltitude.BackgroundImage = pictureBoxAltitude.Image;
               GaugePitch.BackgroundImage = pictureBoxPitch.Image;
              GaugeEpitch.BackgroundImage = pictureBoxEpitch.Image;
               GaugeSpeed.BackgroundImage = pictureBoxSpeed.Image;
              GaugeVspeed.BackgroundImage = pictureBoxVspeed.Image;
            GaugeThrottle.BackgroundImage = pictureBoxThrottle.Image;
            #endregion background Image


            #region From & To Value
            GaugeAltitude.ToValue = 100000;
               GaugePitch.ToValue = 100;            
              GaugeEpitch.ToValue = 5;            
               GaugeSpeed.ToValue = 100;            
              GaugeVspeed.ToValue = 100;            
            GaugeThrottle.ToValue = 100;

               GaugePitch.FromValue = -100;
              GaugeEpitch.FromValue = -5;
               GaugeSpeed.FromValue = 0;
              GaugeVspeed.FromValue = 0;
            GaugeThrottle.FromValue = 0;
            GaugeAltitude.FromValue = 0;
            #endregion From & To Value


            #region Needle Fill
            GaugeAltitude.NeedleFill = brush;
               GaugePitch.NeedleFill = brush;
              GaugeEpitch.NeedleFill = brush;
               GaugeSpeed.NeedleFill = brush;
              GaugeVspeed.NeedleFill = brush;
            GaugeThrottle.NeedleFill = brush;
            #endregion Needle Fill

            #region Bring To Front
            GaugeAltitude.BringToFront();
               GaugePitch.BringToFront();
              GaugeEpitch.BringToFront();
               GaugeSpeed.BringToFront();
              GaugeVspeed.BringToFront();
            GaugeThrottle.BringToFront();

            labelAltitudeGauge.BringToFront();
               labelPitchGauge.BringToFront();
              labelEpitchGauge.BringToFront();
               labelSpeedGauge.BringToFront();
           labelVertSpeedGauge.BringToFront();
            labelThrottleGauge.BringToFront();
            #endregion Bring To front


            #region Invalidate
           GaugeAltitude.Invalidate();
              GaugePitch.Invalidate();
             GaugeEpitch.Invalidate();
              GaugeSpeed.Invalidate();
             GaugeVspeed.Invalidate();
           GaugeThrottle.Invalidate();
            #endregion Invalidate

        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("   Remote Flight Controller Help\n" +
                "1. Check that IP address & Port matches Flight Sim.\n" +
                "2. Click 'Open Port' on Flight Sim.\n" +
                "3. Click 'Connect' on Remote Flight Controller.\n" +
                "4. A pop up will notify you of successful connection.\n" +
                "5. Click 'Start Sim' to begin simulation.\n" +
                "6. Use flight controls to fly the plane.\n" +
                "\nMax Throttle and Elevation to take off.");
        }
    }
}
