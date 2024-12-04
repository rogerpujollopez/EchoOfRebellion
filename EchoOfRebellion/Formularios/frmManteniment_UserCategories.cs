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

namespace EchoOfRebellion.Formularios
{
    public partial class frmManteniment_UserCategories : frmBaseBBDD
    {
        public frmManteniment_UserCategories()
        {
            InitializeComponent();

            string tabla = "UserCategories";

            Data data = new Data()
            {
                autoLabel = true,
                taule = tabla,
                querySelect = @"select idUserCategory,CodeCategory,DescCategory,AccessLevel from UserCategories",
                queryUpdate = @"select idUserCategory,CodeCategory,DescCategory,AccessLevel from UserCategories",
                id = "idUserCategory",
                titol = $"Mantenimiento tabla '{tabla}'"
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella(){ nom="id", ample=100 , visible=true, alineacio=CasellaAlineacio.Centrat},
                new casella() { nom ="name", ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { nom="name2", ample=300, visible = true},
            };
        }

        private void frmManteniment_UserCategories_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            InicializarFormulario();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
