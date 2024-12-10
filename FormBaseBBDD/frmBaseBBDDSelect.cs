using BiblioModeloDatos;
using FormBase;
using MisControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Utils;

namespace FormBaseBBDD
{
    public partial class frmBaseBBDDSelect : frmBase
    {
        private Timer timer;

        protected class Data
        {
            public string querySelect { get; set; }
            public bool autoLabel { get; set; }
            public string titol { get; set; }
            public string queryOrder { get; set; }
        }

        private clsModeloDatos md;
        private DataSet _ds;
        private string _querySelect { get; set; }
        private string _queryOrder { get; set; }
        private bool _autoLabel { get; set; }

        public Color _color { get; set; } = Color.Red;

        private List<casella> caselles;
        private List<llista> llistes;

        public frmBaseBBDDSelect()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += Timer_Tick;
        }

        protected void InicializarTimerTeclado()
        {
            timer.Stop();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            ConstriurSQL();
            //ActualizarGrid();
        }

        private void ConstriurSQL()
        {
            List<string> camps = new List<string>();

            string strsql = _querySelect;
            int contador = 0;

            string valor, strwhr;
            string[] parts;
            bool flag = false;

            strwhr = "";

            List<SqlParameter> parametros = new List<SqlParameter>();

            foreach (Control control in Controls)
            {
                if (control is TextBox txt)
                {
                    if (!string.IsNullOrWhiteSpace(txt.Text))
                    {
                        if (strwhr == "")
                        {
                            strwhr = " where ";
                        }
                        valor = txt.Text;
                        parts = txt.Tag.ToString().Split(',');
                        strwhr += "(";

                        foreach (string part in parts)
                        {
                            if (flag)
                            {
                                strwhr += " or ";
                            }
                            strwhr += part + $" LIKE '%' + @param{contador} + '%' ";
                            flag = true;
                        }
                        strwhr += ")";

                        parametros.Add(new SqlParameter("@param" + contador, SqlDbType.NVarChar) { Value = valor });
                        contador++;

                    }
                }
            }

            CargarDatosBBDD(parametros, strwhr);
        }



        protected Data SetData
        {
            set
            {
                Data data = value;

                _querySelect = data.querySelect;
                _autoLabel = data.autoLabel;
                Titulo = data.titol;
                _queryOrder = data.queryOrder;
            }
        }

        public List<casella> SetCaselles
        {
            set { caselles = value; }
        }

        public List<llista> SetLlistes
        {
            set { llistes = value; }
        }

        private void FormatoGrid()
        {
            Formats.Grids.FormatoGrid(dataGridView1);
        }

        private void frmBaseBBDDSelect_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            FormatoGrid();

            md = new clsModeloDatos();

            CargarDatosBBDD();
        }

        private void CargarDatosBBDD(List<SqlParameter> parametres = null, string strwhr = "")
        {
            string _query = _querySelect + strwhr + " " + _queryOrder;

            _ds = md.PortarPerConsulta(_query, parametres);
            dataGridView1.DataSource = _ds.Tables[0];
            DibujarGrid();

            //OmplirSWCodi();

        }

        private void DibujarGrid()
        {
            if (caselles == null || caselles.Count == 0)
            {
                return;
            }

            bool NoOrdenable = false;

            int numCols = dataGridView1.ColumnCount;
            int numInfo = caselles.Count;

            int pos = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (NoOrdenable) column.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (pos < numInfo)
                {
                    int _ample = caselles[pos].ample;
                    bool _visible = caselles[pos].visible;
                    CasellaAlineacio _alineacio = caselles[pos].alineacio;
                    string _nom = caselles[pos].nom == null ? column.HeaderText.Capitalize() : caselles[pos].nom;

                    column.Visible = _visible;
                    column.Width = _ample;
                    column.HeaderText = _nom;

                    switch (_alineacio)
                    {
                        case CasellaAlineacio.Centrat: // center
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            break;
                        case CasellaAlineacio.Dreta: // right
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                            break;
                        default: // CasellaAlineacio.Esquerra
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                            break;
                    }

                    Type tipoDeDato = column.ValueType;

                    if (tipoDeDato == typeof(string))
                    {
                        // La columna es de tipo string
                    }
                    else if (tipoDeDato == typeof(decimal) || tipoDeDato == typeof(double) || tipoDeDato == typeof(float))
                    {
                        // La columna es de tipo decimal
                        column.DefaultCellStyle.Format = "N2";
                    }
                    else if (tipoDeDato == typeof(int))
                    {
                        // La columna es de tipo entero (int)
                    }


                }
                pos += 1;
            }

        }

        private void _SituarCamposEnFormulario(int offset_top = 0, int offset_left = 0)
        {
            var grupo = Controls.OfType<Control>().FirstOrDefault(c => c.Name == "GrupCamps");

            int _offset_top = grupo != null ? grupo.Top : 0;
            int _offset_left = grupo != null ? grupo.Left : 0;

            _offset_top += offset_top;
            _offset_left += offset_left;

            List<Control> _listFront = new List<Control>();
            List<Control> _listBack = new List<Control>();

            foreach (Control control in Controls)
            {
                if (control is TextBox txt)
                {
                    txt.Top += _offset_top;
                    txt.Left += _offset_left;
                    _listFront.Add(control);
                }
                else if (control is ComboBox cmb)
                {
                    cmb.Top += _offset_top;
                    cmb.Left += _offset_left;
                    _listFront.Add(control);
                }
                else if (control is SWCodi cd)
                {
                    cd.Top += _offset_top;
                    cd.Left += _offset_left;
                    _listFront.Add(control);
                }
                else if (control is PictureBox pic)
                {
                    pic.Top += _offset_top;
                    pic.Left += _offset_left;
                }
            }

            foreach (Control control in _listFront)
            {
                control.BringToFront();
            }
            foreach (Control control in _listBack)
            {
                control.SendToBack();
            }
        }

        public void InicializarFormulario(int offset_top = 0, int offset_left = 0)
        {
            _SituarCamposEnFormulario(offset_top, offset_left);
            if (_autoLabel)
            {
                _DibujarLabels();
            }
        }

        private void _DibujarLabels()
        {
            int contador = 0;

            List<Control> list = new List<Control>();   

            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                {
                    if (txt.Tag.ToString() != "") 
                    {
                        int offset_y = -20;
                        string buscarPer = "Buscar per ";

                        string[] parts = txt.Tag.ToString().Split(',');
                        bool flag = false;

                        foreach (string part in parts)
                        {
                            if (flag)
                            {
                                buscarPer += ", ";
                            }
                            buscarPer += part;
                            flag = true;
                        }

                        Label lbl = new Label()
                        {
                            Name = "lbl" + contador,
                            Text = buscarPer,
                            Location = new Point(txt.Location.X, txt.Location.Y + offset_y),
                            AutoSize = true,
                            ForeColor = _color,
                        };
                        this.Controls.Add(lbl);
                        list.Add(lbl);

                        txt.Width = lbl.Width;

                        contador++;
                    }
                }
            }

            foreach(Control control in list)
            {
                control.BringToFront();
            }
        }


    }
}
