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
                    MessageBox.Show("Veritabanı zaten mevcut!");
                }
            }
        }
    }
}
