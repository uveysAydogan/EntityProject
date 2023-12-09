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
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityProductEntities db= new EntityProductEntities();
            var query=from x in db.tbl_Admin where x.userName==textBox1.Text && x.Password==textBox2.Text select x;
            if(query.Any())
            {
                frmMainForm fmf= new frmMainForm();
                fmf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Icorrect username or password!Plesae try again.");
            }
        }
    }
}
