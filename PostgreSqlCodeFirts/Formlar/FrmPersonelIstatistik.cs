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
    public partial class FrmPersonelIstatistik : Form
    {
        public FrmPersonelIstatistik()
        {
            InitializeComponent();
        }

        private async void FrmPersonelIstatistik_Load(object sender, EventArgs e)
        {
            using(var departmanRepo=new Classlarım.GenericRepository<Departman>())
            using(var FirmaRepo=new Classlarım.GenericRepository<Firma>())
            using(var personelRepo=new Classlarım.GenericRepository<Personel>())
            {
                try
                {
                    var departmanlar = await departmanRepo.GetAllAsync();
                    toplamDepartman.Text = departmanlar.Count(d => d.Aktif).ToString();

                    var personeller = await personelRepo.GetAllAsync();
                    lbltoplamPersonel.Text = personeller.Count(d => d.Aktif).ToString();

                    var Firmalar = await FirmaRepo.GetAllAsync();
                    topllamFirma.Text = Firmalar.Count().ToString();
                }
                catch
                {
                    ;
                }
                
            }
        }

        private void panelControl6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
