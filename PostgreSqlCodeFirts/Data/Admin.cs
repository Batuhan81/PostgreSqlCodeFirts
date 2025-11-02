using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Data
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string KullaniciAd { get; set; }

        [StringLength(10)]
        public string Sifre { get; set; }
    }
}
