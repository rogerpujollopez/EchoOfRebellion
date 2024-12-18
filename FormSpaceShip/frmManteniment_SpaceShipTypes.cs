﻿using FormBaseBBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSpaceShip
{
    public partial class frmManteniment_SpaceShipTypes : frmBaseBBDD
    {
        public frmManteniment_SpaceShipTypes()
        {
            InitializeComponent();

            string tabla = "SpaceShipTypes";
            Data data = new Data()
            {
                autoLabel = true,
                taule = "SpaceShipTypes",
                querySelect = @"SELECT sst.idSpaceShipType, sst.idFiliation, sst.idSpaceShipCategory, sst.CodeSpaceShipType, sst.DescSpaceShipType, f.DescFiliations, sc.DescSpaceShipCategory FROM SpaceShipTypes AS sst LEFT JOIN Filiations AS f ON sst.idFiliation = f.idFiliation LEFT JOIN SpaceShipCategories AS sc ON sst.idSpaceShipCategory = sc.idSpaceShipCategory",
                queryUpdate = @"select idSpaceShipType,CodeSpaceShipType,DescSpaceShipType,idFiliation,idSpaceShipCategory from SpaceShipTypes ",
                id = "idSpaceShipType",
                titol = $"Mantenimiento tabla '{tabla}'"

            };


            SetData = data;

            SetCaselles = new List<casella>() {
                    new casella() { nom = "id", ample = 100 , visible = true, alineacio = CasellaAlineacio.Centrat},
                };

            // ds Combo
            SetLlistes = new List<llista>()
                {
                    new llista() { id="idSpaceShipCategory", query="select idSpaceShipCategory,CodeSpaceShipCategory,DescSpaceShipCategory from SpaceShipCategories order by DescSpaceShipCategory"},
                    new llista() { id="idFiliation", query="select idFiliation,CodeFiliation,DescFiliations as Filiation from Filiations order by Filiation"}
                };


            //SetLlistes = new List<llista>()
            //    {
            //        new llista() { id = "idFiliation", query = "select idFiliation,CodeFiliation,DescFiliations as Filiation from Filiations order by Filiation"}
            //    };
        }

        private void frmManteniment_SpaceShipTypes_Load(object sender, EventArgs e)
        {
            InicializarFormulario();
        }
    }
}
