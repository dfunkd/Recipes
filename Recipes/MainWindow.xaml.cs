using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Recipes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var settings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.CurrentConfiguration.ConnectionStrings.ConnectionStrings;
            //if (settings["RecipesModel"] != null)
            //{
            //    if (settings["RecipesModel"].ConnectionString.IndexOf("password") == -1)
            //    {
            //        settings["RecipesModel"].ConnectionString = "data source=dfunkd.database.windows.net;Trusted_Connection=False;Persist Security Info=True;initial catalog=MediaInventory;user id=dylanpfunk4;password=Samuelxf1104!;MultipleActiveResultSets=True;App=EntityFramework;";
            //        ConfigurationManager.RefreshSection("connectionStrings");
            //        var test = settings["RecipesModel"].ConnectionString;
            //        using (var db = new Data.RecipesModel())
            //        {

            //            var test2 = db.Ingredients.ToList();
            //        }
            //    }
            //}

            //Database.SetInitializer<Data.RecipesModel>(null);
            using (var db = new Data.RecipesModel())
            {
                var test2 = db.Ingredients.ToList();
            }

            //if (string.IsNullOrWhiteSpace(Properties.Settings.Default.DbPassword))
            //{
            //    if (!string.IsNullOrWhiteSpace(ConfigurationManager.ConnectionStrings["RecipesModel"].ConnectionString))
            //    {
            //        if (ConfigurationManager.ConnectionStrings["RecipesModel"].ConnectionString.IndexOf("password") == -1)
            //        {
            //            DbPasswordSetup setup = new DbPasswordSetup();
            //            setup.ShowDialog();
            //            if (setup.Result != MessageBoxResult.OK)
            //                Application.Current.Shutdown();
            //            Properties.Settings.Default.Upgrade();
            //        }
            //    }
            //}
            //else
            //{
            //    if (ConfigurationManager.ConnectionStrings["RecipesModel"].ConnectionString.IndexOf("password") == -1)
            //    {
            //        CreateEntity();
            //        //ConfigurationManager.ConnectionStrings["RecipesModel"].ConnectionString += string.Format("password={0}", Properties.Settings.Default.DbPassword);
            //    }
            //}
        }
        private void CreateEntity()
        {
            // Specify the provider name, server and database.
            string providerName = "System.Data.SqlClient";
            string serverName = "data source=dfunkd.database.windows.net;initial catalog=MediaInventory;user id=dylanpfunk4;MultipleActiveResultSets=True;App=EntityFramework";
            string databaseName = "RecipesModel";
            // Initialize the connection string builder for the underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;
            // Build the SqlConnection connection string.
            string providerString = sqlBuilder.ToString();
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            //Set the provider name.
            entityBuilder.Provider = providerName;
            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = providerString;
            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/RecipesModel.csdl|res://*/RecipesModel.ssdl|res://*/RecipesModel.msl";
            Console.WriteLine(entityBuilder.ToString());
            using (EntityConnection conn = new EntityConnection(entityBuilder.ToString()))
            {
                conn.Open();
                Console.WriteLine("Just testing the connection.");
                conn.Close();
            }
        }
    }
}
