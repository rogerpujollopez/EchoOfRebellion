using BiblioModeloDatos;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using FormBase;
using MisControles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;
using Utils;

namespace FormUsers
{
    public partial class frmImprimir : frmBase
    {
        private int idUser;

        public frmImprimir(int idUser)
        {
            InitializeComponent();

            this.idUser = idUser;   
        }

        private void frmImprimir_Load(object sender, EventArgs e)
        {
            Top = 100;

            Funcions.Impresoras(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Cerrar()
        {
            Close();
        }

        private void swBotons1_MouseClick(object sender, MouseEventArgs e)
        {
            Exportar("pdf");
        }

        private void Exportar(string formato)
        {
            try
            {
                string fichero = MostrarGuardarDialogoPDF(formato);

                if (fichero == null)
                {
                    return;
                }


                clsModeloDatos dm = new clsModeloDatos();

                string query = @"
                    select UserName,c.DescCategory,r.DescRank,s.DescSpecie,p.DescPlanet,CodeUser,Photo
                    from Users as u left join UserRanks as r on u.idUserRank=r.idUserRank
                    left join UserCategories as c on u.idUserCategory=c.idUserCategory
                    left join Species as s on u.idSpecie=s.idSpecie
                    left join Planets as p on u.idPlanet=p.idPlanet
                    where idUser=@idUser
                ";

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@idUser", idUser));

                DataSet ds = dm.PortarPerConsulta(query, parametros);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"Reports\RptUsuario.rpt");
                cryRpt.SetDataSource(ds);

                PageMargins margins;
                margins = cryRpt.PrintOptions.PageMargins;
                margins.bottomMargin = 0;
                margins.leftMargin = 0;
                margins.rightMargin = 0;
                margins.topMargin = 0;
                cryRpt.PrintOptions.ApplyPageMargins(margins);

                // Configuración de exportación a PDF
                ExportOptions exportOpts = new ExportOptions();
                DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions
                {
                    DiskFileName = fichero
                };

                exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;

                ExportFormatType _formato = ExportFormatType.PortableDocFormat;

                switch (formato)
                {
                    case "doc":
                        _formato = ExportFormatType.WordForWindows;
                        break;
                    case "xls":
                        _formato = ExportFormatType.Excel;
                        break;
                }

                exportOpts.ExportFormatType = _formato;
                exportOpts.DestinationOptions = diskOpts;

                // Exportar el reporte a PDF
                cryRpt.Export(exportOpts);

                if (chkOpen.Checked)
                {
                    AbrirArchivo(fichero);
                }

                Cerrar();
            }
            catch (Exception ex)
            {
                SetLogColor = Color.Red;
                SetLogActivarTimer = true;
                SetLog = ex.Message;
            }
        }


        private void swBotons2_Click(object sender, EventArgs e)
        {
            int copias = 1;

            try
            {
                clsModeloDatos dm = new clsModeloDatos();

                string query = @"
                    select UserName,c.DescCategory,r.DescRank,s.DescSpecie,p.DescPlanet,CodeUser,Photo
                    from Users as u left join UserRanks as r on u.idUserRank=r.idUserRank
                    left join UserCategories as c on u.idUserCategory=c.idUserCategory
                    left join Species as s on u.idSpecie=s.idSpecie
                    left join Planets as p on u.idPlanet=p.idPlanet
                    where idUser=@idUser
                ";

                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@idUser", idUser));

                DataSet ds = dm.PortarPerConsulta(query, parametros);

                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"Reports\RptUsuario.rpt");
                cryRpt.SetDataSource(ds);

                PageMargins margins;
                margins = cryRpt.PrintOptions.PageMargins;
                margins.bottomMargin = 0;
                margins.leftMargin = 0;
                margins.rightMargin = 0;
                margins.topMargin = 0;
                cryRpt.PrintOptions.ApplyPageMargins(margins);

                cryRpt.PrintOptions.PrinterName = comboBox1.SelectedItem?.ToString();
                cryRpt.PrintToPrinter(copias, false, 0, 0);

                Cerrar();
            }
            catch (Exception ex)
            {
                SetLogColor = Color.Red;
                SetLogActivarTimer = true;
                SetLog = ex.Message;
            }
        }

        private string MostrarGuardarDialogoPDF(string formato, string nombrePredeterminado = "user")
        {
            string fichero = nombrePredeterminado;

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Configuración del diálogo para archivos PDF
                switch (formato)
                {
                    case "doc":
                        saveFileDialog.Filter = "Archivos Word|*.doc";
                        nombrePredeterminado += ".doc";
                        saveFileDialog.Title = "Guardar archivo Word"; // Título del cuadro de diálogo
                        saveFileDialog.DefaultExt = "doc"; // Extensión predeterminada
                        break;
                    case "xls":
                        saveFileDialog.Filter = "Archivos Excel|*.xls";
                        nombrePredeterminado += ".xls";
                        saveFileDialog.Title = "Guardar archivo Excel"; // Título del cuadro de diálogo
                        saveFileDialog.DefaultExt = "xls"; // Extensión predeterminada
                        break;
                    default:
                        saveFileDialog.Filter = "Archivos PDF|*.pdf";
                        nombrePredeterminado += ".pdf";
                        saveFileDialog.Title = "Guardar archivo PDF"; // Título del cuadro de diálogo
                        saveFileDialog.DefaultExt = "pdf"; // Extensión predeterminada
                        break;
                }
                saveFileDialog.FileName = nombrePredeterminado; // Nombre predeterminado del archivo
                saveFileDialog.OverwritePrompt = true; // Solicitar confirmación al sobrescribir

                // Mostrar el cuadro de diálogo
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return saveFileDialog.FileName; // Devuelve la ruta seleccionada
                }
            }

            return null; // El usuario canceló el cuadro de diálogo
        }

        private void AbrirArchivo(string rutaArchivo)
        {
            try
            {
                // Verificar si el archivo existe
                if (System.IO.File.Exists(rutaArchivo))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = rutaArchivo,
                        UseShellExecute = true // Abre con el programa predeterminado
                    });
                }
                else
                {
                    MessageBox.Show("El archivo no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void swBotons3_MouseClick(object sender, MouseEventArgs e)
        {
            Exportar("doc");
        }

        private void swBotons4_MouseClick(object sender, MouseEventArgs e)
        {
            Exportar("xls");
        }
    }
}
