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
// package for creating the gauges.
using LiveCharts.WinForms;
using System.Reflection;
using System.Linq;
using static _30051129_RemoteFlightController.RemoteFlightController;


namespace _30051129_RemoteFlightController
{
    public partial class RemoteFlightController : Form
    {

        private TcpClient tcpClient;
        private    Thread listenThread;
        // private    Thread autopilotThread;
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
        AngularGauge    GaugeSpeed = new AngularGauge();
        AngularGauge    GaugePitch = new AngularGauge();
        AngularGauge   GaugeEpitch = new AngularGauge();
        AngularGauge   GaugeVspeed = new AngularGauge();
        AngularGauge GaugeThrottle = new AngularGauge();

        // time and date for blackbox.
        //static DateTime now = DateTime.Now;
        //static string  date = $"{now.Day}/{now.Month}/{now.Year}";
        //static string  time = $"{now.Hour}:{now.Minute}:{now.Second}";


        // private bool autopilotOn = false;
        

        // Workaround suggested by intelisense.
        [Obsolete]

       

        // Constructor
        public RemoteFlightController()
        {
            InitializeComponent();
            
            // executes flight sim
            System.Diagnostics.Process.Start("C:\\Users\\will0\\Documents\\Yeat 2\\Event Driven Programming\\Assignment 2\\FlightSimulator.exe");
            
            // finds the user's IP address and places it into the IP input field.
            string hostname = Dns.GetHostName();
            string       IP = Dns.GetHostByName(hostname).AddressList[0].ToString();
             textBoxIP.Text = IP;

            // Add events to their delegate.
            updateTelemetryDelegate += new UpdateTelemetryDelegate(UpdateTelemetryGauges);
              updateWarningDelegate += new UpdateWarningDelegate(updateWarnings);
                      sendTelemetry += new SendTelemetryDelegate(SendData);


            ;

            // Sets the Pitch label to its correct value.
            labelEpitchDegrees.Text = trackBarPitch.Value.ToString() + "°";
            labelThrottlePercent.Text = trackBarThrottle.Value.ToString() + "%";
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
                IPAddress ip = IPAddress.Parse( textBoxIP.Text );
                int     port = Convert.ToInt32( textBoxPort.Text );

                tcpClient.Connect( ip, port );
                _ = MessageBox.Show( $"Connected to: {ip}" );
                

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
        /// Close Button: runs Form1_FormClosing method and closes form.
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

            ControlsUpdate controls = new ControlsUpdate
            {
                Throttle = trackBarThrottle.Value,
                ElevatorPitch = trackBarPitch.Value
            };

            

            if (this.InvokeRequired)
            {
                
                this.Invoke(new SendTelemetryDelegate(SendData), new object[] { controls });
               
            }
            else
            { 
                sendTelemetry?.Invoke(controls);
            }

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


        // failed attempt at an autopilot

        //private void ButtonAutoPilot_Click(object sender, EventArgs e)
        //{
        //    // Changes bool to the opposite value to its current value.
        //    autopilotOn = !autopilotOn;

        //    // ternery operator to change the text
        //    labelAutoPilotActivation.Text = autopilotOn ? "Enabled" : "Disabled";
            
        //    if (autopilotOn) 
        //    {
        //        autopilotThread = new Thread(Autopilot);
        //        autopilotThread.Start();
        //    }
        //    else 
        //    {
        //        autopilotThread.Abort();
                
        //    }
            
        //}
        #endregion Handlers






        #region Receive and Send Data

        // Blueprint for receiving data from the Fight Simulator. Originally a Struct.
        public class TelemetryUpdate
        {
            public double      Altitude { get; set; } = Math.Min(0, 100000);
            public double         Speed { get; set; } = Math.Min(0, 1000);
            public double         Pitch { get; set; } = Math.Min(-100, 100);
            public double VerticalSpeed { get; set; } = Math.Min(0, 1000);
            public double      Throttle { get; set; } = Math.Min(0, 100);
            public double ElevatorPitch { get; set; } = Math.Min(-5, 5);
            public    int   WarningCode { get; set; } = 0;
            
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
                        TelemetryUpdate  telemetryUpdate = serialiszer.Deserialize<TelemetryUpdate>(receivedData);                
                       

                        // updates telemetry gauges and the warnings.
                        if (this.InvokeRequired)
                        {
                            this.Invoke(new UpdateTelemetryDelegate(UpdateTelemetryGauges), new object[] { telemetryUpdate });
                            this.Invoke(new UpdateWarningDelegate(updateWarnings),          new object[] { telemetryUpdate.WarningCode });   
                        }
                        else
                        {
                            updateTelemetryDelegate?.Invoke(telemetryUpdate);
                            updateWarningDelegate?.Invoke(telemetryUpdate.WarningCode); 
                            

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
            public double      Throttle { get; set; } = 0;
            public double ElevatorPitch { get; set; } = 0;
            
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

            updateDataGridViewControls(C);
            updateTrackBarLabels(C);
           

        }
        #endregion Receive and Send Data




        #region Telemetry Updating

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
       
        private void updateTrackBarLabels(ControlsUpdate C)
        {
                labelThrottlePercent.Text = C.Throttle.ToString() + "%";
                  labelEpitchDegrees.Text = C.ElevatorPitch.ToString() + "°"; 
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

            labelAltitudeGauge.Text = telemObj.Altitude.ToString("F2");
               labelSpeedGauge.Text = telemObj.Speed.ToString("F2");
               labelPitchGauge.Text = telemObj.Pitch.ToString("F2");
              labelEpitchGauge.Text = telemObj.ElevatorPitch.ToString("F2");
           labelVertSpeedGauge.Text = telemObj.VerticalSpeed.ToString("F2");
            labelThrottleGauge.Text = telemObj.Throttle.ToString("F2");

            // makes controller trackbar match flight sim trackbars.
            trackBarPitch.Value    = (int)telemObj.ElevatorPitch;
            trackBarThrottle.Value = (int)telemObj.Throttle;

            UpdateNeedles(telemObj);


            updateDataGridView(telemObj);
           

        }

        

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
        #endregion Telemetry Updating

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

        // failed attempt at a blackbox   
        //private void updateBlackbox(TelemetryUpdate telemetry)
        //{
        //    SheetPath = SheetPath + "\\Blackbox.csv";

        //    try
        //    {
        //        using (StreamWriter writer = File.AppendText(SheetPath))
        //        {
        //            writer.WriteLine(string.Join(",",date,time,telemetry.Altitude,telemetry.Pitch,telemetry.ElevatorPitch,telemetry.Speed,telemetry.VerticalSpeed,telemetry.Throttle));
        //        }


        //    }
        //    catch
        //    {
        //        MessageBox.Show("Blackbox Malfunction");
        //    }


        //}



        // failed attempt at an autopilot button
        //private void Autopilot()
        //{
        //    ControlsUpdate controls = new ControlsUpdate();


        //    while (autopilotOn)
        //    {
        //        double altitude = double.Parse(labelAltitudeGauge.Text.ToString());
        //        double    pitch = double.Parse(labelPitchGauge.Text.ToString());
        //        double    speed = double.Parse(labelSpeedGauge.Text.ToString());



        //        List<List<double>> listOfLists = new List<List<double>>
        //        {   
        //            //               criuse alt   pitch                             Throttle     Elev Pitch       
        //             new List<double> { 5000.0, 10.0, -10.0 }, new List<double> { 100.0, 3.0, -1.0 },
        //            //                                                         
        //        };
        //           // if alt is greater than 5000
        //        if(altitude > listOfLists[0][0])
        //        {
        //            if (pitch > listOfLists[0][1])
        //            {
        //                // drop pitch
        //                controls.ElevatorPitch = listOfLists[1][2];
        //                controls.Throttle = listOfLists[1][0];
        //            }

        //            else if (pitch < listOfLists[0][2])
        //            {
        //                // raises pitch
        //                controls.ElevatorPitch = listOfLists[1][1];
        //                controls.Throttle = listOfLists[1][0];
        //            }
        //        }
        //        // of al is less than 5000
        //        if(altitude <= listOfLists[0][0])
        //        {
        //            // if pitch is too high
        //            if (pitch > listOfLists[0][1])
        //                // drop pitch
        //            {
        //                controls.ElevatorPitch = listOfLists[1][2];
        //                controls.Throttle = listOfLists[1][0];
        //            }

        //            else if (pitch < listOfLists[0][2])
        //            {
        //                controls.ElevatorPitch = listOfLists[1][1];
        //                controls.Throttle = listOfLists[1][0];
        //            }
        //        }
        //        if(altitude >= listOfLists[0][0])
        //        {
        //            if (pitch > listOfLists[0][1])
        //            // drop pitch
        //            {
        //                controls.ElevatorPitch = listOfLists[1][2];
        //                controls.Throttle = listOfLists[1][0];
        //            }

        //            else if (pitch < listOfLists[0][2])
        //            {
        //                controls.ElevatorPitch = listOfLists[1][1];
        //                controls.Throttle = listOfLists[1][0];
        //            }
        //        }



        //        if (this.InvokeRequired)
        //        {

        //            this.Invoke(new SendTelemetryDelegate(SendData), new object[] { controls });

        //        }
        //        else
        //        {
        //            sendTelemetry?.Invoke(controls);
        //        }



        //    }
        //}
       
    }
}
