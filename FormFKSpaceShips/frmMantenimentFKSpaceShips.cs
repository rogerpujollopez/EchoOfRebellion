using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FormBase;

namespace FormFKSpaceShips
{
    public partial class frmMantenimentFKSpaceShips : frmBase
    {
        SecureCoreG1Entities db = new SecureCoreG1Entities();

        public frmMantenimentFKSpaceShips()
        {
            InitializeComponent();
            Titulo = "Formulario Mantenimiento FK SpaceShips";
        }

        private void frmMantenimentFKSpaceShips_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarDatos();
        }

        private void CargarCategorias()
        {
            cmbBoxCategories.DataSource = db.SpaceShipCategories.ToList();
            cmbBoxCategories.DisplayMember = "DescSpaceShipCategory";
            cmbBoxCategories.ValueMember = "idSpaceShipCategory";
        }

        private void CargarDatos()
        {
            dgvDatos.DataSource = db.SpaceShipTypes
                .Select(s => new
                {
                    s.idSpaceShipType,
                    s.CodeSpaceShipType,
                    s.DescSpaceShipType,
                    Categoria = s.SpaceShipCategories.DescSpaceShipCategory
                })
                .ToList();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevo = new SpaceShipTypes()
            {
                CodeSpaceShipType = txtBoxCodeType.Text,
                DescSpaceShipType = txtBoxDescType.Text,
                idSpaceShipCategory = (int)cmbBoxCategories.SelectedValue
            };
            db.SpaceShipTypes.Add(nuevo);
            db.SaveChanges();
            CargarDatos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;

            int id = (int)dgvDatos.SelectedRows[0].Cells["idSpaceShipType"].Value;
            var edit = db.SpaceShipTypes.Find(id);
            if (edit != null)
            {
                edit.CodeSpaceShipType = txtBoxCodeType.Text;
                edit.DescSpaceShipType = txtBoxDescType.Text;
                edit.idSpaceShipCategory = (int)cmbBoxCategories.SelectedValue;
                db.SaveChanges();
                CargarDatos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) return;

            int id = (int)dgvDatos.SelectedRows[0].Cells["idSpaceShipType"].Value;
            var eliminar = db.SpaceShipTypes.Find(id);
            if (eliminar != null)
            {
                db.SpaceShipTypes.Remove(eliminar);
                db.SaveChanges();
                CargarDatos();
            }
        }
    }
}
