using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using Domain.NHConfiguration;

namespace Domain.NHConfiguration
{
    public class TestRunner
    {
        public static void run()
        {
            LoadNHibernateCfg();
            Seeds seeds = new Seeds();
            seeds.setupDB();
        }

        public static void LoadNHibernateCfg()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            
            cfg.Configure();
            cfg.AddAssembly("BricknMortarSystem");
            new SchemaExport(cfg).Execute(true, true, false);
        }
    }
}
