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

namespace FormSectors
{
    public partial class frmSelector_Sectors : frmBaseBBDDSelect
    {
        public frmSelector_Sectors()
        {
            InitializeComponent();



            Data data = new Data()
            {
                autoLabel = true,
                querySelect = @"
                    select idSector,CodeSector,DescSector,s.Remarks,r.DescRegion 
                    from Sectors as s left join Regions as r on s.idRegion=r.idRegion
                ",
                queryOrder = "order by CodeSector",
                titol = $"Selector"
            };
            SetData = data;

            SetCaselles = new List<casella>() {
                new casella(){ nom="id", ample=100 , visible=true, alineacio=CasellaAlineacio.Centrat},
                new casella() { nom ="name", ample=200, visible = true, alineacio = CasellaAlineacio.Dreta},
                new casella() { nom="name2", ample=300, visible = true},
            };

            // ds Combo
            //SetLlistes = new List<llista>()
            //{
            //    new llista() { id="idRegion", query="select idRegion,CodeRegion,DescRegion as Region from Regions order by Region"}
            //};

        }

        private void frmSelector_Sectors_Load(object sender, EventArgs e)
        {
            InicializarFormulario();

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
