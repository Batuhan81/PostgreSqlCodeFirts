using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Data
{
    public class Departman
    {
        [Key]   
        public int Id { get; set; }

        [Required]           
        [StringLength(20)]
        public string Ad { get; set; }

        public bool Aktif { get; set; }
    }
}
