using BiblioModeloDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDILibrary
{
    public static class Edi
    {

        /*
         Ejemplo

            string ruta = @"C:\Users\Administrador\Desktop\DAM\S2AM\ABP\17 - Gestió de comandes\RAREDI_1.edi";

            string[] lines = File.ReadAllLines(ruta);

            int idOrder = Edi.EDItoOrder(lines);
         
         */

        public static int EDItoOrder(string[] lines)
        {
            if (lines.Length == 0)
            {
                throw new Exception("No hay información a procesar");
            }

            if (lines[0] != "ORDERS_D_96A_UN_EAN008")
            {
                throw new Exception("El fichero EDI no es un pedido");
            }

            string[] parts;
            int idOrder = 0;

            int pos = 1;

            do
            {
                parts = lines[pos].Split('|');
                if (parts[0] == "ORD")
                {
                    string codeOrder = parts[1];
                    string CodePriority = parts[2];

                    int IdPriority = ObtenerPriority(CodePriority);

                    DateTime? dateOrder = null;
                    int idOperationalArea = 0;
                    int idAgency = 0;
                    int idFactory = 0;

                    pos++;

                    Procesar_DTM(ref dateOrder, lines[pos]);

                    pos++;

                    Procesar_NADMS(ref idOperationalArea, ref idAgency, lines[pos]);

                    pos++;

                    Procesar_NADMR(ref idFactory, lines[pos]);

                    idOrder = NuevoPedido(codeOrder, (DateTime)dateOrder, IdPriority, idFactory);

                    pos++;

                    bool salirbucle = false;

                    do
                    {
                        int idPlanet = 0;
                        int idReference = 0;
                        int cantidad = 0;

                        Procesar_LIN(ref idPlanet, ref idReference, lines[pos]);

                        pos++;

                        Procesar_QTYLIN(ref cantidad, lines[pos]);

                        pos++;

                        DateTime? DeliveryDate = null;

                        Procesar_DTMLIN(ref DeliveryDate, lines[pos]);

                        NuevoDetallePedido(idOrder, idPlanet, idReference, cantidad, (DateTime)DeliveryDate);

                        pos++;

                        if (pos < lines.Length)
                        {
                            parts = lines[pos].Split('|');
                            salirbucle = parts[0] != "LIN";
                        }
                    }
                    while (pos < lines.Length && !salirbucle);
                }
                else
                {
                    throw new Exception("Falta linea ORD");
                }
            }
            while (pos < lines.Length);

            /*
             
                ORDERS_D_96A_UN_EAN008
                ORD|061243446666|220|
                DTM|20200119|
                NADMS|INNER|40A|
                NADMR|NABOSOUTXW02|

                LIN|0000INRINABO|841001009689|EN|
                QTYLIN|21|17|
                DTMLIN|20200110|

                LIN|0000OUTTAKO|841001009692|EN|
                QTYLIN|21|31|
                DTMLIN|20200115|             
             
             
             */

            return idOrder;

        }



        private static void Procesar_DTM(ref DateTime? dateOrder, string linea)
        {
            string[] parts = linea.Split('|');
            if (parts[0] == "DTM")
            {
                string txtdateOrder = parts[1];
                try
                {
                    dateOrder = DateTime.ParseExact(txtdateOrder, "yyyyMMdd", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en el Date Order");
                }
            }
            else
            {
                throw new Exception("Falta linea DTM");
            }
        }

        private static void Procesar_NADMS(ref int idOperationalArea, ref int idAgency, string linea)
        {
            string[] parts = linea.Split('|');
            if (parts[0] == "NADMS")
            {
                string CodeOperationalArea = parts[1];
                idOperationalArea = ObtenerOperationalAreas(CodeOperationalArea);

                string CodeAgency = parts[2];
                idAgency = ObtenerCodeAgency(CodeAgency);
            }
            else
            {
                throw new Exception("Falta linea NADMS");
            }
        }

        private static void Procesar_NADMR(ref int idFactory, string linea)
        {
            string[] parts = linea.Split('|');
            if (parts[0] == "NADMR")
            {
                string codeFactory = parts[1];
                idFactory = ObtenerFactories(codeFactory);
            }
            else
            {
                throw new Exception("Falta linea NADMR");
            }
        }

        private static void Procesar_LIN(ref int idPlanet, ref int idReference, string linea)
        {
            string[] parts = linea.Split('|');
            if (parts[0] == "LIN")
            {
                string CodePlanet = parts[1];
                string codeReference = parts[2];

                idPlanet = ObtenerPlanets(CodePlanet);
                idReference = ObtenerReferencies(codeReference);
            }
            else
            {
                throw new Exception("Falta linea LIN");
            }
        }

        private static void Procesar_QTYLIN(ref int cantidad, string linea)
        {
            string[] parts = linea.Split('|');
            if (parts[0] == "QTYLIN")
            {
                string Calificador = parts[1];
                string txtCantidad = parts[2];

                cantidad = Convert.ToInt32(txtCantidad);

                switch (Calificador)
                {
                    case "21":
                        break;
                    case "61":
                        cantidad *= -1;
                        break;
                    default:
                        throw new Exception("Calificador no válido");
                }
            }
            else
            {
                throw new Exception("Falta linea QTYLIN");
            }
        }

        private static void Procesar_DTMLIN(ref DateTime? DeliveryDate, string linea)
        {
            string[] parts = linea.Split('|');
            if (parts[0] == "DTMLIN")
            {
                string txtDeliveryDate = parts[1];
                try
                {
                    DeliveryDate = DateTime.ParseExact(txtDeliveryDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en DeliveryDate");
                }
            }
            else
            {
                throw new Exception("Falta linea DTMLIN");
            }
        }

        private static int NuevoPedido(string codeOrder, DateTime dateOrder, int IdPriority, int IdFactory)
        {
            string consulta = @"
                insert into Orders (codeOrder, dateOrder, IdPriority, IdFactory) 
                values (@codeOrder, @dateOrder, @IdPriority, @IdFactory);

                select SCOPE_IDENTITY();
            ";

            var parametros = new Dictionary<string, object>
            {
                { "@codeOrder", codeOrder },
                { "@dateOrder", dateOrder },
                { "@IdPriority", IdPriority },
                { "@IdFactory", IdFactory },
            };

            clsModeloDatos m = new clsModeloDatos();
            int idOrder = m.ExecutaConParametrosScope(consulta, parametros);

            return idOrder;
        }

        private static int NuevoDetallePedido(int idOrder, int idPlanet, int idReference, int Quantity, DateTime DeliveryDate)
        {
            string consulta = @"
                insert into OrdersDetail (idOrder, idPlanet, idReference, Quantity, DeliveryDate) 
                values (@idOrder, @idPlanet, @idReference, @Quantity, @DeliveryDate);

                select SCOPE_IDENTITY();
            ";

            var parametros = new Dictionary<string, object>
            {
                { "@idOrder", idOrder },
                { "@idPlanet", idPlanet },
                { "@idReference", idReference },
                { "@Quantity", Quantity },
                { "@DeliveryDate", DeliveryDate },
            };

            clsModeloDatos m = new clsModeloDatos();
            int idOrderDetail = m.ExecutaConParametrosScope(consulta, parametros);

            return idOrderDetail;
        }

        private static int ObtenerPriority(string CodePriority)
        {
            string consulta = @"select idPriority from Priority where CodePriority=@CodePriority";

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@CodePriority", CodePriority },
            };

            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            int valor = -1;

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                valor = Convert.ToInt32(row[0]);
            }
            else
            {
                throw new Exception("CodePriority no localizado");
            }

            return valor;
        }

        private static int ObtenerOperationalAreas(string CodeOperationalArea)
        {
            string consulta = @"select idOperationalArea from OperationalAreas where CodeOperationalArea=@CodeOperationalArea";

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@CodeOperationalArea", CodeOperationalArea },
            };

            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            int valor = -1;

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                valor = Convert.ToInt32(row[0]);
            }
            else
            {
                throw new Exception("CodeOperationalArea no localizado");
            }

            return valor;
        }

        private static int ObtenerCodeAgency(string CodeAgency)
        {
            string consulta = @"select idAgency from Agencies where CodeAgency=@CodeAgency";

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@CodeAgency", CodeAgency },
            };

            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            int valor = -1;

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                valor = Convert.ToInt32(row[0]);
            }
            else
            {
                throw new Exception("CodeAgency no localizado");
            }

            return valor;
        }

        private static int ObtenerFactories(string codeFactory)
        {
            string consulta = @"select idFactory from Factories where codeFactory=@codeFactory";

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@codeFactory", codeFactory },
            };

            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            int valor = -1;

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                valor = Convert.ToInt32(row[0]);
            }
            else
            {
                throw new Exception("CodeFactory no localizado");
            }

            return valor;
        }

        private static int ObtenerPlanets(string CodePlanet)
        {
            string consulta = @"select idPlanet from Planets where CodePlanet=@CodePlanet";

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@CodePlanet", CodePlanet },
            };

            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            int valor = -1;

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                valor = Convert.ToInt32(row[0]);
            }
            else
            {
                throw new Exception("CodePlanet no localizado");
            }

            return valor;
        }

        private static int ObtenerReferencies(string codeReference)
        {
            string consulta = @"select idReference from Referencies where codeReference=@codeReference";

            clsModeloDatos m = new clsModeloDatos();

            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                { "@codeReference", codeReference },
            };

            DataSet ds = m.GeneraConsultaCerca(consulta, parametros);

            int valor = -1;

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                valor = Convert.ToInt32(row[0]);
            }
            else
            {
                throw new Exception("CodeReference no localizado");
            }

            return valor;
        }


    }
}
