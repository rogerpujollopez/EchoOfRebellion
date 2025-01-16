using EchoOfRebellion.Clases.Utils;
using FormBase;
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
using UsuariActiuNameSpace;
using static BiblioModeloDatos.DM.DMModel;

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
            BackColor = Color.FromArgb(32, 32, 32);

            Titulo = "Menú principal";
            
            DibuixarMenu();
        }

        private void DibuixarMenu()
        {
            int _x = 10;
            int _y = 120;
            int _h = 80;
            int _w = 260;
            int offset = 10;

            foreach (Permis permis in UsuariActiu.usuari.Permisos)
            {
                SWBotons btn = new SWBotons()
                {
                    Texto = permis.Desc,
                    Formulari = permis.Nom,
                    Top = _y,
                    Left = _x,
                    Height = _h,
                    Width = _w,
                    BackColor = BackColor
                };

                _y += _h + offset;

                btn.MouseClick += SwBotoms_MouseClick;

                this.Controls.Add(btn);
            }
        }

        private void SwBotoms_MouseClick(object sender, MouseEventArgs e)
        {
            string txt = ((SWBotons)sender).Formulari ?? "";

            if (txt != "")
            {
                Form frm = Reflexio.GetFormulari(txt);
                frm.ShowDialog();
            }
        }

        private void frmMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            HandleKeyDown(e);
        }

        private void Cerrar()
        {
            if (Missatgeria.Sortir())
            {
                this.Close();
            }
        }

        protected override void HandleKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cerrar();
                    break;
            }
        }
    }
}
