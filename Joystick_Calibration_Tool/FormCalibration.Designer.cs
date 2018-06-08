namespace Joystick_Calibration_Tool
{
    partial class FormCalibration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibration));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_Port = new System.Windows.Forms.ComboBox();
            this.CB_Baud = new System.Windows.Forms.ComboBox();
            this.btnConnexion = new System.Windows.Forms.Button();
            this.SP_Joy = new System.IO.Ports.SerialPort(this.components);
            this.RTB_Recu = new System.Windows.Forms.RichTextBox();
            this.gb_Joystick = new System.Windows.Forms.GroupBox();
            this.lblJoystick = new System.Windows.Forms.Label();
            this.gb_Throttle = new System.Windows.Forms.GroupBox();
            this.lblThrottle = new System.Windows.Forms.Label();
            this.gb_Boutons = new System.Windows.Forms.GroupBox();
            this.lblMissile = new System.Windows.Forms.Label();
            this.lblGachette = new System.Windows.Forms.Label();
            this.pbMissile = new System.Windows.Forms.PictureBox();
            this.pbGachette = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbMessages = new System.Windows.Forms.CheckBox();
            this.gb_Joystick.SuspendLayout();
            this.gb_Throttle.SuspendLayout();
            this.gb_Boutons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMissile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGachette)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Bauds :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Port :";
            // 
            // CB_Port
            // 
            this.CB_Port.FormattingEnabled = true;
            this.CB_Port.Location = new System.Drawing.Point(72, 7);
            this.CB_Port.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Port.Name = "CB_Port";
            this.CB_Port.Size = new System.Drawing.Size(92, 21);
            this.CB_Port.TabIndex = 10;
            this.CB_Port.SelectedIndexChanged += new System.EventHandler(this.CB_Port_SelectedIndexChanged);
            this.CB_Port.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CB_Port_MouseClick);
            // 
            // CB_Baud
            // 
            this.CB_Baud.FormattingEnabled = true;
            this.CB_Baud.Location = new System.Drawing.Point(72, 36);
            this.CB_Baud.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Baud.Name = "CB_Baud";
            this.CB_Baud.Size = new System.Drawing.Size(92, 21);
            this.CB_Baud.TabIndex = 9;
            this.CB_Baud.SelectedIndexChanged += new System.EventHandler(this.CB_Baud_SelectedIndexChanged);
            // 
            // btnConnexion
            // 
            this.btnConnexion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConnexion.Location = new System.Drawing.Point(13, 61);
            this.btnConnexion.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(153, 23);
            this.btnConnexion.TabIndex = 13;
            this.btnConnexion.Text = "Connexion";
            this.btnConnexion.UseVisualStyleBackColor = false;
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            // 
            // SP_Joy
            // 
            this.SP_Joy.ReadTimeout = 3000;
            this.SP_Joy.ErrorReceived += new System.IO.Ports.SerialErrorReceivedEventHandler(this.SP_Joy_ErrorReceived);
            this.SP_Joy.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SP_Joy_DataReceived);
            // 
            // RTB_Recu
            // 
            this.RTB_Recu.BackColor = System.Drawing.SystemColors.WindowText;
            this.RTB_Recu.DetectUrls = false;
            this.RTB_Recu.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.RTB_Recu.Location = new System.Drawing.Point(12, 106);
            this.RTB_Recu.Margin = new System.Windows.Forms.Padding(6);
            this.RTB_Recu.Name = "RTB_Recu";
            this.RTB_Recu.ReadOnly = true;
            this.RTB_Recu.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.RTB_Recu.Size = new System.Drawing.Size(153, 256);
            this.RTB_Recu.TabIndex = 14;
            this.RTB_Recu.Text = "";
            this.RTB_Recu.WordWrap = false;
            // 
            // gb_Joystick
            // 
            this.gb_Joystick.Controls.Add(this.lblJoystick);
            this.gb_Joystick.Location = new System.Drawing.Point(247, 7);
            this.gb_Joystick.Name = "gb_Joystick";
            this.gb_Joystick.Size = new System.Drawing.Size(250, 250);
            this.gb_Joystick.TabIndex = 16;
            this.gb_Joystick.TabStop = false;
            this.gb_Joystick.Text = "Joystick";
            this.gb_Joystick.Paint += new System.Windows.Forms.PaintEventHandler(this.gb_Joystick_Paint);
            // 
            // lblJoystick
            // 
            this.lblJoystick.AutoSize = true;
            this.lblJoystick.Location = new System.Drawing.Point(0, 237);
            this.lblJoystick.Name = "lblJoystick";
            this.lblJoystick.Size = new System.Drawing.Size(66, 13);
            this.lblJoystick.TabIndex = 1;
            this.lblJoystick.Text = "Pos Joystick";
            // 
            // gb_Throttle
            // 
            this.gb_Throttle.Controls.Add(this.lblThrottle);
            this.gb_Throttle.Location = new System.Drawing.Point(171, 7);
            this.gb_Throttle.Name = "gb_Throttle";
            this.gb_Throttle.Size = new System.Drawing.Size(70, 355);
            this.gb_Throttle.TabIndex = 17;
            this.gb_Throttle.TabStop = false;
            this.gb_Throttle.Text = "Throttle";
            this.gb_Throttle.Paint += new System.Windows.Forms.PaintEventHandler(this.gb_Throttle_Paint);
            // 
            // lblThrottle
            // 
            this.lblThrottle.AutoSize = true;
            this.lblThrottle.Location = new System.Drawing.Point(-3, 342);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.Size = new System.Drawing.Size(64, 13);
            this.lblThrottle.TabIndex = 0;
            this.lblThrottle.Text = "Pos Throttle";
            // 
            // gb_Boutons
            // 
            this.gb_Boutons.Controls.Add(this.lblMissile);
            this.gb_Boutons.Controls.Add(this.lblGachette);
            this.gb_Boutons.Controls.Add(this.pbMissile);
            this.gb_Boutons.Controls.Add(this.pbGachette);
            this.gb_Boutons.Location = new System.Drawing.Point(247, 263);
            this.gb_Boutons.Name = "gb_Boutons";
            this.gb_Boutons.Size = new System.Drawing.Size(250, 99);
            this.gb_Boutons.TabIndex = 18;
            this.gb_Boutons.TabStop = false;
            this.gb_Boutons.Text = "Boutons";
            // 
            // lblMissile
            // 
            this.lblMissile.AutoSize = true;
            this.lblMissile.Location = new System.Drawing.Point(171, 27);
            this.lblMissile.Name = "lblMissile";
            this.lblMissile.Size = new System.Drawing.Size(38, 13);
            this.lblMissile.TabIndex = 3;
            this.lblMissile.Text = "Missile";
            // 
            // lblGachette
            // 
            this.lblGachette.AutoSize = true;
            this.lblGachette.Location = new System.Drawing.Point(44, 27);
            this.lblGachette.Name = "lblGachette";
            this.lblGachette.Size = new System.Drawing.Size(51, 13);
            this.lblGachette.TabIndex = 2;
            this.lblGachette.Text = "Gachette";
            // 
            // pbMissile
            // 
            this.pbMissile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbMissile.Image = global::Joystick_Calibration_Tool.Properties.Resources._2000px_Redbutton_svg;
            this.pbMissile.Location = new System.Drawing.Point(159, 43);
            this.pbMissile.Name = "pbMissile";
            this.pbMissile.Size = new System.Drawing.Size(50, 50);
            this.pbMissile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMissile.TabIndex = 1;
            this.pbMissile.TabStop = false;
            // 
            // pbGachette
            // 
            this.pbGachette.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbGachette.Image = global::Joystick_Calibration_Tool.Properties.Resources._2000px_Redbutton_svg;
            this.pbGachette.Location = new System.Drawing.Point(47, 43);
            this.pbGachette.Name = "pbGachette";
            this.pbGachette.Size = new System.Drawing.Size(50, 50);
            this.pbGachette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGachette.TabIndex = 0;
            this.pbGachette.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbMessages
            // 
            this.cbMessages.AutoSize = true;
            this.cbMessages.Checked = true;
            this.cbMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMessages.Location = new System.Drawing.Point(14, 89);
            this.cbMessages.Name = "cbMessages";
            this.cbMessages.Size = new System.Drawing.Size(144, 17);
            this.cbMessages.TabIndex = 19;
            this.cbMessages.Text = "Derniers messages reçus";
            this.cbMessages.UseVisualStyleBackColor = true;
            this.cbMessages.CheckedChanged += new System.EventHandler(this.cbMessages_CheckedChanged);
            // 
            // FormCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 374);
            this.Controls.Add(this.cbMessages);
            this.Controls.Add(this.gb_Boutons);
            this.Controls.Add(this.gb_Throttle);
            this.Controls.Add(this.gb_Joystick);
            this.Controls.Add(this.RTB_Recu);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Port);
            this.Controls.Add(this.CB_Baud);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormCalibration";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calibration du joystick";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCalibration_FormClosing);
            this.gb_Joystick.ResumeLayout(false);
            this.gb_Joystick.PerformLayout();
            this.gb_Throttle.ResumeLayout(false);
            this.gb_Throttle.PerformLayout();
            this.gb_Boutons.ResumeLayout(false);
            this.gb_Boutons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMissile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGachette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_Port;
        private System.Windows.Forms.ComboBox CB_Baud;
        private System.Windows.Forms.Button btnConnexion;
        private System.IO.Ports.SerialPort SP_Joy;
        private System.Windows.Forms.RichTextBox RTB_Recu;
        private System.Windows.Forms.GroupBox gb_Joystick;
        private System.Windows.Forms.GroupBox gb_Throttle;
        private System.Windows.Forms.GroupBox gb_Boutons;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbMessages;
        private System.Windows.Forms.Label lblJoystick;
        private System.Windows.Forms.Label lblThrottle;
        private System.Windows.Forms.PictureBox pbGachette;
        private System.Windows.Forms.PictureBox pbMissile;
        private System.Windows.Forms.Label lblMissile;
        private System.Windows.Forms.Label lblGachette;
    }
}

