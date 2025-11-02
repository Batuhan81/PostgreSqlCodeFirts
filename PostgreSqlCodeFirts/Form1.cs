using PostgreSqlCodeFirts.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSqlCodeFirts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new Context())
            {
                // Veritabanı var mı kontrol eder, yoksa oluşturur.
                if (!db.Database.Exists())
                {
                    db.Database.Create();
                    MessageBox.Show("Veritabanı oluşturuldu!");
                }
                else
                {

                }
            }
        }
        Formlar.FrmDepartmanlar frm;
        Formlar.FrmPersoneller frm2;
        Formlar.FrmPersonelIstatistik frm3;
        Formlar.Gorevlistesi frm4;
        Formlar.FrmGorevDetay frm5;
        Formlar.AnaForm frm6;
        private void DepartmanList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null||frm.IsDisposed)
            {
                frm = new Formlar.FrmDepartmanlar();
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null||frm2.IsDisposed)
            {
                frm2 = new Formlar.FrmPersoneller();
                frm2.MdiParent = this;
                frm2.Show();

            }
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {
                frm3 = new Formlar.FrmPersonelIstatistik();
                frm3.MdiParent = this;
                frm3.Show();
            }

        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {
                frm4 = new Formlar.Gorevlistesi();
                frm4.MdiParent = this;
                frm4.Show();
            }
        }

        private void GorevDetaybtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {
                frm5 = new Formlar.FrmGorevDetay();
                frm5.Show();
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm6 == null || frm5.IsDisposed)
            {
                frm6 = new Formlar.AnaForm();
                frm6.MdiParent = this;
                frm6.Show();
            }
        }
    }
}
