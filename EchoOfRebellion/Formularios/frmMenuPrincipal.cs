using EchoOfRebellion.Clases.Utils;
<<<<<<< HEAD
=======
using FormBase;
>>>>>>> dev
using MisControles;
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
    public partial class frmMenuPrincipal : frmBase
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            Titulo("Menú principal");
=======
            Titulo = "Menú principal";
>>>>>>> dev
            
            DibuixarMenu();
        }


        private void DibuixarMenu()
        {
            Dictionary<string, string> opciones = new Dictionary<string, string>()
            {
                { "frmClientes", "Clientes" },
                { "frmProveedores", "Proveedores" },
                { "frmPlanetas", "Planets" },
            };

            int _x = 10;
            int _y = 120;
            int _h = 80;
            int _w = 260;
            int offset = 10;

            foreach (KeyValuePair<string, string> kvp in opciones)
            {
                string key = kvp.Key;
                string value = kvp.Value;

                SWBotons btn = new SWBotons()
                {
                    Texto = value,
                    Top=_y,
                    Left=_x,
                    Height=_h,
                    Width=_w,
                };

                _y += _h + offset;  
                
                this.Controls.Add(btn);
            }
        }

        private void frmMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cerrar();
                    break;
            }
        }

        private void Cerrar()
        {
            if (Missatgeria.Sortir())
            {
                this.Close();
            }
        }
    }
}
