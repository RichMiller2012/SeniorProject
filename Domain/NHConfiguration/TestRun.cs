using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace Domain
{
    /*
    class Program
    {
        static void Main(string[] args)
        {
            LoadNHibernateCfg();

            Console.ReadKey();
        }

        public static void LoadNHibernateCfg()
        {
            var cfg = new Configuration();
            cfg.Configure();

            Assembly ass = typeof(Account).Assembly;

            cfg.AddAssembly("SeniorProject");
            new SchemaExport(cfg).Execute(true, true, false);
        }
     

    }
     */
}
