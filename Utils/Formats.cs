using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utils
{
    public static class Formats
    {
        public static class Grids
        {
            public static void FormatoGrid(DataGridView dgv)
            {
                // Configuración general
                dgv.Font = new Font("Arial", 10, FontStyle.Regular); // Fuente general
                dgv.ForeColor = Color.Black; // Color de letra en negro
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Selección por fila completa
                dgv.RowHeadersVisible = false; // Ocultar selector de la izquierda
                dgv.AllowUserToAddRows = false; // No permitir añadir filas
                dgv.AllowUserToDeleteRows = false; // No permitir eliminar filas
                dgv.ReadOnly = true; // No permitir editar celdas
                dgv.MultiSelect = false; // No permitir selección múltiple

                // Configuración de estilos para la selección
                DataGridViewCellStyle selectionStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.Violet, // Fondo violeta para la fila seleccionada
                    ForeColor = Color.White   // Letra blanca para la fila seleccionada
                };
                dgv.DefaultCellStyle.SelectionBackColor = selectionStyle.BackColor;
                dgv.DefaultCellStyle.SelectionForeColor = selectionStyle.ForeColor;

                // Configuración adicional para mejorar estética (opcional)
                dgv.DefaultCellStyle.BackColor = Color.White; // Fondo blanco para las celdas no seleccionadas
                dgv.DefaultCellStyle.ForeColor = Color.Black; // Texto negro para celdas no seleccionadas
                dgv.GridColor = Color.LightGray; // Color de las líneas del grid
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezados centrados
            }

        }
    }
}
