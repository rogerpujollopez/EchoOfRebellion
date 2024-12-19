using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EchoOfRebellion.Clases.Utils
{
    public class Reflexio
    {
        private List<LlistatReflexio> forms;

        public Reflexio(DataSet ds)
        {
            forms = new List<LlistatReflexio>();

            forms.Add(new LlistatReflexio()
            {
                dll = @"FormRegions.dll",
                tipus = "FormRegions.frmManteniment_Regions",
                nom = "Regions"
            });

            forms.Add(new LlistatReflexio()
            {
                dll = @"FormPlanetes.dll",
                tipus = "FormPlanetes.frmManteniment_Planetes",
                nom = "Planetes"
            });

            forms.Add(new LlistatReflexio()
            {
                dll = @"FormSectors.dll",
                tipus = "FormSectors.frmSelector_Sectors",
                nom = "SectorsSelect"
            });

            forms.Add(new LlistatReflexio()
            {
                dll = @"FormSectors.dll",
                tipus = "FormSectors.frmManteniment_Sectors",
                nom = "Sectors"
            });

            forms.Add(new LlistatReflexio()
            {
                dll = @"FormUsers.dll",
                tipus = "FormUsers.frmManteniment_UserRangs",
                nom = "RangsUsuaris"
            });

            forms.Add(new LlistatReflexio()
            {
                dll = @"FormUsers.dll",
                tipus = "FormUsers.frmManteniment_UserCategories",
                nom = "CategoriesUsuaris"
            });

            forms.Add(new LlistatReflexio()
            {
                dll = @"FormUsers.dll",
                tipus = "FormUsers.frmManteniment_Users",
                nom = "Usuaris"
            });

            CarregarFormularis();
        }

        public static Form GetFormulari(string dll, string tipus)
        {
            Assembly _ensamblat = Assembly.LoadFrom(dll); // @"FormRegions.dll"
            Type _tipus = _ensamblat.GetType(tipus); // "FormRegions.frmManteniment_Regions"
            Form _frm = (Form)Activator.CreateInstance(_tipus);
            return _frm;
        }

        public Form GetFormulari(string nom)
        {
            LlistatReflexio frm = forms.FirstOrDefault(f => f.nom == nom);

            if (frm != null)
            {
                return frm.frm;
            }
            else
            {
                return null;
            }
        }

        private void CarregarFormularis() {

            string txtdll, txttipus;

            foreach (LlistatReflexio reflex in forms) {
                txtdll = reflex.dll;
                txttipus = reflex.tipus;

                Assembly ensamblat = Assembly.LoadFrom(txtdll); // @"FormRegions.dll"
                Type tipus = ensamblat.GetType(txttipus); // "FormRegions.frmManteniment_Regions"
                Form frm = (Form)Activator.CreateInstance(tipus);

                reflex.frm = frm;                
            }
        }

        public class LlistatReflexio
        {
            public string nom { get;set; }
            public Form frm { get; set; }
            public string dll { get; set; }
            public string tipus { get; set; }

        }

    }
}
