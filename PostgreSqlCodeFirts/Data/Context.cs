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
        public DbSet<Departman> Departman { get; set; }
    }
}
