using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Data
{
    public class GorevDetay
    {
        [Key]
        public int Id { get; set; }
        public int GorevId { get; set; }
        public virtual Gorev Gorev { get; set; }

        [StringLength(200)]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}
