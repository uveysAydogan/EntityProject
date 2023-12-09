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
    public partial class frmSystatistic : Form
    {
        public frmSystatistic()
        {
            InitializeComponent();
        }
        EntityProductEntities db = new EntityProductEntities();
        private void frmSystatistic_Load(object sender, EventArgs e)
        {
            label2.Text=db.tbl_Categories.Count().ToString();
            label3.Text=db.tbl_Customers.Count().ToString();
            label5.Text=db.tbl_Customers.Count(x=>x.Status==true).ToString();
            label7.Text=db.tbl_Customers.Count(x=>x.Status==false).ToString();
            label13.Text=db.tbl_Products.Sum(x=>x.Stock).ToString();
            label21.Text=db.tbl_Sales.Sum(x=>x.Price).ToString()+"TL";
            label21.Text=db.tbl_Sales.Sum(x=>x.Price).ToString()+"TL";
            label11.Text=(from x in db.tbl_Products orderby x.Price descending select x.productName +" "+ x.Price).FirstOrDefault();
            label9.Text=(from x in db.tbl_Products orderby x.Price ascending select x.productName +" "+ x.Price).FirstOrDefault();
            label15.Text=db.tbl_Products.Count(y=>y.Category==1).ToString();
            label17.Text=db.tbl_Products.Count(y=>y.productName=="Refrigerator").ToString();
            label23.Text=(from x in db.tbl_Customers select x.City).Distinct().Count().ToString();
            label19.Text = db.proc_getBrand().FirstOrDefault();

        }
    }
}
