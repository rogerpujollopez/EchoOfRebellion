using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;
using static MisControles.SWCodi;

namespace MisControles
{
    public class SWTextbox : TextBox
    {
        private TipusDada tipus;

        public enum TipusDada
        {
            [Description("Número")]
            Numero = 0,
            [Description("Text")]
            Text = 1,
            [Description("Codi")]
            Codi = 2,
            [Description("IP Rang")]
            IP = 3,
        }

        [Browsable(true)]
        [Category("Personalización")]
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

        private void SWTextbox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGreen;
        }

        private void SWTextbox_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;

            //if (this.ValidaCodi != null)
            //{
            //    this.ValidaCodi(sender, e);
            //}
        }

        private void SWTextbox_Validating(object sender, CancelEventArgs e)
        {
            switch(tipus)
            {
                case TipusDada.Text:
                    e.Cancel = !EsText(this.Text);
                    break;
                case TipusDada.Numero:
                    e.Cancel = !EsNumero(this.Text);
                    break;
                case TipusDada.Codi:
                    e.Cancel = !EsCodi(this.Text);
                    break;
                case TipusDada.IP:
                    e.Cancel = !EsIPRang(this.Text);
                    break;
            }
        }

        // Funciones

        public static bool EsText(string texto)
        {
            return !string.IsNullOrEmpty(texto) && texto.All(char.IsLetter);
        }

        public static bool EsNumero(string texto)
        {
            return !string.IsNullOrEmpty(texto) && texto.All(char.IsDigit);
        }

        public static bool EsCodi(string texto)
        {
            bool esCodi;

            string patro = @"^[^AEIOU]{4}-\d{3}/[13579]{1}[AEIOU]{1}$";

            esCodi = Regex.IsMatch(texto, patro);

            return esCodi;
        }

        public static bool EsIPRang(string texto)
        {
            bool esCodi;

            string patro = @"^192.168.([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).([1-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-4])$";

            esCodi = Regex.IsMatch(texto, patro);

            return esCodi;
        }

    }
}
