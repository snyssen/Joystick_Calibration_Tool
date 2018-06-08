using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Joystick_Calibration_Tool
{
    public partial class FormCalibration : Form
    {
        int[] Liste_Bauds = new int[]
        {
            50,
            75,
            110,
            150,
            300,
            600,
            1200,
            1800,
            2400,
            4800,
            7200,
            9600,
            14400,
            19200,
            38400,
            56000,
            57600,
            76800,
            115200,
            128000,
            230400,
            256000,
            460800
        };
        int NbrLignes = 0;
        DonneesJoy donneesJoy = new DonneesJoy();

        public FormCalibration()
        {
            InitializeComponent();
            foreach (int Baud in Liste_Bauds) //Affiche les valeurs dans la CB
            {
                CB_Baud.Items.Add(Baud);
            }
            RTB_Recu.Text = "Appuyez sur \"Connexion\" après avoir entré le port et le baudrate à utiliser pour continuer...";
            CB_Baud.SelectedIndex = 11; // 9600 bauds de sélectionné par défaut
        }

        private void SP_Joy_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            try
            {
                string Donnees = sp.ReadLine();
                string[] SplitDonnees = Donnees.Split(';');
                if (SplitDonnees.Length >= 5) // Il peut arriver, notamment lorsqu'on vient d'ouvrir la connexion, qu'on ne reçoive pas les messages en entier; il est donc important de faire toutes les vérifs suivantes au cas où le message serait corrompu
                {
                    // Rappel : TryParse renvoie vrai si la conversion réussi, sinon faux
                    bool IsvGachette = int.TryParse(SplitDonnees[0], out int vGachette);
                    bool IsvMissile = int.TryParse(SplitDonnees[1], out int vMissile);
                    bool IsvAxeX = int.TryParse(SplitDonnees[2], out int vAxeX);
                    bool IsvAxeY = int.TryParse(SplitDonnees[3], out int vAxeY);
                    bool IsvThrottle = int.TryParse(SplitDonnees[4], out int vThrottle);
                    // Si il y a erreur de conversion, on envoie la valeur par défaut => pour un bouton, bouton non appuyé | pour un axe, axe au centre
                    donneesJoy = new DonneesJoy(IsvGachette ? vGachette : 0, IsvMissile ? vMissile : 0, IsvAxeX ? vAxeX : 128, IsvAxeY ? vAxeY : 128, IsvThrottle ? vThrottle : 128);
                }
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("Temps de lecture dépassé ! Il semblerait que le port ne répond pas...\n\n" + ex.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                if (SP_Joy.IsOpen)
                    Close_Serial_Port(SP_Joy);
                timer1.Stop();
            }
        }

        private void SP_Joy_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            Close_Serial_Port(SP_Joy);
            MessageBox.Show("Erreur sur le port série !\n\n" + e.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CB_Port_MouseClick(object sender, MouseEventArgs e)
        {
            Close_Serial_Port(SP_Joy);
            string[] ports = System.IO.Ports.SerialPort.GetPortNames(); //Récupère les ports utilisés
            CB_Port.Items.Clear();

            // Affiche les noms des ports utilisés dans la CB
            foreach (string port in ports)
            {
                CB_Port.Items.Add(port);
            }
        }

        private void CB_Port_SelectedIndexChanged(object sender, EventArgs e)
        {
            Close_Serial_Port(SP_Joy);
            SP_Joy.PortName = (string)CB_Port.SelectedItem;
        }

        private void Close_Serial_Port(SerialPort sp)
        {
            sp.Close();
            //RTB_Recu.Text = "Connexion interrompue";
            btnConnexion.Enabled = true;
            timer1.Stop();
            timer1.Enabled = false;
        }

        private void CB_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {
            Close_Serial_Port(SP_Joy);
            SP_Joy.BaudRate = (int)CB_Baud.SelectedItem;
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (CB_Port.SelectedItem == null)
                MessageBox.Show("Veuillez choisir un port avant de continuer !"); // Le port défini par défaut (COM1) n'existe pas forcément sur l'ordinateur de l'utilisateur, et pourrait donc causer un crash dans ce cas. On force donc l'utilisateur à choisir un port valable
            else
            {
                SP_Joy.Open();
                if (SP_Joy.IsOpen)
                {
                    RTB_Recu.Text = "Connexion établie";
                    btnConnexion.Enabled = false;
                    timer1.Enabled = true;
                    timer1.Start();
                }
                else
                    MessageBox.Show("Erreur lors de l'ouverture de la connexion !");
            }
        }

        private void FormCalibration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close_Serial_Port(SP_Joy);
        }

        private void timer1_Tick(object sender, EventArgs e) // tick toutes les 10ms
        {
            if (cbMessages.Checked)
            {
                if (NbrLignes % 10 == 0) // On ne met à jour la console que toutes les 100 ms pour éviter de la surcharger
                {
                    if (NbrLignes == 0 || NbrLignes > 190) // Valeur = max nbr lignes que peut supporter notre RTB sans scroll * 10 vu qu'on utilise également NbrLignes comme compteur
                    {
                        RTB_Recu.Text = "";
                        NbrLignes = 0;
                    }
                    RTB_Recu.Text += donneesJoy.vGachette.ToString() + "/" + donneesJoy.vMissile.ToString() + "/" + donneesJoy.vAxeX + "/" + donneesJoy.vAxeY + "/" + donneesJoy.vThrottle + "\n";
                }
                NbrLignes++;
            }
            DrawAll();
        }

        private void cbMessages_CheckedChanged(object sender, EventArgs e)
        {
            RTB_Recu.Text = "";
            NbrLignes = 0;
        }

        private void DrawAll()
        {
            DrawButtons();
            DrawThrottle();
            DrawJoystick();
        }
        private void DrawThrottle()
        {
            gb_Throttle.Invalidate();
        }
        private void DrawJoystick()
        {
            gb_Joystick.Invalidate();
        }
        private void DrawButtons()
        {
            pbGachette.Image = donneesJoy.vGachette ? Properties.Resources._2000px_Button_Icon_Green_svg : Properties.Resources._2000px_Redbutton_svg;
            pbMissile.Image =  donneesJoy.vMissile ? Properties.Resources._2000px_Button_Icon_Green_svg : Properties.Resources._2000px_Redbutton_svg;
        }

        private void gb_Throttle_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = (GroupBox)sender;
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), 0, gb.Height / 2, gb.Width, gb.Height / 2);
            if (SP_Joy.IsOpen)
            {
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red), 2), gb.Width / 2, gb.Height - (donneesJoy.vThrottle * gb.Height / 256), 5, 5);
                lblThrottle.Text = donneesJoy.vThrottle.ToString();
            }
        }

        private void gb_Joystick_Paint(object sender, PaintEventArgs e)
        {
            GroupBox gb = (GroupBox)sender;
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), 0, gb.Height / 2, gb.Width, gb.Height / 2);
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), gb.Width / 2, 0, gb.Width / 2, gb.Height);
            if (SP_Joy.IsOpen)
            {
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red), 2), gb.Width - (donneesJoy.vAxeX * gb.Width / 256), donneesJoy.vAxeY * gb.Height / 256, 5, 5);
                lblJoystick.Text = donneesJoy.vAxeX.ToString() + ";" + donneesJoy.vAxeY.ToString();
            }
        }
    }

    class DonneesJoy
    {
        #region Donnees membres
        private bool _vGachette;
        private bool _vMissile;
        private int _vAxeX;
        private int _vAxeY;
        private int _vThrottle;
        #endregion
        #region Constructeurs
        public DonneesJoy() { }
        public DonneesJoy(bool vGachette_, bool vMissile_, int vAxeX_, int vAxeY_, int vThrottle_)
        {
            vGachette = vGachette_;
            vMissile = vMissile_;
            vAxeX = vAxeX_;
            vAxeY = vAxeY_;
            vThrottle = vThrottle_;
        }
        public DonneesJoy(int vGachette_, int vMissile_, int vAxeX_, int vAxeY_, int vThrottle_)
        {
            if (vGachette_ > 0)
                vGachette = true;
            else
                vGachette = false;
            if (vMissile_ > 0)
                vMissile = true;
            else
                vMissile = false;
            vAxeX = vAxeX_;
            vAxeY = vAxeY_;
            vThrottle = vThrottle_;
        }
        #endregion
        #region Event
        // L'idée est ici de trigger un event lorsqu'un des valeurs de notre classe a changé (voir accesseurs pour l'appel)
        public event System.EventHandler ValueChanged;
        protected virtual void OnValueChanged()
        {
            if (ValueChanged != null)
                ValueChanged(this, EventArgs.Empty);
        }
        #endregion
        #region Accesseurs
        public bool vGachette
        {
            get { return _vGachette; }
            set { _vGachette = value; OnValueChanged(); }
        }
        public bool vMissile
        {
            get { return _vMissile; }
            set { _vMissile = value; OnValueChanged(); }
        }
        public int vAxeX
        {
            get { return _vAxeX; }
            set { _vAxeX = value; OnValueChanged(); }
        }
        public int vAxeY
        {
            get { return _vAxeY; }
            set { _vAxeY = value; OnValueChanged(); }
        }
        public int vThrottle
        {
            get { return _vThrottle; }
            set { _vThrottle = value; OnValueChanged(); }
        }
        #endregion
    }
}
