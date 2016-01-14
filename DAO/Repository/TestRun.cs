using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;
using Domain.Entities;

namespace DAO.Repository
{
    class TestRun
    {
        static void Main(string[] args)
        {
            LoadNHibernateCfg();

            using (RepositoryBase repository = new RepositoryBase())
            {
                repository.beginTransaction();

                Store store = new Store() { name = "The New Store" };
                Store store2 = new Store() { name = "Another Store" };
                Store store3 = new Store() { name = "The Third Store" };

                repository.save(store);
                repository.save(store2);
                repository.save(store3);
            }
            

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
}
