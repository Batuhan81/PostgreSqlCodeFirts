using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSqlCodeFirts.Data
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }

        [Required]            // Boş geçilemez
        [StringLength(20)]    // Maksimum 20 karakter
        public string Ad { get; set; }

        [StringLength(20)]
        public string Soyad { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(100)]
        public string Gorsel { get; set; }

        public bool Aktif { get; set; }

        //Froeign Key
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }
    }
}
