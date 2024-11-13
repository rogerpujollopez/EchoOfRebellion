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

namespace MisControles
{
    public partial class SWBotons : UserControl
    {
        private Font _font;
        private float _fontSize;
        private Brush _colorFuente;
        private string _texto = "";
        private bool isPressed = false;

        public SWBotons()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Resize += (s, e) => this.Invalidate();

            //this.MouseDown += (s, e) => { OnButtonPressed(s,e); };
            //this.MouseUp += (s, e) => { OnButtonReleased(s,e); };

            this.BackColor = Color.Black;

            _fontSize = 14f; // Tamaño de fuente por defecto
            _font = new Font("Agency FB", _fontSize, FontStyle.Bold);
            _colorFuente = Brushes.White;
        }

        private Color colorFondoBoton = Color.FromArgb(29, 17, 67);
        private Color colorPerfilInteriorBoton = Color.FromArgb(85, 84, 128);
        private Color colorPerfilExteriorBoton = Color.FromArgb(126, 157, 201);

        [Browsable(true)]
        [Category("Personalización")]
        [Description("Texto")]
        public string Texto // Usar `new` en lugar de `override`
        {
            get => _texto;
            set
            {
                _texto = value;
                Invalidate(); // Redibuja el control para reflejar el cambio de texto
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Lógica personalizada antes de llamar al método base
            isPressed = true;
            Invalidate(); // Redibuja el control para reflejar el cambio

            // Llamar al método base para asegurar el funcionamiento predeterminado
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Lógica personalizada antes de llamar al método base
            isPressed = false;
            Invalidate(); // Redibuja el control para reflejar el cambio

            // Llamar al método base para asegurar el funcionamiento predeterminado
            base.OnMouseUp(e);
        }



        //[Browsable(true)]
        //[Category("Personalización")]
        //[Description("Mouse Up")]
        //public event EventHandler MouseUp;

        //public void OnButtonReleased(object sender, EventArgs e)
        //{
        //    isPressed = false;
        //    Invalidate(); // Redibuja el control

        //    if (this.MouseUp != null)
        //    {
        //        this.MouseUp(sender, e);
        //    }
        //}


        #region "Eventos no disponibles"

        [Browsable(false)]
        [Obsolete("El evento DragEnter no está disponible para este control.", true)]
        public new event DragEventHandler DragEnter
        {
            add { throw new NotSupportedException("El evento DragEnter no está disponible para este control."); }
            remove { }
        }

        #endregion



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int start_x = 20;
            int brush_size = 2;

            // Tamaños base para los puntos iniciales
            int baseWidth = 680 + start_x;
            int baseHeight = 270;
            int padding = 8; // Padding para el borde

            // Factor de escala único basado en el ancho y alto
            float scale = Math.Min((float)this.Width / baseWidth, (float)this.Height / baseHeight);

            // Ajuste de la posición inicial para centrar el polígono
            float offsetX = (this.Width - baseWidth * scale) / 2;
            float offsetY = (this.Height - baseHeight * scale) / 2;

            #region "Reflejo superior interior"

            Point[] perfilPoints = new Point[]
            {
                new Point((int)((start_x - padding) * scale + offsetX), (int)((30 + 27) * scale + offsetY)),
                new Point((int)((start_x - padding) * scale + offsetX), (int)((30 - padding) * scale + offsetY)),
                new Point((int)((start_x + 532 + padding) * scale + offsetX), (int)((30 - padding) * scale + offsetY)),
                new Point((int)((start_x + 532 + padding + 36) * scale + offsetX), (int)((30 - padding + 36) * scale + offsetY)),
                new Point((int)((start_x + 532 + padding + 36 + 92) * scale + offsetX), (int)((30 + 36 - padding) * scale + offsetY)),
                new Point((int)((start_x + 532 + padding + 36 + 92) * scale + offsetX), (int)((30 + 36 + 120) * scale + offsetY)),
            };

            // Dibujar el borde del polígono
            using (Pen borderPen = new Pen(colorPerfilInteriorBoton, brush_size))
            {
                g.DrawLines(borderPen, perfilPoints);
            }

            #endregion

            #region "Reflejo inferior interior"

            Point[] perfilInferiorPoints = new Point[]
            {
                new Point((int)((start_x - padding) * scale + offsetX), (int)((30 + 27 + 70) * scale + offsetY)),
                new Point((int)((start_x - padding) * scale + offsetX), (int)((30 + 36 + 180 - 36 + padding) * scale + offsetY)),
                new Point((int)((start_x - padding + 532 + 36 + 92 - 474 - 36) * scale + offsetX), (int)((30 + 36 + 180 - 36 + padding) * scale + offsetY)),
                new Point((int)((start_x - padding  + 532 + 36 + 92 - 474) * scale + offsetX), (int)((30 + 36 + 180 + padding) * scale + offsetY)),
                new Point((int)((start_x + padding + 532 + 36 + 92) * scale + offsetX), (int)((30 + 36 + 180 + padding) * scale + offsetY)),
                new Point((int)((start_x + padding + 532 + 36 + 92) * scale + offsetX), (int)((30 + 36 + 180 + padding - 30) * scale + offsetY)),
            };

            // Dibujar el borde del polígono
            using (Pen borderPen = new Pen(colorPerfilInteriorBoton, brush_size))
            {
                g.DrawLines(borderPen, perfilInferiorPoints);
            }

            #endregion

            #region "Reflejo exterior superior"

            Point[] perfilExteriorSuperiorPoints = new Point[]
            {
                new Point((int)((start_x - padding) * scale + offsetX - (brush_size / 2)), (int)((30 - (padding * 2)) * scale + offsetY)),
                new Point((int)((start_x + 532 + padding) * scale + offsetX + (brush_size / 2)), (int)((30 - (padding * 2)) * scale + offsetY)),
            };

            // Dibujar el borde del polígono
            using (Pen borderPen = new Pen(colorPerfilExteriorBoton, brush_size))
            {
                g.DrawLines(borderPen, perfilExteriorSuperiorPoints);
            }

            #endregion

            #region "Reflejo exterior inferior"

            Point[] perfilExteriorInferiorPoints = new Point[]
            {
                new Point((int)((start_x - padding  + 532 + 36 + 92 - 474) * scale + offsetX - (brush_size / 2)), (int)((30 + 36 + 180 + (padding * 2)) * scale + offsetY)),
                new Point((int)((start_x + padding + 532 + 36 + 92) * scale + offsetX + (brush_size / 2)), (int)((30 + 36 + 180 + (padding * 2)) * scale + offsetY)),
            };

            // Dibujar el borde del polígono
            using (Pen borderPen = new Pen(colorPerfilExteriorBoton, brush_size))
            {
                g.DrawLines(borderPen, perfilExteriorInferiorPoints);
            }

            #endregion

            // Definir los puntos del polígono ajustados por el factor de escala y el offset
            Point[] polygonPoints = new Point[]
            {
                new Point((int)(start_x * scale + offsetX), (int)(30 * scale + offsetY)),
                new Point((int)((start_x + 532) * scale + offsetX), (int)(30 * scale + offsetY)),
                new Point((int)((start_x + 532 + 36) * scale + offsetX), (int)((30 + 36) * scale + offsetY)),
                new Point((int)((start_x + 532 + 36 + 92) * scale + offsetX), (int)((30 + 36) * scale + offsetY)),

                new Point((int)((start_x + 532 + 36 + 92) * scale + offsetX), (int)((30 + 36 + 180) * scale + offsetY)),
                new Point((int)((start_x + 532 + 36 + 92 - 474) * scale + offsetX), (int)((30 + 36 + 180) * scale + offsetY)),
                new Point((int)((start_x + 532 + 36 + 92 - 474 - 36) * scale + offsetX), (int)((30 + 36 + 180 - 36) * scale + offsetY)),
                new Point((int)(start_x * scale + offsetX), (int)((30 + 36 + 180 - 36) * scale + offsetY)),
            };


            Color colorFondo = isPressed ? colorPerfilInteriorBoton : colorFondoBoton;

            // Crear el pincel para rellenar el polígono principal
            using (Brush brush = new SolidBrush(colorFondo))
            {
                g.FillPolygon(brush, polygonPoints);
            }

            // Dibujar el contorno del polígono principal
            //using (Pen pen = new Pen(colorPerfilInteriorBoton, 2))
            //{
            //    g.DrawPolygon(pen, polygonPoints);
            //}

            Color colorInicioDegradado = isPressed ? colorPerfilInteriorBoton : colorPerfilExteriorBoton;
            Color colorFinalDegradado = isPressed ? colorPerfilExteriorBoton : colorPerfilInteriorBoton;

            #region "Rectangulo con degradado inferior"

            int x_ini = (int)((start_x - padding) * scale + offsetX);
            int y_ini = (int)((30 + 36 + 180 - 36 + (padding * 3)) * scale + offsetY);

            int x_fin = (int)((start_x - padding + 532 + 36 + 92 - 474 - 36 + 24) * scale + offsetX);
            int y_fin = (int)((30 + 36 + 180 - 36 + 24 + (padding * 3)) * scale + offsetY);

            // Definir los puntos para formar el rombo
            Point[] diamondPoints = new Point[]
            {
                new Point((int)((start_x - padding) * scale + offsetX), (int)((30 + 36 + 180 - 36 + (padding*3)) * scale + offsetY)),
                new Point((int)((start_x - padding + 532 + 36 + 92 - 474 - 36) * scale + offsetX), (int)((30 + 36 + 180 - 36 + (padding*3)) * scale + offsetY)),
                new Point((int)((start_x - padding + 532 + 36 + 92 - 474 - 36 + 24) * scale + offsetX), (int)((30 + 36 + 180 - 36 + 24 + (padding*3)) * scale + offsetY)),
                new Point((int)((start_x - padding + 24) * scale + offsetX), (int)((30 + 36 + 180 - 36 + 24 + (padding*3)) * scale + offsetY)),
            };


            // Crear el rectángulo de límite para el degradado
            Rectangle gradientBounds = new Rectangle(x_ini, y_ini, x_fin - x_ini, y_fin - y_ini);

            // Crear el pincel de degradado
            using (LinearGradientBrush brush = new LinearGradientBrush(gradientBounds, colorInicioDegradado, colorFinalDegradado, LinearGradientMode.Horizontal))
            {
                // Dibujar el rombo relleno con el degradado
                g.FillPolygon(brush, diamondPoints);
            }


            #endregion


            #region "Rectangulo con degradado superior"

            x_ini = (int)((start_x + 532 + padding + 36 - 24 + (padding * 1)) * scale + offsetX);
            y_ini = (int)((30 - padding + 36 - 24 - (padding * 1)) * scale + offsetY);

            x_fin = (int)((start_x + 532 + padding + 36 + 92) * scale + offsetX);
            y_fin = (int)((30 + 36 - padding - (padding * 1)) * scale + offsetY);

            // Definir los puntos para formar el rombo
            Point[] diamondPointsS = new Point[]
            {
                new Point((int)((start_x + 532 + padding + 36 + (padding*1)) * scale + offsetX), (int)((30 - padding + 36 - (padding*1)) * scale + offsetY)),
                new Point((int)((start_x + 532 + padding + 36 + 92) * scale + offsetX), (int)((30 + 36 - padding - (padding*1)) * scale + offsetY)),

                new Point((int)((start_x + 532 + padding + 36 + 92 - 24) * scale + offsetX), (int)((30 + 36 - padding - 24 - (padding*1)) * scale + offsetY)),
                new Point((int)((start_x + 532 + padding + 36 - 24 + (padding * 1)) * scale + offsetX), (int)((30 - padding + 36 - 24 - (padding*1)) * scale + offsetY)),
            };


            // Crear el rectángulo de límite para el degradado
            Rectangle gradientBoundsS = new Rectangle(x_ini, y_ini, x_fin - x_ini, y_fin - y_ini);

            // Crear el pincel de degradado
            using (LinearGradientBrush brush = new LinearGradientBrush(gradientBoundsS, colorInicioDegradado, colorFinalDegradado, LinearGradientMode.Horizontal))
            {
                // Dibujar el rombo relleno con el degradado
                g.FillPolygon(brush, diamondPointsS);
            }

            #endregion

            int centerX = this.Width / 2;
            int centerY = this.Height / 2;

            if (isPressed) {
                int inc = ((int)(this.Height / 100.0) * 2);
                if (inc <= 0) {
                    inc = 1;
                }
                centerY += inc;
            }

            SizeF textSize = g.MeasureString(_texto, _font);
            PointF textPosition = new PointF(
                centerX - textSize.Width / 2,
                centerY - textSize.Height / 2
            );
            g.DrawString(_texto, _font, _colorFuente, textPosition);
        }
    }
}
