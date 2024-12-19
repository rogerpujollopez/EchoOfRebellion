using BiblioModeloDatos;
using FormBase;
using MisControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace FormBaseBBDD
{
    public partial class frmBaseBBDD : frmBase
    {
        protected class Data
        {
            public string taule { get; set; }
            public string querySelect { get; set; }
            public string queryUpdate { get; set; }
            public string id { get; set; }
            public bool autoLabel { get; set; }
            public string titol { get; set; }
        }

        private clsModeloDatos md;
        private DataSet _ds;
        private bool _esNou = false;
        private string _tabla { get; set; }
        private string _querySelect { get; set; }
        private string _queryUpdate { get; set; }
        private string _id { get; set; }
        private bool _autoLabel { get; set; }

        public Color _color { get; set; } = Color.Red;

        private List<casella> caselles;
        private List<llista> llistes;
        private List<string> nomsCampsPhoto;

        public frmBaseBBDD()
        {
            InitializeComponent();
            dataGridView1.RowHeadersVisible = false;
        }

        protected Data SetData
        {
            set
            {
                Data data = value;

                _tabla = data.taule;
                _querySelect = data.querySelect;
                _queryUpdate = data.queryUpdate;
                _id = data.id;
                _autoLabel = data.autoLabel;
                Titulo = data.titol;
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



        private void frmBaseBBDD_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            
            dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);

            FormatoGrid();

            nomsCampsPhoto = new List<string>();

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pb && control.Tag != null)
                {
                    nomsCampsPhoto.Add(pb.Tag.ToString());
                }
            }

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
            DibujarGrid();

            OmplirSWCodi();

        }

        private void OmplirSWCodi()
        {
            if (llistes != null && llistes.Count > 0)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is SWCodi txt && control.Tag != null)
                    {
                        string id = txt.Tag.ToString();

                        foreach (llista lis in llistes)
                        {
                            if (lis.id == id)
                            {
                                txt.Origen = md.PortarPerConsulta(lis.query);
                                // Co
                                break;
                            }
                        }
                    }
                }
            }
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
                else if (control is ComboBox cmb)
                {
                    cmb.DataBindings.Clear();
                    cmb.DataBindings.Add("SelectedValue", _ds.Tables[0], cmb.Tag.ToString());
                    cmb.Validating += Evento;
                }
                else if (control is SWCodi cd)
                {
                    cd.DataBindings.Clear();
                    cd.DataBindings.Add("TextId", _ds.Tables[0], cd.Tag.ToString());
                    if (cd.Tag2 != "")
                    {
                        cd.DataBindings.Add("TextValue", _ds.Tables[0], cd.Tag2); // "CodeSector"
                    }
                    if (cd.Tag3 != "")
                    {
                        cd.DataBindings.Add("TextDesc", _ds.Tables[0], cd.Tag3); // "DescRegion"
                    }
                    cd.Validating += Evento;
                }
                else if (control is PictureBox pb)
                {
                    pb.DataBindings.Clear();
                    pb.DataBindings.Add("Image", _ds.Tables[0], pb.Tag.ToString(), true, DataSourceUpdateMode.Never);
                    pb.DataBindings[pb.DataBindings.Count - 1].Format += (s, e) =>
                    {
                        // Convertir el byte[] en una imagen
                        if (e.Value is byte[] byteArray)
                        {
                            using (var ms = new MemoryStream(byteArray))
                            {
                                e.Value = Image.FromStream(ms);
                            }
                        }
                        else
                        {
                            //e.Value = null; // Si el valor no es byte[], no se muestra nada
                            e.Value = Properties.Resources.SinFoto;
                        }
                    };
                }
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
                else if (control is SWCodi cd)
                {
                    cd.DataBindings.Clear();
                    cd.Validating -= Evento;
                }
                else if (control is PictureBox pb)
                {
                    pb.DataBindings.Clear();
                }
            }
        }

        private void Evento(object sender, EventArgs e)
        {
            if (sender is TextBox txt)
            {
                txt.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
            else if (sender is SWCodi cd)
            {
                cd.DataBindings[0].BindingManagerBase.EndCurrentEdit();
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
            foreach (DataColumn col in _ds.Tables[0].Columns)
            {
                Type dataType = col.DataType;

                if (dataType == typeof(string) || dataType == typeof(int))
                {
                    string columnName = col.ColumnName;

                    foreach (Control control in this.Controls)
                    {
                        if (control is TextBox txt)
                        {
                            if (txt.Tag.ToString() == columnName && !txt.ReadOnly)
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
                                    ForeColor = _color,
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
                                    ForeColor = _color,
                                };
                                this.Controls.Add(lbl);
                                lbl.BringToFront();
                            }
                        }
                        else if (control is SWCodi cd)
                        {
                            if (cd.Tag.ToString() == columnName)
                            {
                                int offset = columnName.Length * 8;

                                Label lbl = new Label()
                                {
                                    Name = "lbl" + columnName,
                                    Text = columnName,
                                    Location = new Point(cd.Location.X - offset, cd.Location.Y + 2),
                                    AutoSize = false,
                                    Width = offset,
                                    Height = 13,
                                    ForeColor = _color,
                                };
                                this.Controls.Add(lbl);
                                lbl.BringToFront();
                            }
                        }
                        else if (control is PictureBox pic)
                        {
                            pic.BorderStyle = BorderStyle.None;

                            pic.Paint += (sender, e) =>
                            {
                                using (var pen = new Pen(_color, 2)) 
                                {
                                    e.Graphics.DrawRectangle(pen, 0, 0, pic.Width, pic.Height);
                                }
                            };

                            pic.Refresh();

                            if (pic.Tag.ToString() == columnName)
                            {
                                int offset = columnName.Length * 8;

                                Label lbl = new Label()
                                {
                                    Name = "lbl" + columnName,
                                    Text = columnName,
                                    Location = new Point(pic.Location.X - offset, pic.Location.Y + 2),
                                    AutoSize = false,
                                    Width = offset,
                                    Height = 13,
                                    ForeColor = _color,
                                };
                                this.Controls.Add(lbl);
                                lbl.BringToFront();
                            }
                        }
                    }
                }
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
                    if (txt.Tag.ToString() == _id)
                    {
                        txt.Top = 0;
                        txt.Left = 0;
                        txt.Enabled = false;
                        _listBack.Add(control);
                    }
                    else
                    {
                        txt.Top += _offset_top;
                        txt.Left += _offset_left;
                        _listFront.Add(control);
                    }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_esNou)
            {
                DataRow row = _ds.Tables[0].NewRow();

                foreach (Control control in this.Controls)
                {
                    if (control is TextBox txt)
                    {
                        if (txt.Enabled)
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


            int result = md.Actualitzar(_ds, _queryUpdate);

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
            int? valor = null;

            // Esto obtiene las filas que no están eliminadas.
            DataRow[] activeRows = _ds.Tables[0].Select(null, null, DataViewRowState.CurrentRows);

            if (activeRows.Length == 0)
            {
                return;
            }

            foreach (Control control in this.Controls)
            {
                if (control is TextBox txt)
                {
                    if (txt.Tag.ToString() == _id)
                    {
                        valor = Convert.ToInt32(txt.Text);
                        break;
                    }
                }
            }

            if (valor == null)
            {
                return;
            }

            foreach (DataRow row in activeRows)
            {
                int _idTmp = (int)row[_id];
                if (valor == _idTmp)
                {
                    row.Delete();
                    break;
                }
            }

        }


        #region "Resize tamaño vertical"
        private void dataGridView1_CellFormattingResizeVertical(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (nomsCampsPhoto.Contains(dataGridView1.Columns[e.ColumnIndex].Name, StringComparer.OrdinalIgnoreCase))
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    using (var ms = new MemoryStream())
                    {
                        Properties.Resources.SinFoto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        e.Value = ms.ToArray();
                    }
                }

                byte[] byteArray = (byte[])e.Value;

                using (var ms = new MemoryStream(byteArray))
                {
                    Image originalImage = Image.FromStream(ms);

                    // Ajustar el tamaño de la imagen al ancho de la columna
                    int columnWidth = dataGridView1.Columns[e.ColumnIndex].Width;
                    int cellHeight = dataGridView1.Rows[e.RowIndex].Height;

                    // Redimensionar y centrar la imagen verticalmente
                    e.Value = ResizeAndCenterImage(originalImage, columnWidth, cellHeight);
                    e.FormattingApplied = true;
                }
            }
        }

        private Image ResizeAndCenterImage(Image image, int cellWidth, int cellHeight)
        {
            float aspectRatio = (float)image.Width / image.Height;

            // Calcular el tamaño de la imagen dentro de la celda
            int imgWidth = cellWidth;
            int imgHeight = (int)(cellWidth / aspectRatio);

            if (imgHeight > cellHeight)
            {
                imgHeight = cellHeight;
                imgWidth = (int)(cellHeight * aspectRatio);
            }

            // Crear una nueva imagen que incluya el centrado vertical
            var centeredImage = new Bitmap(cellWidth, cellHeight);
            using (var graphics = Graphics.FromImage(centeredImage))
            {
                graphics.Clear(Color.Transparent);
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Calcular la posición para centrar la imagen
                int x = (cellWidth - imgWidth) / 2;
                int y = (cellHeight - imgHeight) / 2;

                graphics.DrawImage(image, new Rectangle(x, y, imgWidth, imgHeight));
            }

            return centeredImage;
        }

        #endregion

        #region "Resize tamaño celda horizontal"

        /// <summary>
        /// Resize al ancho de la celda
        /// </summary>
        /// <param name="image"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Image ResizeImage(Image image, int width, int height)
        {
            var resizedImage = new Bitmap(width, height);
            using (var graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        /// <summary>
        /// Evento Resize al ancho de la celda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // nomsCampsPhoto


            if (nomsCampsPhoto.Contains(dataGridView1.Columns[e.ColumnIndex].Name, StringComparer.OrdinalIgnoreCase))
            {
                if (e.Value == null || e.Value == DBNull.Value)
                {
                    using (var ms = new MemoryStream())
                    {
                        Properties.Resources.SinFoto.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        e.Value = ms.ToArray();
                    }
                }

                byte[] byteArray = (byte[])e.Value;

                using (var ms = new MemoryStream(byteArray))
                {
                    Image originalImage = Image.FromStream(ms);

                    // Ajustar el tamaño de la imagen al ancho de la columna
                    int columnWidth = dataGridView1.Columns[e.ColumnIndex].Width;
                    e.Value = ResizeImage(originalImage, columnWidth, originalImage.Height * columnWidth / originalImage.Width);
                }
                e.FormattingApplied = true;
            }
        }

        #endregion
    }

    public enum CasellaAlineacio
    {
        Esquerra,
        Centrat,
        Dreta
    }

    public class casella
    {
        public string nom { get; set; }
        public int ample { get; set; }
        public bool visible { get; set; }
        public CasellaAlineacio alineacio { get; set; }
    }

    public class llista
    {
        public string query { get; set; }
        public string id { get; set; }
    }
}
