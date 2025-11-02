using PostgreSqlCodeFirts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSqlCodeFirts.Formlar
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private async  void AnaForm_Load(object sender, EventArgs e)
        {
            using (var gorevRepo = new Classlarım.GenericRepository<Gorev>())
            using (var gorevdetayRepo = new Classlarım.GenericRepository<GorevDetay>())
            {
                // Tüm görevleri, hem görev veren hem de görev alan personeli dahil ederek çekiyoruz
                var gorevler = await gorevRepo.GetAllAsync(
                    null, // filtre yok, tüm kayıtlar
                    g => g.GorevverenPersonel,
                    g => g.GorevAlanPersonel
                );

                // Grid'e aktarırken sadece gerekli alanları seçiyoruz
                var liste = gorevler
                    .Where(o=>o.Durum=="0")
                    .Select(g => new
                    {
                        g.Id,
                        GorevVeren = g.GorevverenPersonel.Ad + " " + g.GorevverenPersonel.Soyad,
                        GorevAlan = g.GorevAlanPersonel.Ad + " " + g.GorevAlanPersonel.Soyad,
                        g.Aciklama,
                        g.Durum,
                        g.Tarih
                    })
                    .OrderByDescending(x => x.Tarih) // Tarihe göre sıralama
                    .ToList();

                gridControl1.DataSource = liste;

                DateTime bugun = DateTime.Today;
                var detaylar = await gorevdetayRepo.GetAllAsync();
                gridControl2.DataSource = detaylar
                    .Select(d => new
                    {
                        d.Id,
                        d.Aciklama,
                        d.Tarih
                    })
                    .OrderByDescending(x => x.Tarih==bugun)
                    .ToList();
            }
        }
    }
}
