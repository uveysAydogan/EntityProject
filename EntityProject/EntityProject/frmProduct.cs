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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }

        EntityProductEntities db= new EntityProductEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource=(from x in db.tbl_Products
                                      select new
                                      {
                                          x.productID,
                                          x.productName,
                                          x.Brand,
                                          x.Stock,
                                          x.Price,
                                          x.Status,
                                          x.Category
                                      }).ToList();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            tbl_Products t=new tbl_Products();
            t.productName=txtName.Text;
            t.Brand=txtBrand.Text;
            t.Stock=short.Parse(txtStock.Text);
            t.Price=decimal.Parse(txtPrice.Text);
            t.Status = true;
            t.Category = int.Parse(cmbCategory.SelectedValue.ToString());
            db.tbl_Products.Add(t);
            db.SaveChanges();
            MessageBox.Show("Product has been inserted!");
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt32(txtID.Text);
            var prdc=db.tbl_Products.Find(x);
            db.tbl_Products.Remove(prdc);
            db.SaveChanges();
            MessageBox.Show("Product has been removed!");
            
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            int x= Convert.ToInt32(txtID.Text);
            var updt = db.tbl_Products.Find(x);
            updt.productName = txtName.Text;
            updt.Brand=txtBrand.Text;
            updt.Stock=short.Parse(txtStock.Text);
            db.SaveChanges();
            MessageBox.Show("Product has been updated!");
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            var categories=(from x in db.tbl_Categories
                            select new
                            {
                                x.ID,
                                x.Name
                            }).ToList();
            cmbCategory.ValueMember = "ID";
            cmbCategory.DisplayMember = "Name";
            cmbCategory.DataSource = categories;

        }
    }
}
