using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace WpfDi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var collection = new ServiceCollection();

            collection.AddScoped<TestClass>();
            collection.AddTransient<MainWindow>();

            var provider = collection.BuildServiceProvider();
            var mainWindow = provider.GetRequiredService<MainWindow>();
            MainWindow.Show();
        }
    }
}
