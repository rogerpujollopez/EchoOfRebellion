using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Configuracio
{
    public static class Config
    {
        public static class Colores
        {
            private static Color colorFondoBoton = Color.FromArgb(29, 17, 67);
            private static Color colorPerfilInteriorBoton = Color.FromArgb(85, 84, 128);
            private static Color colorPerfilExteriorBoton = Color.FromArgb(126, 157, 201);

            public static class Formularios
            {
                public static Color BackColor
                {
                    get
                    {
                        return Color.Black;
                    }
                }
            }

            public static class Cabecera
            {
                public static Color BackColor
                {
                    get
                    {
                        return colorPerfilInteriorBoton;
                    }
                }
                public static Color ForeColor
                {
                    get
                    {
                        return Color.White;
                    }
                }
            }

            public static class Botones
            {
                public static Brush FontColor
                {
                    get
                    {
                        return Brushes.White;
                    }
                }

                public static Color BackColor
                {
                    get
                    {
                        return colorFondoBoton;
                    }
                }

                public static Color ColorLineaInterior
                {
                    get
                    {
                        return colorPerfilInteriorBoton;
                    }
                }

                public static Color ColorLineaExterior
                {
                    get
                    {
                        return colorPerfilExteriorBoton;
                    }
                }
            }

        }

    }
}
