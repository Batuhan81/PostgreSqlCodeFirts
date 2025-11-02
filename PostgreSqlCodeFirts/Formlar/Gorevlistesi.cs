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
                chartControl1.Series["Series 1"].Points.AddPoint("Akdeniz", 10);
                chartControl1.Series["Series 1"].Points.AddPoint("Karadeniz", 34);
                chartControl1.Series["Series 1"].Points.AddPoint("Marmara", 50);
                chartControl1.Series["Series 1"].Points.AddPoint("Güney Doğu Anadolu", 15);
                chartControl1.Series["Series 1"].Points.AddPoint("İç Anadolu", 22);
            }
        }
    }
}
