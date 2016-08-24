using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Recipes
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var settings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).ConnectionStrings.CurrentConfiguration.ConnectionStrings.ConnectionStrings;
            if (settings["RecipesModel"] != null)
            {
                if (settings["RecipesModel"].ConnectionString.IndexOf("password") == -1)
                {
                    settings["RecipesModel"].ConnectionString = "data source=dfunkd.database.windows.net;Trusted_Connection=False;Persist Security Info=True;initial catalog=MediaInventory;user id=dylanpfunk4;password=Samuelxf1104!;MultipleActiveResultSets=True;App=EntityFramework;";
                    ConfigurationManager.RefreshSection("connectionStrings");
                    var test = settings["RecipesModel"].ConnectionString;
                }
            }
        }
    }
}
