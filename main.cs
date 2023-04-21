using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class MyContacts : Form
    {
        IServices services;
            
    

        public MyContacts()
        {
            InitializeComponent();
        }

        private void MyContacts_Load(object sender, EventArgs e)
        {
            services = new Services();
            bindGrid();
        }

        private void bindGrid()
        {
           
            dgContacts.AutoGenerateColumns = false;
            dgContacts.DataSource = services.selectAll();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            addOrEdit add = new addOrEdit();
            add.Text = "Add";
            add.ShowDialog();
            bindGrid();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow != null)
            {
                addOrEdit edit = new addOrEdit();
                edit.Text = "Edit";
                edit.currentID = (int)dgContacts.CurrentRow.Cells[0].Value;
                edit.ShowDialog();
                bindGrid();
                
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if(dgContacts.CurrentRow != null)
            {
                
                services.remove((int)dgContacts.CurrentRow.Cells[0].Value);
                bindGrid();
            }
            else
            {
                MessageBox.Show("Please choose a contacts first");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgContacts.DataSource = services.search(textBox1.Text);
            

        }
    }
}
