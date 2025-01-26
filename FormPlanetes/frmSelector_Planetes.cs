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
using System.Windows.Forms.Design;

namespace FormPlanetes
{
    public partial class frmSelector_Planetes : frmBaseBBDDSelect
    {
        public frmSelector_Planetes()
        {
            InitializeComponent();

            Data data = new Data()
            {
                autoLabel = true,
                querySelect = @"
                    select idPlanet,DescPlanet,CodePlanet
                    from Planets
                ",
                queryOrder = "order by DescPlanet",
                titol = $"Selector Planetes",
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella() { visible = false},
                new casella() { ample = 200, visible = true, alineacio = CasellaAlineacio.Esquerra},
                new casella() { ample = 100, visible = true, alineacio = CasellaAlineacio.Centrat},
            };
        }

        private void frmSelector_Sectors_Load(object sender, EventArgs e)
        {
            InicializarFormulario(this);

            foreach(Control control in this.Controls)
            {
                if (control is TextBox txt)
                {
                    txt.KeyDown += TextBox_KeyDown;
                }
            }

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            InicializarTimerTeclado();
        }
    }
}
