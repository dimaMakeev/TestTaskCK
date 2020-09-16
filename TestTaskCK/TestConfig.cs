using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace TestTaskCK
{
    class TestConfig
    {
        public string getBaseUrl()
        {

            var config = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
             .Build();
            return config["BaseUrl"];
        }
    }
}
