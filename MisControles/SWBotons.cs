using Configuracio;
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
using Utils;

namespace MisControles
{
    public partial class SWBotons : UserControl
    {
        private Font _font;
        private float _fontSize;
        private Brush _colorFuente;
        private string _texto = "";
        private bool _isPressed = false;
        private bool _haytecla = false;
        private string _quetecla = "";
        private bool _noDragDrop = false;

        public SWBotons()
        {
            InitializeComponent();
            //InitializePictureBox();

            this.DoubleBuffered = true;
            this.Resize += (s, e) => this.Invalidate();

            this.BackColor = Config.Colores.Formularios.BackColor;

            _fontSize = 14f; // Tamaño de fuente por defecto
            _font = new Font("Agency FB", _fontSize, FontStyle.Bold);
            _colorFuente = Config.Colores.Botones.FontColor;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            InitializePictureBox();
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Desactivar Drag & Drop")]
        public bool DesactivarDragAndDrop
        {
            get => _noDragDrop;
            set
            {
                _noDragDrop = value;
                Invalidate(); // Redibuja el control para reflejar el cambio de texto
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Texto")]
        public string Texto 
        {
            get => _texto;
            set
            {
                _texto = value;
                Invalidate(); // Redibuja el control para reflejar el cambio de texto
            }
        }

        [Browsable(true)]
        [Category("Personalizació")]
        [Description("Nom formulari")]
        public string Formulari { get; set; }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isPressed = true;
            Invalidate(); // Redibuja el control para reflejar el cambio

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPressed = false;
            Invalidate(); // Redibuja el control para reflejar el cambio

            base.OnMouseUp(e);
        }

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

            using (Pen borderPen = new Pen(Config.Colores.Botones.ColorLineaInterior, brush_size))
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

            using (Pen borderPen = new Pen(Config.Colores.Botones.ColorLineaInterior, brush_size))
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

            using (Pen borderPen = new Pen(Config.Colores.Botones.ColorLineaExterior, brush_size))
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

            using (Pen borderPen = new Pen(Config.Colores.Botones.ColorLineaExterior, brush_size))
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


            Color colorFondo = _isPressed ? Config.Colores.Botones.ColorLineaInterior : Config.Colores.Botones.BackColor;

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

            Color colorInicioDegradado = _isPressed ? Config.Colores.Botones.ColorLineaInterior : Config.Colores.Botones.ColorLineaExterior;
            Color colorFinalDegradado = _isPressed ? Config.Colores.Botones.ColorLineaExterior : Config.Colores.Botones.ColorLineaInterior;

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

            string copiaText = _texto;


            SizeF textSizeSub = new SizeF();
            SizeF textSizeIni = new SizeF();

            int possub = copiaText.IndexOf("&");
            bool siSub = possub >= 0;


            if (siSub)
            {
                textSizeSub = g.MeasureString(copiaText, _font);
                textSizeIni = g.MeasureString(copiaText.Left(possub), _font);
                copiaText = copiaText.Replace("&", "");

                if (!_haytecla)
                {
                    _quetecla = copiaText[possub].ToString().ToLower();
                    string gg = "";
                }

                _haytecla = true;
            }

            int centerX = this.Width / 2;
            int centerY = this.Height / 2;

            int inc = 0;

            if (_isPressed) {
                inc = ((int)(this.Height / 100.0) * 2);
                if (inc <= 0) {
                    inc = 1;
                }
                centerY += inc;
            }

            SizeF textSize = g.MeasureString(copiaText, _font);
            PointF textPosition = new PointF(
                centerX - textSize.Width / 2,
                centerY - textSize.Height / 2
            );
            g.DrawString(copiaText, _font, _colorFuente, textPosition);


            // Crear el rectángulo donde se aplicará el gradiente

            if (siSub)
            {
                Size sizeSub = new Size((int)(textSizeSub.Width - textSize.Width), 2);
                Point textPositionInt = new Point((int)textPosition.X + (int)textSizeIni.Width, (int)(textPosition.Y + textSize.Height + inc)); // 10 offset vertical

                Rectangle rect = new Rectangle(textPositionInt, sizeSub);

                // Crear un LinearGradientBrush de izquierda a derecha
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Yellow, Color.Red, LinearGradientMode.Horizontal))
                {
                    // Dibujar el rectángulo con el degradado
                    g.FillRectangle(brush, rect);
                }
            }

            if (!_noDragDrop)
            {
                pictureBox.Location = new Point(40, 16);
            }
        }

        public new event MouseEventHandler MouseClick;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            //base.OnMouseClick(e);

            // Invocar el evento MouseClick personalizado
            MouseClick?.Invoke(this, e);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            // Permitir que el control procese todas las teclas, incluidas flechas, Enter, etc.
            return true;
        }

        public void ProcessKey(KeyEventArgs e)
        {
            string teclaPulsada = e.KeyCode.ToString().ToLower();

            if (_haytecla && teclaPulsada == _quetecla)
            {
                MouseEventArgs mouseEventArgs = new MouseEventArgs(
                    MouseButtons.Left, // Botón izquierdo
                    1,                 // Número de clics
                    0,                 // Coordenada X
                    0,                 // Coordenada Y
                    0                  // Delta de la rueda del ratón
                );

                // Invocar el evento MouseClick personalizado
                MouseClick?.Invoke(this, mouseEventArgs);

                e.Handled = true; // Evita que se propague el evento.
            }
        }

        #region "PictureBox"

        private PictureBox pictureBox;

        private void InitializePictureBox()
        {
            if (!_noDragDrop)
            {
                pictureBox = new PictureBox
                {
                    Image = Properties.Resources.star3, // La imagen que quieres usar
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    Size = new Size(20, 20),
                    Cursor = Cursors.Hand // Indicar visualmente que es interactivo
                };

                // Evento para iniciar el drag and drop
                pictureBox.MouseDown += PictureBox_MouseDown;

                // Añadir el PictureBox al control
                this.Controls.Add(pictureBox);
                pictureBox.BringToFront(); // Asegurar que esté encima de otros elementos
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_noDragDrop)
            {
                if (e.Button == MouseButtons.Left)
                {
                    // Crear un cursor visual basado en la imagen `star3`
                    Cursor dragCursor = CreateDragCursor(Properties.Resources.star3);

                    // Cambiar el cursor por el personalizado durante el arrastre
                    Cursor.Current = dragCursor;

                    // Iniciar el drag and drop con el botón completo (SWBotons)
                    DoDragDrop(this, DragDropEffects.Move);
                }
            }
        }

        private Cursor CreateDragCursor(Image dragImage)
        {
            // Ajustar el tamaño de la imagen (por ejemplo, 32x32)
            int cursorSize = 32; // Cambia este valor según el tamaño que prefieras
            Bitmap bitmap = new Bitmap(cursorSize, cursorSize);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);

                // Dibujar la imagen escalada al nuevo tamaño
                g.DrawImage(dragImage, new Rectangle(0, 0, cursorSize, cursorSize));

                // Opcional: Agregar un contorno para mayor visibilidad
                using (Pen pen = new Pen(Color.Gray, 2))
                {
                    g.DrawRectangle(pen, 0, 0, cursorSize - 1, cursorSize - 1);
                }
            }

            // Crear el cursor a partir del bitmap redimensionado
            return new Cursor(bitmap.GetHicon());
        }

        #endregion
    }
}
