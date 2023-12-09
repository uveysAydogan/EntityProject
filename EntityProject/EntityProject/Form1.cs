using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EntityProductEntities db=new EntityProductEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var Categories = db.tbl_Categories.ToList();//var veri tipini kullanma sebebi her hangi bir veri tipinden veri gelme ihtimaldir.
            dataGridView1.DataSource = Categories;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            tbl_Categories t=new tbl_Categories();
            t.Name=textBox2.Text;
            db.tbl_Categories.Add(t);
            db.SaveChanges();
            MessageBox.Show("Category has been inserted!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int dl=Convert.ToInt32(textBox1.Text);
            var ctgr = db.tbl_Categories.Find(dl);
            db.tbl_Categories.Remove(ctgr);
            db.SaveChanges();
            MessageBox.Show("Category has been deleted!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int up=Convert.ToInt32(textBox1.Text);
            var ctgr=db.tbl_Categories.Find(up);
            ctgr.Name = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Category has been updated!");
        }
    }
}
