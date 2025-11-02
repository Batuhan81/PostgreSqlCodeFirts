using DevExpress.XtraEditors;
using PostgreSqlCodeFirts.Classlarım;
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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        private async void FrmPersoneller_Load(object sender, EventArgs e)
        {
            Listele();
            using (var departmanRepo = new Classlarım.GenericRepository<Departman>())
            {
                var departmanlar = await departmanRepo.GetAllAsync();
                lookupDepartman.Properties.DataSource = departmanlar;
                lookupDepartman.Properties.DisplayMember = "Ad";
                lookupDepartman.Properties.ValueMember = "Id";
            }
        }

        async void Listele()
        {
            using (var PersonelRepo = new Classlarım.GenericRepository<Personel>())
            {
                var personeller = await PersonelRepo.GetAllAsync();
                gridControl1.DataSource = personeller.Where(o => o.Aktif == true).OrderBy(d => d.Id).Select(p => new
                {
                    p.Id,
                    p.Ad,
                    p.Soyad,
                    p.Mail,
                    p.Telefon,
                    p.Gorsel,
                    Departman = p.Departman.Ad,
                    p.Aktif
                }).ToList();
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
        static void Temizle(GroupControl group)
        {
            foreach (Control item in group.Controls)
            {
                if (item is TextEdit || item is LookUpEdit)
                {
                    item.Text = "";
                }
            }
        }
        private async void btnEkle_Click(object sender, EventArgs e)
        {
            using (var personelRepo = new GenericRepository<Personel>())
            {
                try
                {
                    personelRepo.BeginTransaction();

                    Personel d = new Personel
                    {
                        Ad = txtAd.Text,
                        Soyad = txtsoyad.Text,
                        Telefon = txttel.Text,
                        Mail = txtMail.Text,
                        Gorsel = txtMail.Text,
                        DepartmanId = Convert.ToInt32(lookupDepartman.EditValue),
                        Aktif = true
                    };
                    await personelRepo.AddAsync(d);

                    personelRepo.Commit();
                    XtraMessageBox.Show("Personel eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    personelRepo.Rollback(); // Önemli!
                    MessageBox.Show("Hata oluştu, işlem geri alındı.");
                    MessageBox.Show(ex.ToString());
                }
            }
            Listele();
            Temizle(groupControl1);
        }

        private async void Btnguncelle_Click(object sender, EventArgs e)
        {
            using (var personelRepo = new GenericRepository<Personel>())
            {
                try
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    personelRepo.BeginTransaction();
                    var personel =await personelRepo.GetByIdAsync(x => x.Id == Id);
                    personel.Ad = txtAd.Text;
                    personel.Soyad = txtsoyad.Text;
                    personel.Telefon = txttel.Text;
                    personel.Mail = txtMail.Text;
                    personel.Gorsel = txtMail.Text;
                    personel.DepartmanId = Convert.ToInt32(lookupDepartman.EditValue);
                    await personelRepo.UpdateAsync(personel);

                    personelRepo.Commit();
                    XtraMessageBox.Show("Personel Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    personelRepo.Rollback(); // Önemli!
                    MessageBox.Show("Hata oluştu, işlem geri alındı.");
                    MessageBox.Show(ex.ToString());
                }
            }
            Listele();
            Temizle(groupControl1);
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Seçili personeli silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            using (var personelRepo = new GenericRepository<Personel>())
            {
                try
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    personelRepo.BeginTransaction();
                    var personel =await personelRepo.GetByIdAsync(x => x.Id == Id);
                    personel.Aktif = false;
                    await personelRepo.UpdateAsync(personel);

                    personelRepo.Commit();
                    XtraMessageBox.Show("Personel Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    personelRepo.Rollback(); // Önemli!
                    MessageBox.Show("Hata oluştu, işlem geri alındı.");
                    MessageBox.Show(ex.ToString());
                }
            }
            Listele();
            Temizle(groupControl1);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
            txtsoyad.Text = gridView1.GetFocusedRowCellValue("Soyad").ToString();
            txttel.Text = gridView1.GetFocusedRowCellValue("Telefon").ToString();
            txtMail.Text = gridView1.GetFocusedRowCellValue("Mail").ToString();
            if (gridView1.GetFocusedRowCellValue("Gorsel") != null)
            {
                txtgorsel.Text = gridView1.GetFocusedRowCellValue("Gorsel").ToString();
            }
            lookupDepartman.Text = gridView1.GetFocusedRowCellValue("Departman").ToString();
        }
    }
}
