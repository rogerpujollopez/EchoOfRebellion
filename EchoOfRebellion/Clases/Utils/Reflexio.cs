using BiblioModeloDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;
using static BiblioModeloDatos.DM.DMModel;

namespace EchoOfRebellion.Clases.Utils
{
    public class Reflexio
    {
        public static Form GetFormulari(string formulari)
        {
            Form _frm = null;
            
            Permis permis = UsuariActiu.usuari.Permisos.FirstOrDefault(p => p.Nom == formulari);

            if (permis != null)
            {
                Assembly _ensamblat = Assembly.LoadFrom(permis.Dll); // @"FormRegions.dll"
                Type _tipus = _ensamblat.GetType(permis.Tipus); // "FormRegions.frmManteniment_Regions"
                _frm = (Form)Activator.CreateInstance(_tipus);
            }

            return _frm;
        }
    }
}
