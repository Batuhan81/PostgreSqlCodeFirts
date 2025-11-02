using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Data
{
    public class Firma
    {
        [Key]   
        public int Id { get; set; }

        [StringLength(30)]
        public string Ad { get; set; }

        [StringLength(20)]
        public string Yetkili { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(30)]
        public string Mail { get; set; }

        [StringLength(20)]
        public string Sektor { get; set; }

        [StringLength(20)]
        public string Il { get; set; }

        [StringLength(30)]
        public string Ilce { get; set; }

        [StringLength(200)]
        public string Adres { get; set; }
    }
}
