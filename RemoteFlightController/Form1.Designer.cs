using System.Drawing;
using System.Windows.Forms;

namespace _30051129_RemoteFlightController
{
    partial class RemoteFlightController
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteFlightController));
            this.panelConnection = new System.Windows.Forms.Panel();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.labelConnectOrNot = new System.Windows.Forms.Label();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.dataGridViewTelemetry = new System.Windows.Forms.DataGridView();
            this.Altitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VerticalSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Throttle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElevatorPitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBoxAltitude = new System.Windows.Forms.PictureBox();
            this.pictureBoxPitch = new System.Windows.Forms.PictureBox();
            this.pictureBoxControls = new System.Windows.Forms.PictureBox();
            this.pictureBoxWarnings = new System.Windows.Forms.PictureBox();
            this.trackBarThrottle = new System.Windows.Forms.TrackBar();
            this.trackBarPitch = new System.Windows.Forms.TrackBar();
            this.labelWarnings = new System.Windows.Forms.Label();
            this.labelThrottlePercent = new System.Windows.Forms.Label();
            this.labelEpitchDegrees = new System.Windows.Forms.Label();
            this.labelThrottle = new System.Windows.Forms.Label();
            this.labelEpitch = new System.Windows.Forms.Label();
            this.labelAltitudeGauge = new System.Windows.Forms.Label();
            this.pictureBoxSpeed = new System.Windows.Forms.PictureBox();
            this.pictureBoxEpitch = new System.Windows.Forms.PictureBox();
            this.pictureBoxVspeed = new System.Windows.Forms.PictureBox();
            this.pictureBoxThrottle = new System.Windows.Forms.PictureBox();
            this.labelSpeedGauge = new System.Windows.Forms.Label();
            this.labelPitchGauge = new System.Windows.Forms.Label();
            this.labelEpitchGauge = new System.Windows.Forms.Label();
            this.labelVertSpeedGauge = new System.Windows.Forms.Label();
            this.labelThrottleGauge = new System.Windows.Forms.Label();
            this.dataGridViewControls = new System.Windows.Forms.DataGridView();
            this.ControlThrottle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlEpitch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonAutoPilot = new System.Windows.Forms.Button();
            this.labelAutoPilotActivation = new System.Windows.Forms.Label();
            this.panelConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelemetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAltitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarnings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThrottle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVspeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThrottle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControls)).BeginInit();
            this.SuspendLayout();
            // 
            // panelConnection
            // 
            this.panelConnection.Controls.Add(this.buttonHelp);
            this.panelConnection.Controls.Add(this.labelConnectOrNot);
            this.panelConnection.Controls.Add(this.labelConnectionStatus);
            this.panelConnection.Controls.Add(this.buttonClose);
            this.panelConnection.Controls.Add(this.buttonDisconnect);
            this.panelConnection.Controls.Add(this.buttonConnect);
            this.panelConnection.Controls.Add(this.labelIP);
            this.panelConnection.Controls.Add(this.labelPort);
            this.panelConnection.Controls.Add(this.textBoxPort);
            this.panelConnection.Controls.Add(this.textBoxIP);
            this.panelConnection.Location = new System.Drawing.Point(13, 405);
            this.panelConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(330, 217);
            this.panelConnection.TabIndex = 0;
            // 
            // buttonHelp
            // 
            this.buttonHelp.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonHelp.Location = new System.Drawing.Point(203, 141);
            this.buttonHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(110, 26);
            this.buttonHelp.TabIndex = 10;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = false;
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // labelConnectOrNot
            // 
            this.labelConnectOrNot.AutoSize = true;
            this.labelConnectOrNot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelConnectOrNot.Location = new System.Drawing.Point(200, 98);
            this.labelConnectOrNot.Name = "labelConnectOrNot";
            this.labelConnectOrNot.Size = new System.Drawing.Size(118, 18);
            this.labelConnectOrNot.TabIndex = 9;
            this.labelConnectOrNot.Text = "Disonnected";
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelConnectionStatus.Location = new System.Drawing.Point(11, 98);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(188, 18);
            this.labelConnectionStatus.TabIndex = 8;
            this.labelConnectionStatus.Text = "Connection Status:";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Location = new System.Drawing.Point(203, 173);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(110, 26);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.BackColor = System.Drawing.Color.White;
            this.buttonDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDisconnect.Font = new System.Drawing.Font("Disket Mono", 8.249999F);
            this.buttonDisconnect.Location = new System.Drawing.Point(22, 173);
            this.buttonDisconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(110, 26);
            this.buttonDisconnect.TabIndex = 5;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = false;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.White;
            this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonConnect.Location = new System.Drawing.Point(22, 141);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(110, 26);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Disket Mono", 8.999999F, System.Drawing.FontStyle.Bold);
            this.labelIP.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelIP.Location = new System.Drawing.Point(11, 24);
            this.labelIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(108, 18);
            this.labelIP.TabIndex = 3;
            this.labelIP.Text = "IP Address";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("Disket Mono", 8.999999F, System.Drawing.FontStyle.Bold);
            this.labelPort.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPort.Location = new System.Drawing.Point(59, 60);
            this.labelPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(48, 18);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(133, 57);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(115, 24);
            this.textBoxPort.TabIndex = 1;
            this.textBoxPort.Text = "9999";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(133, 21);
            this.textBoxIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(180, 24);
            this.textBoxIP.TabIndex = 0;
            // 
            // dataGridViewTelemetry
            // 
            this.dataGridViewTelemetry.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewTelemetry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTelemetry.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Altitude,
            this.AirSpeed,
            this.Pitch,
            this.VerticalSpeed,
            this.Throttle,
            this.ElevatorPitch});
            this.dataGridViewTelemetry.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewTelemetry.Location = new System.Drawing.Point(351, 405);
            this.dataGridViewTelemetry.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridViewTelemetry.Name = "dataGridViewTelemetry";
            this.dataGridViewTelemetry.RowHeadersWidth = 51;
            this.dataGridViewTelemetry.Size = new System.Drawing.Size(668, 217);
            this.dataGridViewTelemetry.TabIndex = 1;
            this.dataGridViewTelemetry.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewTelemetry_RowsAdded);
            // 
            // Altitude
            // 
            this.Altitude.HeaderText = "Altitude (ft)";
            this.Altitude.MinimumWidth = 6;
            this.Altitude.Name = "Altitude";
            this.Altitude.ReadOnly = true;
            this.Altitude.Width = 125;
            // 
            // AirSpeed
            // 
            this.AirSpeed.HeaderText = "Air Speed (knots)";
            this.AirSpeed.MinimumWidth = 6;
            this.AirSpeed.Name = "AirSpeed";
            this.AirSpeed.ReadOnly = true;
            this.AirSpeed.Width = 125;
            // 
            // Pitch
            // 
            this.Pitch.HeaderText = "Pitch (Degrees)";
            this.Pitch.MinimumWidth = 6;
            this.Pitch.Name = "Pitch";
            this.Pitch.ReadOnly = true;
            this.Pitch.Width = 125;
            // 
            // VerticalSpeed
            // 
            this.VerticalSpeed.HeaderText = "Vertical Speed (Ft/min)";
            this.VerticalSpeed.MinimumWidth = 6;
            this.VerticalSpeed.Name = "VerticalSpeed";
            this.VerticalSpeed.ReadOnly = true;
            this.VerticalSpeed.Width = 125;
            // 
            // Throttle
            // 
            this.Throttle.HeaderText = "Throttle";
            this.Throttle.MinimumWidth = 6;
            this.Throttle.Name = "Throttle";
            this.Throttle.ReadOnly = true;
            this.Throttle.Width = 125;
            // 
            // ElevatorPitch
            // 
            this.ElevatorPitch.HeaderText = "Elevator Pitch";
            this.ElevatorPitch.MinimumWidth = 6;
            this.ElevatorPitch.Name = "ElevatorPitch";
            this.ElevatorPitch.ReadOnly = true;
            this.ElevatorPitch.Width = 125;
            // 
            // pictureBoxAltitude
            // 
            this.pictureBoxAltitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAltitude.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAltitude.Image")));
            this.pictureBoxAltitude.Location = new System.Drawing.Point(13, 12);
            this.pictureBoxAltitude.Name = "pictureBoxAltitude";
            this.pictureBoxAltitude.Size = new System.Drawing.Size(193, 177);
            this.pictureBoxAltitude.TabIndex = 2;
            this.pictureBoxAltitude.TabStop = false;
            // 
            // pictureBoxPitch
            // 
            this.pictureBoxPitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPitch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPitch.Image")));
            this.pictureBoxPitch.Location = new System.Drawing.Point(445, 12);
            this.pictureBoxPitch.Name = "pictureBoxPitch";
            this.pictureBoxPitch.Size = new System.Drawing.Size(193, 177);
            this.pictureBoxPitch.TabIndex = 4;
            this.pictureBoxPitch.TabStop = false;
            // 
            // pictureBoxControls
            // 
            this.pictureBoxControls.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxControls.Image")));
            this.pictureBoxControls.Location = new System.Drawing.Point(671, 12);
            this.pictureBoxControls.Name = "pictureBoxControls";
            this.pictureBoxControls.Size = new System.Drawing.Size(348, 277);
            this.pictureBoxControls.TabIndex = 8;
            this.pictureBoxControls.TabStop = false;
            // 
            // pictureBoxWarnings
            // 
            this.pictureBoxWarnings.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxWarnings.Image")));
            this.pictureBoxWarnings.Location = new System.Drawing.Point(671, 312);
            this.pictureBoxWarnings.Name = "pictureBoxWarnings";
            this.pictureBoxWarnings.Size = new System.Drawing.Size(348, 75);
            this.pictureBoxWarnings.TabIndex = 9;
            this.pictureBoxWarnings.TabStop = false;
            // 
            // trackBarThrottle
            // 
            this.trackBarThrottle.BackColor = System.Drawing.Color.Black;
            this.trackBarThrottle.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.trackBarThrottle.Location = new System.Drawing.Point(772, 59);
            this.trackBarThrottle.Maximum = 100;
            this.trackBarThrottle.Name = "trackBarThrottle";
            this.trackBarThrottle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarThrottle.Size = new System.Drawing.Size(56, 222);
            this.trackBarThrottle.SmallChange = 5;
            this.trackBarThrottle.TabIndex = 10;
            this.trackBarThrottle.Tag = "Throttle";
            this.trackBarThrottle.TickFrequency = 10;
            this.trackBarThrottle.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarThrottle.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // trackBarPitch
            // 
            this.trackBarPitch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.trackBarPitch.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.trackBarPitch.Location = new System.Drawing.Point(904, 59);
            this.trackBarPitch.Maximum = 5;
            this.trackBarPitch.Minimum = -5;
            this.trackBarPitch.Name = "trackBarPitch";
            this.trackBarPitch.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarPitch.Size = new System.Drawing.Size(56, 222);
            this.trackBarPitch.TabIndex = 11;
            this.trackBarPitch.Tag = "ePitch";
            this.trackBarPitch.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarPitch.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // labelWarnings
            // 
            this.labelWarnings.AutoSize = true;
            this.labelWarnings.Font = new System.Drawing.Font("Disket Mono", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelWarnings.ForeColor = System.Drawing.Color.Red;
            this.labelWarnings.Location = new System.Drawing.Point(743, 335);
            this.labelWarnings.Name = "labelWarnings";
            this.labelWarnings.Size = new System.Drawing.Size(204, 31);
            this.labelWarnings.TabIndex = 12;
            this.labelWarnings.Text = "No Warning";
            this.labelWarnings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelThrottlePercent
            // 
            this.labelThrottlePercent.AutoSize = true;
            this.labelThrottlePercent.BackColor = System.Drawing.Color.Black;
            this.labelThrottlePercent.Font = new System.Drawing.Font("Disket Mono", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelThrottlePercent.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelThrottlePercent.Location = new System.Drawing.Point(695, 130);
            this.labelThrottlePercent.Name = "labelThrottlePercent";
            this.labelThrottlePercent.Size = new System.Drawing.Size(54, 32);
            this.labelThrottlePercent.TabIndex = 13;
            this.labelThrottlePercent.Text = "0%";
            // 
            // labelEpitchDegrees
            // 
            this.labelEpitchDegrees.AutoSize = true;
            this.labelEpitchDegrees.BackColor = System.Drawing.Color.Black;
            this.labelEpitchDegrees.Font = new System.Drawing.Font("Disket Mono", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelEpitchDegrees.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelEpitchDegrees.Location = new System.Drawing.Point(846, 130);
            this.labelEpitchDegrees.Name = "labelEpitchDegrees";
            this.labelEpitchDegrees.Size = new System.Drawing.Size(54, 32);
            this.labelEpitchDegrees.TabIndex = 14;
            this.labelEpitchDegrees.Text = "0°";
            // 
            // labelThrottle
            // 
            this.labelThrottle.AutoSize = true;
            this.labelThrottle.BackColor = System.Drawing.Color.Black;
            this.labelThrottle.Font = new System.Drawing.Font("Disket Mono", 10.8F);
            this.labelThrottle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelThrottle.Location = new System.Drawing.Point(734, 35);
            this.labelThrottle.Name = "labelThrottle";
            this.labelThrottle.Size = new System.Drawing.Size(114, 21);
            this.labelThrottle.TabIndex = 15;
            this.labelThrottle.Text = "Throttle";
            // 
            // labelEpitch
            // 
            this.labelEpitch.AutoSize = true;
            this.labelEpitch.BackColor = System.Drawing.Color.Black;
            this.labelEpitch.Font = new System.Drawing.Font("Disket Mono", 10.8F);
            this.labelEpitch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelEpitch.Location = new System.Drawing.Point(870, 35);
            this.labelEpitch.Name = "labelEpitch";
            this.labelEpitch.Size = new System.Drawing.Size(101, 21);
            this.labelEpitch.TabIndex = 16;
            this.labelEpitch.Text = "E.Pitch";
            // 
            // labelAltitudeGauge
            // 
            this.labelAltitudeGauge.AutoSize = true;
            this.labelAltitudeGauge.BackColor = System.Drawing.Color.Transparent;
            this.labelAltitudeGauge.Font = new System.Drawing.Font("Disket Mono", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelAltitudeGauge.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelAltitudeGauge.Location = new System.Drawing.Point(45, 123);
            this.labelAltitudeGauge.Name = "labelAltitudeGauge";
            this.labelAltitudeGauge.Size = new System.Drawing.Size(44, 27);
            this.labelAltitudeGauge.TabIndex = 17;
            this.labelAltitudeGauge.Text = "00";
            this.labelAltitudeGauge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxSpeed
            // 
            this.pictureBoxSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSpeed.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSpeed.Image")));
            this.pictureBoxSpeed.Location = new System.Drawing.Point(228, 12);
            this.pictureBoxSpeed.Name = "pictureBoxSpeed";
            this.pictureBoxSpeed.Size = new System.Drawing.Size(193, 177);
            this.pictureBoxSpeed.TabIndex = 18;
            this.pictureBoxSpeed.TabStop = false;
            // 
            // pictureBoxEpitch
            // 
            this.pictureBoxEpitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxEpitch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEpitch.Image")));
            this.pictureBoxEpitch.Location = new System.Drawing.Point(12, 210);
            this.pictureBoxEpitch.Name = "pictureBoxEpitch";
            this.pictureBoxEpitch.Size = new System.Drawing.Size(193, 177);
            this.pictureBoxEpitch.TabIndex = 19;
            this.pictureBoxEpitch.TabStop = false;
            // 
            // pictureBoxVspeed
            // 
            this.pictureBoxVspeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxVspeed.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxVspeed.Image")));
            this.pictureBoxVspeed.Location = new System.Drawing.Point(228, 210);
            this.pictureBoxVspeed.Name = "pictureBoxVspeed";
            this.pictureBoxVspeed.Size = new System.Drawing.Size(193, 177);
            this.pictureBoxVspeed.TabIndex = 20;
            this.pictureBoxVspeed.TabStop = false;
            // 
            // pictureBoxThrottle
            // 
            this.pictureBoxThrottle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxThrottle.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxThrottle.Image")));
            this.pictureBoxThrottle.Location = new System.Drawing.Point(445, 210);
            this.pictureBoxThrottle.Name = "pictureBoxThrottle";
            this.pictureBoxThrottle.Size = new System.Drawing.Size(193, 177);
            this.pictureBoxThrottle.TabIndex = 21;
            this.pictureBoxThrottle.TabStop = false;
            // 
            // labelSpeedGauge
            // 
            this.labelSpeedGauge.AutoSize = true;
            this.labelSpeedGauge.BackColor = System.Drawing.Color.Transparent;
            this.labelSpeedGauge.Font = new System.Drawing.Font("Disket Mono", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelSpeedGauge.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelSpeedGauge.Location = new System.Drawing.Point(265, 123);
            this.labelSpeedGauge.Name = "labelSpeedGauge";
            this.labelSpeedGauge.Size = new System.Drawing.Size(44, 27);
            this.labelSpeedGauge.TabIndex = 22;
            this.labelSpeedGauge.Text = "00";
            this.labelSpeedGauge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPitchGauge
            // 
            this.labelPitchGauge.AutoSize = true;
            this.labelPitchGauge.BackColor = System.Drawing.Color.Transparent;
            this.labelPitchGauge.Font = new System.Drawing.Font("Disket Mono", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelPitchGauge.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelPitchGauge.Location = new System.Drawing.Point(482, 123);
            this.labelPitchGauge.Name = "labelPitchGauge";
            this.labelPitchGauge.Size = new System.Drawing.Size(44, 27);
            this.labelPitchGauge.TabIndex = 23;
            this.labelPitchGauge.Text = "00";
            this.labelPitchGauge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEpitchGauge
            // 
            this.labelEpitchGauge.AutoSize = true;
            this.labelEpitchGauge.BackColor = System.Drawing.Color.Transparent;
            this.labelEpitchGauge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEpitchGauge.Font = new System.Drawing.Font("Disket Mono", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelEpitchGauge.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelEpitchGauge.Location = new System.Drawing.Point(50, 312);
            this.labelEpitchGauge.Name = "labelEpitchGauge";
            this.labelEpitchGauge.Size = new System.Drawing.Size(30, 29);
            this.labelEpitchGauge.TabIndex = 24;
            this.labelEpitchGauge.Text = "0";
            this.labelEpitchGauge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVertSpeedGauge
            // 
            this.labelVertSpeedGauge.AutoSize = true;
            this.labelVertSpeedGauge.BackColor = System.Drawing.Color.Transparent;
            this.labelVertSpeedGauge.Font = new System.Drawing.Font("Disket Mono", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelVertSpeedGauge.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelVertSpeedGauge.Location = new System.Drawing.Point(265, 321);
            this.labelVertSpeedGauge.Name = "labelVertSpeedGauge";
            this.labelVertSpeedGauge.Size = new System.Drawing.Size(44, 27);
            this.labelVertSpeedGauge.TabIndex = 25;
            this.labelVertSpeedGauge.Text = "00";
            this.labelVertSpeedGauge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelThrottleGauge
            // 
            this.labelThrottleGauge.AutoSize = true;
            this.labelThrottleGauge.BackColor = System.Drawing.Color.Transparent;
            this.labelThrottleGauge.Font = new System.Drawing.Font("Disket Mono", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelThrottleGauge.ForeColor = System.Drawing.Color.SpringGreen;
            this.labelThrottleGauge.Location = new System.Drawing.Point(482, 314);
            this.labelThrottleGauge.Name = "labelThrottleGauge";
            this.labelThrottleGauge.Size = new System.Drawing.Size(44, 27);
            this.labelThrottleGauge.TabIndex = 26;
            this.labelThrottleGauge.Text = "00";
            this.labelThrottleGauge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewControls
            // 
            this.dataGridViewControls.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewControls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewControls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ControlThrottle,
            this.ControlEpitch});
            this.dataGridViewControls.Location = new System.Drawing.Point(1026, 12);
            this.dataGridViewControls.Name = "dataGridViewControls";
            this.dataGridViewControls.RowHeadersWidth = 51;
            this.dataGridViewControls.RowTemplate.Height = 24;
            this.dataGridViewControls.Size = new System.Drawing.Size(271, 474);
            this.dataGridViewControls.TabIndex = 27;
            // 
            // ControlThrottle
            // 
            this.ControlThrottle.HeaderText = "Throttle";
            this.ControlThrottle.MinimumWidth = 6;
            this.ControlThrottle.Name = "ControlThrottle";
            this.ControlThrottle.Width = 125;
            // 
            // ControlEpitch
            // 
            this.ControlEpitch.HeaderText = "E.Pitch";
            this.ControlEpitch.MinimumWidth = 6;
            this.ControlEpitch.Name = "ControlEpitch";
            this.ControlEpitch.Width = 125;
            // 
            // ButtonAutoPilot
            // 
            this.ButtonAutoPilot.BackColor = System.Drawing.Color.DarkRed;
            this.ButtonAutoPilot.Font = new System.Drawing.Font("Disket Mono", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAutoPilot.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonAutoPilot.Location = new System.Drawing.Point(1087, 520);
            this.ButtonAutoPilot.Name = "ButtonAutoPilot";
            this.ButtonAutoPilot.Size = new System.Drawing.Size(165, 42);
            this.ButtonAutoPilot.TabIndex = 28;
            this.ButtonAutoPilot.Text = "Autopilot";
            this.ButtonAutoPilot.UseVisualStyleBackColor = false;
            this.ButtonAutoPilot.Click += new System.EventHandler(this.ButtonAutoPilot_Click);
            // 
            // labelAutoPilotActivation
            // 
            this.labelAutoPilotActivation.AutoSize = true;
            this.labelAutoPilotActivation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelAutoPilotActivation.Location = new System.Drawing.Point(1122, 578);
            this.labelAutoPilotActivation.Name = "labelAutoPilotActivation";
            this.labelAutoPilotActivation.Size = new System.Drawing.Size(88, 18);
            this.labelAutoPilotActivation.TabIndex = 29;
            this.labelAutoPilotActivation.Text = "Disabled";
            // 
            // RemoteFlightController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1309, 638);
            this.Controls.Add(this.labelAutoPilotActivation);
            this.Controls.Add(this.ButtonAutoPilot);
            this.Controls.Add(this.dataGridViewControls);
            this.Controls.Add(this.labelThrottleGauge);
            this.Controls.Add(this.labelVertSpeedGauge);
            this.Controls.Add(this.labelEpitchGauge);
            this.Controls.Add(this.labelPitchGauge);
            this.Controls.Add(this.labelSpeedGauge);
            this.Controls.Add(this.pictureBoxThrottle);
            this.Controls.Add(this.pictureBoxVspeed);
            this.Controls.Add(this.pictureBoxEpitch);
            this.Controls.Add(this.pictureBoxSpeed);
            this.Controls.Add(this.labelAltitudeGauge);
            this.Controls.Add(this.labelEpitch);
            this.Controls.Add(this.labelThrottle);
            this.Controls.Add(this.labelEpitchDegrees);
            this.Controls.Add(this.labelThrottlePercent);
            this.Controls.Add(this.labelWarnings);
            this.Controls.Add(this.trackBarPitch);
            this.Controls.Add(this.trackBarThrottle);
            this.Controls.Add(this.pictureBoxWarnings);
            this.Controls.Add(this.pictureBoxControls);
            this.Controls.Add(this.pictureBoxPitch);
            this.Controls.Add(this.pictureBoxAltitude);
            this.Controls.Add(this.dataGridViewTelemetry);
            this.Controls.Add(this.panelConnection);
            this.Font = new System.Drawing.Font("Disket Mono", 8.999999F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RemoteFlightController";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTelemetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAltitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWarnings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThrottle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEpitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVspeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxThrottle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewControls)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelConnection;
        private Button buttonDisconnect;
        private Button buttonConnect;
        private Label labelIP;
        private Label labelPort;
        private TextBox textBoxPort;
        private TextBox textBoxIP;
        private Button buttonClose;
        private DataGridView dataGridViewTelemetry;
        private Label labelConnectionStatus;
        private Label labelConnectOrNot;
        private DataGridViewTextBoxColumn Altitude;
        private DataGridViewTextBoxColumn AirSpeed;
        private DataGridViewTextBoxColumn Pitch;
        private DataGridViewTextBoxColumn VerticalSpeed;
        private DataGridViewTextBoxColumn Throttle;
        private DataGridViewTextBoxColumn ElevatorPitch;
        private PictureBox pictureBoxAltitude;
        private PictureBox pictureBoxPitch;
        private PictureBox pictureBoxControls;
        private PictureBox pictureBoxWarnings;
        private TrackBar trackBarThrottle;
        private TrackBar trackBarPitch;
        private Label labelWarnings;
        private Label labelThrottlePercent;
        private Label labelEpitchDegrees;
        private Label labelThrottle;
        private Label labelEpitch;
        private Label labelAltitudeGauge;
        private PictureBox pictureBoxSpeed;
        private PictureBox pictureBoxEpitch;
        private PictureBox pictureBoxVspeed;
        private PictureBox pictureBoxThrottle;
        private Label labelSpeedGauge;
        private Label labelPitchGauge;
        private Label labelEpitchGauge;
        private Label labelVertSpeedGauge;
        private Label labelThrottleGauge;
        private DataGridView dataGridViewControls;
        private DataGridViewTextBoxColumn ControlThrottle;
        private DataGridViewTextBoxColumn ControlEpitch;
        private Button buttonHelp;
        private Button ButtonAutoPilot;
        private Label labelAutoPilotActivation;
    }
}