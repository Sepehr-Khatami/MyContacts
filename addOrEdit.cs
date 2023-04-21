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
    public partial class addOrEdit : Form
    {
        IServices services;


        public addOrEdit()
        {
            InitializeComponent();

        }
        public int currentID = 0;

        private void addOrEdit_Load(object sender, EventArgs e)
        {
            services = new Services();
            if (currentID != 0)
            {
                var currentContact = services.selectById(currentID);
                txtName.Text = currentContact[0].Name.ToString();
                txtFamily.Text = currentContact[0].Family.ToString();
                txtMobile.Text = currentContact[0].Mobile.ToString();
                txtEmail.Text = currentContact[0].Email.ToString();
                txtAddress.Text = currentContact[0].Address.ToString();

            }


        }

        private bool Validator()

        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Name can not be empty!");
                return false;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("Mobile can not be empty!");
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validator())
            {
                if (currentID == 0)
                {
                    if (services.insert
                        (
                        txtName.Text,
                        txtFamily.Text,
                        txtMobile.Text,
                        txtEmail.Text,
                        txtAddress.Text
                        ))
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        DialogResult = DialogResult.None;
                    }
                }
                if (currentID != 0)
                {

                    services.edit(currentID, txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text);

                    DialogResult = DialogResult.OK;
                }

            }

        }

    }
}
