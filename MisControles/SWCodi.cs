using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisControles
{
    public partial class SWCodi : UserControl
    {
        private bool requerit;
        private TipusNivell nivell;

        public enum TipusNivell
        {
            [Description("GM (Grau Mitja)")]
            GM = 0,
            [Description("GS (Grau Superior)")]
            GS = 1,
        }

        public SWCodi()
        {
            InitializeComponent();
        }


        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Requerit")]
        public bool Requerit
        {
            get
            {
                return requerit;
            }
            set
            {
                requerit = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Nivell")]
        public TipusNivell NivellDesitjat
        {
            get { return nivell; }
            set { nivell = value; }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Text label")]
        public string TextLabel
        {
            get
            {
                return txtLabel.Text;
            }
            set
            {
                txtLabel.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Text valor")]
        public string TextValue
        {
            get
            {
                return txtcodi.Text;
            }
            set
            {
                txtcodi.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Valida codi")]
        public event EventHandler ValidaCodi;

        private void txtcodi_Leave(object sender, EventArgs e)
        {
            txtcodi.BackColor = Color.White;

            if (this.ValidaCodi != null)
            {
                this.ValidaCodi(sender, e);
            }
        }

        private void txtcodi_Enter(object sender, EventArgs e)
        {
            txtcodi.BackColor = Color.LightGreen;
        }

    }
}
