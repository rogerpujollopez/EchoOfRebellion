using FormBaseBBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUsers
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
                new casella() { visible = false},
                new casella() { ample = 180, visible = true, alineacio = CasellaAlineacio.Centrat},
                new casella() { ample = 180, visible = true},
            };
            campsNoVuits = new List<string>()
            {
                "CodeCategory","DescCategory","AccessLevel"
            };

        }

        private void frmManteniment_UserCategories_Load(object sender, EventArgs e)
        {
            InicializarFormulario(this);
        }
    }
}
