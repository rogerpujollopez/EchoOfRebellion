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

namespace FormUsers
{
    public partial class frmManteniment_UserRangs : frmBaseBBDD
    {
        public frmManteniment_UserRangs()
        {
            InitializeComponent();

            string tabla = "UserRanks";

            Data data = new Data()
            {
                autoLabel = true,
                taule = tabla,
                querySelect = @"select idUserRank,CodeRank,DescRank from UserRanks",
                queryUpdate = @"select idUserRank,CodeRank,DescRank from UserRanks",
                id = "idUserRank",
                titol = $"Mantenimiento tabla '{tabla}'"
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella(){ nom="id", ample=100 , visible=false, alineacio=CasellaAlineacio.Centrat},
                new casella() { nom ="CodeRank", ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { nom="DescRank", ample=300, visible = true},
            };
        }

        private void frmManteniment_UserRangs_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            InicializarFormulario();

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}