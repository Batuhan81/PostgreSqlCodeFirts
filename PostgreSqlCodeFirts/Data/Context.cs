using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Data
{
    public class Context :DbContext
    {
        public Context() : base("name=PostgresBaglanti") { }

        public DbSet<Departman> Departmans { get; set; }
        public DbSet<Personel> Personels { get; set; }
        public DbSet<Firma> Firmas { get; set; }

        public DbSet<Gorev> Gorevs { get; set; }

        public DbSet<GorevDetay> GorevDetays { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
