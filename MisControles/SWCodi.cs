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
        private DataSet ds = null;
        private Color colorLeave = Color.White;
        private Color colorEnter = Color.Green;

        public SWCodi()
        {
            InitializeComponent();
        }

        public DataSet Origen
        {
            set { ds = value; }
        }

        //[Browsable(true)]
        //[Category("Personalizació")]
        //[Description("Text label")]
        //public string TextLabel
        //{
        //    get
        //    {
        //        return txtLabel.Text;
        //    }
        //    set
        //    {
        //        txtLabel.Text = value;
        //    }
        //}

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
                ActualitzarLabel();
            }
        }

        private void ActualitzarLabel()
        {
            int result = int.TryParse(txtcodi.Text, out var temp) ? temp : -1;

            if (ds != null && result >= 0) {
                
                int id;

                foreach (DataRow row in ds.Tables[0].Rows) {
                    id = (int)row[0];

                    if (id == result) { 
                        string valor = (string)row[1];
                        txtLabel.Text = valor;
                        break;
                    }
                }
            }
        }

        private void txtcodi_Leave(object sender, EventArgs e)
        {
            txtcodi.BackColor = colorLeave;
        }

        private void txtcodi_Enter(object sender, EventArgs e)
        {
            txtcodi.BackColor = colorEnter;
        }

        private void txtLabel_MouseClick(object sender, MouseEventArgs e)
        {
            int offsetT, offsetL;
            int ample;

            TextBox control = sender as TextBox;
            ample = control.Width;
            Point p = control.Parent.Location;
            offsetL = p.Y;
            offsetT = p.X + control.Location.X;
            p = control.Parent.Parent.Location;
            offsetL += p.Y;
            offsetT += p.X;

            p = new Point(offsetT, offsetL);

            Form frm = new Form()
            {
                Size = new Size(ample, 100),
                FormBorderStyle = FormBorderStyle.None,
                StartPosition= FormStartPosition.Manual,
                Location = p
            };
            ListBox listBox = new ListBox();
            listBox.Location = new Point(0, 0);
            listBox.Size = new Size(ample, 100);

            foreach (DataRow row in ds.Tables[0].Rows) 
            {
                int id = (int)row[0];
                string texto = row[1].ToString();
                listBox.Items.Add(new KeyValuePair<int, string>(id, texto));
            }
            listBox.DisplayMember = "Value";
            listBox.ValueMember = "Key";

            //listBox.Click += (_sender, _e) =>
            //{
            //    frm.Close();
            //};

            listBox.SelectedIndexChanged += (_sender, _e) =>
            {
                if (listBox.SelectedItem is KeyValuePair<int, string> selectedPair)
                {
                    int id = selectedPair.Key;
                    string texto = selectedPair.Value;
                    txtcodi.Text = id.ToString();
                    txtLabel.Text = texto;
                    frm.Close();
                }
            };

            frm.Controls.Add(listBox);



            frm.ShowDialog();

        }
    }
}
