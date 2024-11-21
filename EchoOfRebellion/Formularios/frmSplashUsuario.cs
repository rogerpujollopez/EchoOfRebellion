using EchoOfRebellion.Clases.BIZ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsuariActiuNameSpace;

namespace EchoOfRebellion.Formularios
{
    public partial class frmSplashUsuario : Form
    {
        private Timer timer;
        public frmSplashUsuario()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;

            timer = new Timer
            {
                Interval = 4000
            };

            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();

        }

        private void frmSplashUsuario_Load(object sender, EventArgs e)
        {
            EllipseImatgeUsuari();
            EfectePictureBox();
            CarregarDadesUsuari();
        }
        private void CarregarDadesUsuari()
        {
            labUserName.Text = UsuariActiu.usuari.UserName;
            labCategory.Text = UsuariActiu.usuari.DescCategory;
            labRank.Text = UsuariActiu.usuari.DescRank;

            // Mostra la imatge de l'usuari
        }
        private void EllipseImatgeUsuari()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, ptbFotoUsuario.Width, ptbFotoUsuario.Height);
            ptbFotoUsuario.Region = new Region(path);
        }
        private void EfectePictureBox()
        {
            ptbEffect.Image = Image.FromFile(@"Resources/EfectoSplashUsuario.gif");
            ptbEffect.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
