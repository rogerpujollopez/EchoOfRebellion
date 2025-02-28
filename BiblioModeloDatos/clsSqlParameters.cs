using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using UsuariActiuNameSpace;

namespace BiblioModeloDatos
{
    internal class clsSqlParameters
    {
        public static SqlConnectionStringBuilder SqlConectionString() // SqlConnectionStringBuilder
        {
            //SqlConnectionStringBuilder builder = null;

            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            ////string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            ////ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            ////configMap.ExeConfigFilename = Path.Combine(currentDirectory, "AdoDemo.dll.config");

            ////Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);

            //ConfigurationSection section = config.GetSection("connectionStrings");

            //if (section != null && !section.SectionInformation.IsProtected)
            //{
            //    // Cifrar la sección si no está protegida
            //    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //    // Guardar los cambios en el archivo de configuración
            //    config.Save(ConfigurationSaveMode.Modified);
            //}

            //ConnectionStringSettings conf = ConfigurationManager.ConnectionStrings["ConnectionString"];
            //if (conf != null)
            //{
            //    builder = new SqlConnectionStringBuilder(conf.ConnectionString);
            //}

            //return builder;

            return new SqlConnectionStringBuilder
            {
                DataSource = UsuariActiu.sqlserver,
                InitialCatalog = UsuariActiu.sqlbbdd,
                IntegratedSecurity = false,
                UserID = UsuariActiu.sqluser,
                Password = UsuariActiu.sqlpass
            };
        }
    }
}
