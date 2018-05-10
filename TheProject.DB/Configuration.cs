﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;

namespace TheProject.DB
{
   public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            SetDefaultConnectionFactory(
                new LocalDbConnectionFactory("MYSQLLocalDB"));
        }
    }
}
