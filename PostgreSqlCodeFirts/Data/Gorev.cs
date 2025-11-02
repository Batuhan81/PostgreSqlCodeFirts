using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Data
{
    public class Gorev
    {
        [Key]
        public int Id { get; set; }

        public int Gorevveren { get; set; }
        public virtual Personel GorevverenPersonel { get; set; }

        public int GorevAlan { get; set; }
        public virtual Personel GorevAlanPersonel { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [StringLength(20)]
        public string Durum { get; set; }

        public DateTime Tarih { get; set; }
    }
}
