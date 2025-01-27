using FormBaseBBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPlanetes
{
    public partial class frmManteniment_Planetes : frmBaseBBDD
    {
        public frmManteniment_Planetes()
        {
            InitializeComponent();

            string tabla = "Planetes";

            Data data = new Data()
            {
                autoLabel = true,
                taule = "Planetes",
                querySelect = @"SELECT pl.idPlanet, pl.CodePlanet, pl.DescPlanet, pl.idSector, se.DescSector, pl.long, pl.lat, pl.parsecs, pl.idNatives, sp.DescSpecie, pl.idFiliation, fi.DescFiliations, pl.PlanetPicture, pl.IPPlanet, pl.PortPlanet, pl.PortPlanet1 FROM Planets AS pl LEFT JOIN Sectors AS se ON pl.idSector = se.idSector LEFT JOIN Species AS sp ON pl.idNatives = sp.idSpecie LEFT JOIN Filiations AS fi ON pl.idFiliation = fi.idFiliation",
                queryUpdate = @"SELECT idPlanet, CodePlanet, DescPlanet, idSector, long, lat, parsecs, idNatives, idFiliation, PlanetPicture, IPPlanet, PortPlanet, PortPlanet1 FROM Planets",
                id = "idPlanet",
                titol = $"Mantenimiento tabla '{tabla}'"
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella() { nom = "id", ample = 120 , visible = false, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "Code Planet", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "Desc Planet", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "id", ample = 120 , visible = false, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "Desc Sector", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "long", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "lat", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "parsecs", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "id", ample = 120 , visible = false, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "Desc Specie", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "id", ample = 120 , visible = false, alineacio = CasellaAlineacio.Centrat},
                new casella() { nom = "Desc Filiations", ample = 120 , visible = true, alineacio = CasellaAlineacio.Centrat},
            };

            SetLlistes = new List<llista>()
            {
               new llista() { id="idSector", query="SELECT idSector,CodeSector,DescSector FROM Sectors ORDER BY DescSector"},
               new llista() { id="idNatives", query="SELECT idSpecie,CodeSpecie,DescSpecie FROM Species ORDER BY DescSpecie"},
               new llista() { id="idFiliation", query="SELECT idFiliation,CodeFiliation,DescFiliations FROM Filiations ORDER BY DescFiliations"},
            };

            campsNoVuits = new List<string>()
            {
                "CodePlanet","DescPlanet","idSector","idNatives","idFiliation"
            };

        }

        private void frmManteniment_Planetes_Load(object sender, EventArgs e)
        {
            InicializarFormulario(this);

            // Suscribirse al evento TextChanged de textBox6
            textBox6.TextChanged += TextBox6_TextChanged;

            // Suscribirse al Binding.Format si el binding existe
            var binding = textBox6.DataBindings["Text"];
            if (binding != null)
            {
                binding.Format += Binding_Format;
            }
            ActualizarImagen();
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {
            // Cargar la imagen desde la URL en el PictureBox
            ActualizarImagen();
        }

        private void Binding_Format(object sender, ConvertEventArgs e)
        {
            // Si el binding actualiza el valor, cargamos la imagen
            ActualizarImagen();
        }

        private void ActualizarImagen()
        {
            try
            {
                string url = textBox6.Text;

                if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    // Cargar la imagen desde la URL
                    using (var webClient = new System.Net.WebClient())
                    {
                        byte[] imageData = webClient.DownloadData(url);
                        using (var ms = new System.IO.MemoryStream(imageData))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    // Si no es una URL válida, limpiamos el PictureBox
                    pictureBox1.Image = null;
                }
            }
            catch
            {
                // Si hay algún error (URL inválida o la imagen no se puede cargar), limpiar la imagen
                pictureBox1.Image = null;
            }
        }
    }
}
