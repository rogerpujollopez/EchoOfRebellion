using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BiblioModeloDatos.DM.DMModel;

namespace UsuariActiuNameSpace
{
    public static class UsuariActiu
    {
        public static UsuariComplet usuari { get; set; }

        
        public static event EventHandler InformacionActualizada;

        public static void ActualizarInformacion()
        {
            InformacionActualizada?.Invoke(null, EventArgs.Empty);
        }

        public static string ftpserver { get; set; }
        public static string ftpuser { get; set; }
        public static string ftppass { get; set; }
    }

}
