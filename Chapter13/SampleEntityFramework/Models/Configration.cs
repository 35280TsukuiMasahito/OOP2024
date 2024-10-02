using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework.Models {
    internal sealed class Configration: DbMigrationsConfiguration<BooksDbContext> {
        public Configration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SampleEntityFramework";
        }
    }
}
