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
        private int numCols;
        private List<int> _viewDataColumns;
        public SWCodi()
        {
            InitializeComponent();
        }

        public DataSet Origen
        {
            set { 
                ds = value;
                numCols = 0;
                if (ds != null && ds.Tables[0].Rows.Count > 0) {
                    numCols = ds.Tables[0].Rows.Count;
                }
            }
            get
            {
                return ds;
            }
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
        [Description("Tag2")]
        public string Tag2 { get; set; }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Tag3")]
        public string Tag3 { get; set; }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Text id")]
        public string TextId
        {
            get
            {
                return txtId.Text;
            }
            set
            {
                txtId.Text = value;
                ActualitzarLabelDesdeTextId();
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Columnes a mostrar")]
        public List<int> ViewDataColumns
        {
            set { _viewDataColumns = value; }
        }

        private void ActualitzarLabelDesdeTextId()
        {
            int result = int.TryParse(txtId.Text, out var temp) ? temp : -1;

            if (ds != null && result >= 0)
            {

                int id;

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    id = (int)row[0];

                    if (id == result)
                    {
                        txtcodi.Text = row[1].ToString();
                        txtLabel.Text = row[2].ToString();
                        break;
                    }
                }
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
                ActualitzarLabelDesdeTextValue();
            }
        }

        private void ActualitzarLabelDesdeTextValue()
        {
            string _codi = txtcodi.Text;

            if (ds != null && _codi != "") {
                
                foreach (DataRow row in ds.Tables[0].Rows) {
                    if (_codi == row[1].ToString()) {
                        txtId.Text = row[0].ToString();
                        txtLabel.Text = row[2].ToString();
                        break;
                    }
                }
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Text descripció")]
        public string TextDesc
        {
            get
            {
                return txtLabel.Text;
            }
            set
            {
                txtLabel.Text = value;
                //ActualitzarLabelDesdeTextValue();
            }
        }

        private void txtcodi_Leave(object sender, EventArgs e)
        {
            txtcodi.BackColor = colorLeave;
        }

        private void txtcodi_Enter(object sender, EventArgs e)
        {
            txtcodi.BackColor = colorEnter;
            txtcodi.Select(0, txtcodi.Text.Length);
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
                string texto = "";

                if (_viewDataColumns != null && _viewDataColumns.Count > 0)
                {
                    string cadena = "";

                    for (int i = 0; i < _viewDataColumns.Count; i++)
                    {
                        if (cadena != "")
                        {
                            cadena += " - ";
                        }
                        cadena += row[_viewDataColumns[i]].ToString();
                    }
                    texto = cadena;
                }
                else
                {
                    texto = row[1].ToString();
                }

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
                    txtId.Text = id.ToString();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (id == (int)row[0])
                        {
                            txtcodi.Text = row[1].ToString();
                            txtLabel.Text=row[2].ToString();   
                        }
                    }
                    frm.Close();
                }
            };

            frm.Controls.Add(listBox);



            frm.ShowDialog();

        }

        private void txtcodi_Validating(object sender, CancelEventArgs e)
        {
            int _id = 0;
            string _codi = "";
            string _desc = "";

            if (txtcodi.Text == "")
            {
                txtId.Text = _id.ToString();
                txtcodi.Text = _codi;
                txtLabel.Text = _desc;
                return;
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (txtcodi.Text == row[1].ToString())
                {
                    _id = (int)row[0];
                    _codi = row[1].ToString();
                    _desc = row[2].ToString();
                }
            }

            if (_codi == "" && _desc == "" && _id == 0)
            {
                e.Cancel = true;
            }

            txtId.Text = _id.ToString();
            txtcodi.Text = _codi;
            txtLabel.Text = _desc;
        }
    }
}
