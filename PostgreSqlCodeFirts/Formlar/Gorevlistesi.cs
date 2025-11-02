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
    public partial class Gorevlistesi : Form
    {
        public Gorevlistesi()
        {
            InitializeComponent();
        }

        private void Gorevlistesi_Load(object sender, EventArgs e)
        {
            Listele();
            
        }
        async void Listele()
        {
            using (var GorevRepo = new Classlarım.GenericRepository<Gorev>())
            {
                var gorevler = await GorevRepo.GetAllAsync();
                gridControl1.DataSource = gorevler.OrderBy(d => d.Id).Select(o=>o.Aciklama).ToList();
                int aktifgorev = gorevler.Count(d => d.Durum == "1");
                int pasifgorev = gorevler.Count(d => d.Durum == "0");
                chartControl1.Series["Durum"].Points.AddPoint("Aktif Görevler", aktifgorev);
                chartControl1.Series["Durum"].Points.AddPoint("Pasif Görevler", pasifgorev);
               
            }
        }
    }
}
