using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Domain.NHConfiguration
{
    public class TestRunner
    {
        public static void Main(string[] args)
        {
            LoadNHibernateCfg();
            Console.ReadKey();

        }

        public static void LoadNHibernateCfg()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            
            cfg.Configure();
            cfg.AddAssembly("Domain");
            new SchemaExport(cfg).Execute(true, true, false);
        }
    }
}
