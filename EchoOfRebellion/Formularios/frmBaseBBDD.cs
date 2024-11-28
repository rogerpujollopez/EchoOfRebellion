using BiblioModeloDatos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoOfRebellion.Formularios
{
    public partial class frmBaseBBDD : frmBase
    {
        private clsModeloDatos md;
        private DataSet _ds;
        private bool _esNou = false;
        private string _tabla { get; set; }
        private string _querySelect { get; set; }


        public frmBaseBBDD()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
        }

        public string Tabla
        {
            set { _tabla = value; }
        }
        public string Query
        {
            set { _querySelect = value; }
        }

        private void FormatoGrid()
        {
            // Configuración general
            dataGridView1.Font = new Font("Arial", 10, FontStyle.Regular); // Fuente general
            dataGridView1.ForeColor = Color.Black; // Color de letra en negro
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección por fila completa
            dataGridView1.RowHeadersVisible = false; // Ocultar selector de la izquierda
            dataGridView1.AllowUserToAddRows = false; // No permitir añadir filas
            dataGridView1.AllowUserToDeleteRows = false; // No permitir eliminar filas
            dataGridView1.ReadOnly = true; // No permitir editar celdas
            dataGridView1.MultiSelect = false; // No permitir selección múltiple

            // Configuración de estilos para la selección
            DataGridViewCellStyle selectionStyle = new DataGridViewCellStyle
            {
                BackColor = Color.Violet, // Fondo violeta para la fila seleccionada
                ForeColor = Color.White   // Letra blanca para la fila seleccionada
            };
            dataGridView1.DefaultCellStyle.SelectionBackColor = selectionStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionForeColor = selectionStyle.ForeColor;

            // Configuración adicional para mejorar estética (opcional)
            dataGridView1.DefaultCellStyle.BackColor = Color.White; // Fondo blanco para las celdas no seleccionadas
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black; // Texto negro para celdas no seleccionadas
            dataGridView1.GridColor = Color.LightGray; // Color de las líneas del grid
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezados centrados
        }



        private void frmBaseBBDD_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            
            FormatoGrid();

            md = new clsModeloDatos();

            CargarDatosBBDD();
            EstablecerBinding();
        }

        private void CargarDatosBBDD()
        {
            if (_querySelect == "")
            {
                string query = $"select * from {_tabla}";
                _ds = md.PortarPerConsulta(query);
            }
            else
            {
                _ds = md.PortarPerConsulta(_querySelect); 
            }
            dataGridView1.DataSource = _ds.Tables[0];
        }


        private void EstablecerBinding()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt && control.Tag != null) 
                {
                    txt.DataBindings.Clear();
                    txt.DataBindings.Add("Text", _ds.Tables[0], txt.Tag.ToString());
                    txt.Validating += Evento;
                }
                //else if (control is ComboBox cmb)
                //{
                //    cmb.DataBindings.Clear();
                //    cmb.DataBindings.Add("SelectedValue", dsSelect.Tables[0], cmb.Tag.ToString());
                //    cmb.Validating += Evento;
                //}
            }
        }

        private void RemoverBinding(bool borrarCampos)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                {
                    txt.DataBindings.Clear();
                    txt.Validating -= Evento;
                    if (borrarCampos)
                    {
                        txt.Text = "";
                    }
                }
                else if (control is ComboBox cmb)
                {
                    cmb.DataBindings.Clear();
                    cmb.Validating -= Evento;
                }
            }
        }

        private void Evento(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
            //else if (sender is ComboBox cmb)
            //{
            //    cmb.DataBindings[0].BindingManagerBase.EndCurrentEdit();

            //    int id = (int)cmb.SelectedValue;
            //    string camp = cmb.Tag.ToString();

            //    Combo comboRegion = Combos.FirstOrDefault(c => c.id == camp);

            //    if (comboRegion != null)
            //    {
            //        DataRow rowEncontrada = comboRegion.ds.Tables[0].AsEnumerable().FirstOrDefault(row => row.Field<int>(0) == id);
            //        if (rowEncontrada != null)
            //        {
            //            string valor = rowEncontrada[1].ToString();

            //            if (cmb.DataBindings[0].BindingManagerBase.Current is DataRowView currentRowView)
            //            {
            //                currentRowView.Row[comboRegion.columna] = valor;
            //            }
            //        }
            //    }
            //}
        }

        private void _DibujarLabels()
        {
            DataColumn[] primaryKeyColumns = _ds.Tables[0].PrimaryKey;

            foreach (DataColumn col in _ds.Tables[0].Columns)
            {
                Type dataType = col.DataType;

                if (dataType == typeof(string))
                {
                    string columnName = col.ColumnName;

                    foreach (Control control in this.Controls)
                    {
                        if (control is TextBox txt)
                        {
                            if (txt.Tag.ToString() == columnName)
                            {
                                int offset = columnName.Length * 8;

                                Label lbl = new Label()
                                {
                                    Name = "lbl" + columnName,
                                    Text = columnName,
                                    Location = new Point(txt.Location.X - offset, txt.Location.Y + 2),
                                    AutoSize = false,
                                    Width = offset,
                                    Height = 13,
                                    ForeColor = Color.Red,
                                };
                                this.Controls.Add(lbl);
                                lbl.BringToFront();
                            }
                        }
                        else if (control is ComboBox cmb)
                        {
                            if (cmb.Tag.ToString() == columnName)
                            {
                                int offset = columnName.Length * 8;

                                Label lbl = new Label()
                                {
                                    Name = "lbl" + columnName,
                                    Text = columnName,
                                    Location = new Point(cmb.Location.X - offset, cmb.Location.Y + 2),
                                    AutoSize = false,
                                    Width = offset,
                                    Height = 13,
                                    ForeColor = Color.White,
                                };
                                this.Controls.Add(lbl);
                                lbl.BringToFront();
                            }
                        }
                    }
                }
            }
        }

        private void _SituarCamposEnFormulario()
        {
            var grupo = Controls.OfType<Control>().FirstOrDefault(c => c.Name == "GrupCamps");

            int _offset_top = grupo != null ? grupo.Top : 0;
            int _offset_left = grupo != null ? grupo.Left : 0;

            foreach (Control control in Controls)
            {
                if (control is TextBox txt)
                {
                    txt.Top += _offset_top;
                    txt.Left += _offset_left;
                    txt.BringToFront();
                }
                else if (control is ComboBox cmb)
                {
                    cmb.Top += _offset_top;
                    cmb.Left += _offset_left;
                    cmb.BringToFront();
                }
            }
        }

        public void InicializarFormulario()
        {
            _SituarCamposEnFormulario();
            _DibujarLabels();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_esNou)
            {
                DataRow row = _ds.Tables[0].NewRow();

                foreach (Control control in this.Controls)
                {
                    if (control is TextBox txt)
                    {
                        if (!txt.ReadOnly)
                        {
                            row[txt.Tag.ToString()] = txt.Text;
                        }
                    }
                    else if (control is ComboBox cmb)
                    {
                        row[cmb.Tag.ToString()] = cmb.SelectedValue;
                    }
                }
                _ds.Tables[0].Rows.Add(row);
            }

            btnUpdate.Enabled = false;

            int selectedColumnIndex = dataGridView1.CurrentCell?.ColumnIndex ?? -1;
            int selectedRowIndex = dataGridView1.CurrentCell?.RowIndex ?? -1;


            int result = md.Actualitzar(_ds, _querySelect);

            CargarDatosBBDD();

            if (selectedRowIndex != -1 && selectedColumnIndex != -1)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[selectedRowIndex].Cells[selectedColumnIndex];
            }

            btnUpdate.Enabled = true;


            RemoverBinding(false);
            EstablecerBinding();

            _esNou = false;

        }

        private void btnNou_Click(object sender, EventArgs e)
        {
            if (!_esNou)
            {
                RemoverBinding(true);
                _esNou = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
