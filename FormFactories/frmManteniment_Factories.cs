using FormBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormFactories
{
    public partial class frmManteniment_Factories : frmBase
    {
        FactoriesEntities db;
        List<Factories> factorieList;
        bool EsNou = false;
        public frmManteniment_Factories()
        {
            InitializeComponent();
        }
        private void frmFactories_Load(object sender, EventArgs e)
        {
            CarregaDades();
        }
        private void CarregaDades()
        {
            db = new FactoriesEntities();
            factorieList = db.Factories.ToList();
            FerBinding();
        }
        private void FerBinding()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.DataBindings.Clear();
                    ctrl.DataBindings.Add("Text", factorieList, ctrl.Tag.ToString());
                    ctrl.Validated += new System.EventHandler(this.ValidarTextBox);
                }
            }
            dtgFactories.DataSource = factorieList;
            dtgFactories.Columns["idFactory"].Visible = false;
        }
        private void ValidarTextBox(object sender, EventArgs e)
        {
            TextBox ctr = (TextBox)sender;
            if (ctr.DataBindings.Count > 0)
            {
                ctr.DataBindings[0].BindingManagerBase.EndCurrentEdit();
            }
        }
        private void TreuBinding()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.DataBindings.Clear();
                    ctrl.Text = "";
                    ctrl.Validated -= new System.EventHandler(this.ValidarTextBox);
                }
            }
        }
        private void btnNou_Click(object sender, EventArgs e)
        {
            EsNou = true;
            btnNou.Enabled = false;
            TreuBinding();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (EsNou)
            {
                Factories factory = new Factories()
                {
                    codeFactory = txtCodeFactory.Text,
                    DescFactory = txtDescFactory.Text
                };
                db.Factories.Add(factory);
                FerBinding();
                EsNou = false;
                btnNou.Enabled = true;
            }
            db.SaveChanges();
            CarregaDades();
        }
    }
}
