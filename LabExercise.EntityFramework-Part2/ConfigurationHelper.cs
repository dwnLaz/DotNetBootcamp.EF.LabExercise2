using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExercise.EntityFramework_Part2
{
    internal class ConfigurationHelper
    {
        private static ConfigurationHelper? instance;

        private ConfigurationHelper()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        public T GetProperty<T>(string propertyName)
        {
            return this.Configuration.GetValue<T>(propertyName);
        }

        public T GetConfiguration<T>()
        {
            var section = this.Configuration.GetSection(typeof(T).Name);
            var config = section.Get<T>();
            return config;
        }


        public static ConfigurationHelper Instance()
        {
            if (instance == null)
            {
                instance = new ConfigurationHelper();
            }

            return instance;
        }
    }
}
