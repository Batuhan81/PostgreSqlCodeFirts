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
    public partial class FrmDepartmanlar : Form
    {
        public FrmDepartmanlar()
        {
            InitializeComponent();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        async void Listele()
        {
            using (var departmanRepo = new Classlarım.GenericRepository<Departman>())
            {
                var departmanlar = await departmanRepo.GetAllAsync();
                gridControl1.DataSource = departmanlar.Where(o=>o.Aktif).OrderBy(d=>d.Id).ToList();
            }
        }

        private void FrmDepartmanlar_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            using (var departmanRepo = new GenericRepository<Departman>())
            {
                try
                {
                    departmanRepo.BeginTransaction();

                    Departman d = new Departman
                    {
                        Ad = txtAd.Text,
                        Aktif = true
                    };
                    await departmanRepo.AddAsync(d);

                    departmanRepo.Commit();
                    XtraMessageBox.Show("Departman eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    departmanRepo.Rollback(); // Önemli!
                    MessageBox.Show("Hata oluştu, işlem geri alındı.");
                    MessageBox.Show(ex.ToString());
                }
            }

            Listele();
        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Seçili departmanı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;
            using (var departmanRepo = new GenericRepository<Departman>())
            {
                int Id = Convert.ToInt32(txtId.Text);
                await departmanRepo.DeleteAsync(x => x.Id == Id);
                XtraMessageBox.Show("Departman Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtId.Text = gridView1.GetFocusedRowCellValue("Id").ToString();
            txtAd.Text = gridView1.GetFocusedRowCellValue("Ad").ToString();
        }

        private async void Btnguncelle_Click(object sender, EventArgs e)
        {
            using (var departmanRepo = new GenericRepository<Departman>())
            {
                try
                {
                    int Id = Convert.ToInt32(txtId.Text);
                    departmanRepo.BeginTransaction();
                    var x =await departmanRepo.GetByIdAsync(a => a.Id == Id);
                    x.Ad = txtAd.Text;
                    await departmanRepo.UpdateAsync(x);

                    departmanRepo.Commit();
                    XtraMessageBox.Show("Departman Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    departmanRepo.Rollback(); // Önemli!
                    MessageBox.Show("Hata oluştu, işlem geri alındı.");
                    MessageBox.Show(ex.ToString());
                }
            }
            Listele();
        }
    }
}
