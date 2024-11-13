using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace MisControles
{
    public class SWTextbox : TextBox
    {
        private TipusDada tipus;
        private string patro;
        private Color colorFocus;
        private Color colorSenseFocus;
        private Color colorAmbError;
        private bool hayError;

        public enum TipusDada
        {
            [Description("Sense")]
            Sense = 0,
            [Description("Número")]
            Numero = 1,
            [Description("Text")]
            Text = 2,
            [Description("Codi")]
            Codi = 3,
            [Description("IP Rang")]
            IP = 4,
            [Description("Personalitzat")]
            Personalitzat = 5,
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Nivell")]
        public TipusDada Tipus
        {
            get { return tipus; }
            set { tipus = value; }
        }

        public SWTextbox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SWTextbox
            // 
            this.Enter += new System.EventHandler(this.SWTextbox_Enter);
            this.Leave += new System.EventHandler(this.SWTextbox_Leave);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.SWTextbox_Validating);
            this.ResumeLayout(false);

        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Color de fons quan te el focus")]
        public Color BackColorGetFocus
        {
            get
            {
                return colorFocus;
            }
            set
            {
                colorFocus = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Color de fons quan perd el focus")]
        public Color BackColorLostFocus
        {
            get
            {
                return colorSenseFocus;
            }
            set
            {
                colorSenseFocus = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Color de fons quan no valida")]
        public Color BackColorError
        {
            get
            {
                return colorAmbError;
            }
            set
            {
                colorAmbError = value;
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Patró regex")]
        public string Patro
        {
            get { return patro; }
            set { patro = value; }
        }

        private void SWTextbox_Enter(object sender, EventArgs e)
        {
            //this.BackColor = Color.LightGreen;
            if (hayError)
            {
                BackColor = colorAmbError;
            }
            else
            {
                SetColorActivado();
            }
        }

        private void SWTextbox_Leave(object sender, EventArgs e)
        {
            //this.BackColor = Color.White;
            if (hayError)
            {
                SetColorError();
            }
            else
            {
                SetColorDessctivado();
            }

            //if (this.ValidaCodi != null)
            //{
            //    this.ValidaCodi(sender, e);
            //}
        }

        private void SWTextbox_Validating(object sender, CancelEventArgs e)
        {
            switch (tipus)
            {
                case TipusDada.Text:
                    hayError = !EsText(Text);
                    break;
                case TipusDada.Numero:
                    hayError = !EsNumero(Text);
                    break;
                case TipusDada.Codi:
                    hayError = !EsCodi(Text);
                    break;
                case TipusDada.IP:
                    hayError = !EsIPRang(Text);
                    break;
                case TipusDada.Personalitzat:
                    hayError = !EsPatroPersonalitzat(Text);
                    break;
                default:
                    hayError = false;
                    break;
            }
            SetColorError();
        }

        private void SetColorActivado()
        {
            BackColor = colorFocus;
        }

        private void SetColorDessctivado()
        {
            BackColor = colorSenseFocus;
        }

        private void SetColorError()
        {
            if (hayError)
            {
                BackColor = colorAmbError;
            }
            else
            {
                SetColorDessctivado();
            }
        }

        // Funciones

        public bool EsText(string texto)
        {
            return !string.IsNullOrEmpty(texto) && texto.All(char.IsLetter);
        }

        public bool EsNumero(string texto)
        {
            return !string.IsNullOrEmpty(texto) && texto.All(char.IsDigit);
        }

        public bool EsCodi(string texto)
        {
            bool esCodi;

            string _patro = @"^[^AEIOU]{4}-\d{3}/[13579]{1}[AEIOU]{1}$";

            esCodi = Regex.IsMatch(texto, _patro);

            return esCodi;
        }

        public bool EsIPRang(string texto)
        {
            bool esCodi;

            string _patro = @"^192.168.([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).([1-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-4])$";

            esCodi = Regex.IsMatch(texto, _patro);

            return esCodi;
        }

        public bool EsPatroPersonalitzat(string texto)
        {
            bool esCodi;

            string _patro = patro;

            esCodi = Regex.IsMatch(texto, _patro);

            return esCodi;
        }

    }
}
