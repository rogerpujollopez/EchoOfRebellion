using EchoOfRebellion.Clases.BIZ;
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

        private FlowLayoutPanel flow1;

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(32, 32, 32);

            Titulo = "Menú principal";

            base.ActualizarInformacion(); // Para que la foto se reajuste

            //DibuixarMenu();
            Flow();
        }

        #region "Drag and Drop"

        private void Flow()
        {
            flow1 = new FlowLayoutPanel
            {
                Name = "flow1",
                //BackColor = Color.Red, // Fondo rojo para visualizarlo
                AutoSize = true,       // Ajusta su tamaño automáticamente al contenido
                AutoSizeMode = AutoSizeMode.GrowAndShrink, // Permite expandir o contraer según sea necesario
                FlowDirection = FlowDirection.TopDown, // Los controles fluyen de izquierda a derecha
                WrapContents = true,   // Habilita que los elementos se muevan a la siguiente fila si no hay espacio
                //Dock = DockStyle.Top   // Anclarlo en la parte superior del formulario
                Location = new Point(20, 100), // Establecer la posición (Left = 20, Top = 100)
                Width = 300,           // Ancho inicial del FlowLayoutPanel
                Height = 400,          // Altura inicial del FlowLayoutPanel
                AllowDrop = true // Permitir Drag & Drop
            };

            // Asignar eventos de Drag and Drop
            flow1.DragEnter += Flow1_DragEnter;
            flow1.DragDrop += Flow1_DragDrop;

            // Añadir el FlowLayoutPanel al formulario
            this.Controls.Add(flow1);

            int _h = 80;
            int _w = 260;

            // Supongamos que UsuariActiu.usuari.Permisos contiene una lista de permisos.
            foreach (Permis permis in UsuariActiu.usuari.Permisos)
            {
                // Crear una instancia de SWBotons para cada permiso
                SWBotons btn = new SWBotons
                {
                    Texto = permis.Desc,
                    Formulari = permis.Nom,
                    Height = _h,
                    Width = _w,
                    BackColor = flow1.BackColor, // Igualar el color de fondo al del FlowLayoutPanel
                    Tag = permis.ID_Op
                };

                // Añadir el evento de clic
                btn.MouseClick += SwBotoms_MouseClick;

                // Añadir el SWBotons al FlowLayoutPanel
                flow1.Controls.Add(btn);
            }
        }

        private void Flow1_DragEnter(object sender, DragEventArgs e)
        {
            // Verificar si el objeto arrastrado es un PictureBox
            if (e.Data.GetDataPresent(typeof(SWBotons)))
            {
                e.Effect = DragDropEffects.Move; // Permitir mover el objeto
            }
            else
            {
                e.Effect = DragDropEffects.None; // Rechazar cualquier otro tipo de objeto
            }
        }

        //private void Flow1_DragDrop(object sender, DragEventArgs e)
        //{
        //    if (e.Data.GetData(typeof(SWBotons)) is SWBotons draggedButton)
        //    {
        //        // Mover el PictureBox al FlowLayoutPanel
        //        flow1.Controls.Add(draggedButton);
        //    }
        //}

        private void Flow1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(SWBotons)) is SWBotons draggedButton)
            {
                // Obtener la posición del ratón relativa al FlowLayoutPanel
                Point dropPoint = flow1.PointToClient(new Point(e.X, e.Y));

                // Determinar el índice donde insertar el control
                int insertIndex = GetInsertionIndex(dropPoint);

                // Eliminar el botón de su posición actual (si ya está dentro del FlowLayoutPanel)
                if (flow1.Controls.Contains(draggedButton))
                {
                    flow1.Controls.Remove(draggedButton);
                }

                // Insertar el botón en la posición calculada
                flow1.Controls.Add(draggedButton);
                flow1.Controls.SetChildIndex(draggedButton, insertIndex);

                GuardarOrden();
            }
        }

        private void GuardarOrden()
        {
            List<int> ordenBotones = new List<int>();

            // Recorrer los controles en el FlowLayoutPanel
            foreach (Control control in flow1.Controls)
            {
                if (control is SWBotons boton && boton.Tag is int tag)
                {
                    // Añadir el Tag (int) del botón a la lista
                    ordenBotones.Add(tag);
                }
            }

            BIZLogin.ActualizarOrdenMenu(ordenBotones);
        }

        private int GetInsertionIndex(Point dropPoint)
        {
            for (int i = 0; i < flow1.Controls.Count; i++)
            {
                // Obtener el rectángulo del control actual
                Control currentControl = flow1.Controls[i];
                Rectangle controlBounds = currentControl.Bounds;

                // Si el cursor está antes de este control, devolver el índice actual
                if (dropPoint.Y < controlBounds.Top + (controlBounds.Height / 2))
                {
                    return i;
                }
            }

            // Si el cursor está después de todos los controles, insertar al final
            return flow1.Controls.Count;
        }

        #endregion

        private void DibuixarMenu()
        {
            int _x = 0;
            int _y = 80;
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
            this.Close();
        }

        protected override void HandleKeyDown(KeyEventArgs e)
        {
            foreach (SWBotons boton in this.Controls.OfType<SWBotons>())
            {
                boton.ProcessKey(e); 
            }

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cerrar();
                    break;
            }
        }
    }
}
