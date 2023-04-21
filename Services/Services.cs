using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyContacts
{
    internal class Services : IServices
    {
        ContactETEntities db = new ContactETEntities();

        public bool edit(int id, string Name, string Family, string Mobile, string Email, string Address)
        {
            try
            {
                var currentContact = db.contacsReps.Where(p => p.ID == id).ToList()[0];
                currentContact.Name = Name;
                currentContact.Family = Family;
                currentContact.Mobile = Mobile;
                currentContact.Email = Email;
                currentContact.Address = Address;
                db.SaveChanges();
                
                return true;
            }
            catch { return false; }

        }

        public bool insert(string Name, string Family, string Mobile, string Email, string Address)
        {
            try
            {

                var contacts = db.contacsReps.ToList();

                contacsRep p1 = new contacsRep()
                {
                    Name = Name,
                    Family = Family,
                    Mobile = Mobile,
                    Email = Email,
                    Address = Address
                };
                db.contacsReps.Add(p1);
                db.SaveChanges();
                MessageBox.Show("Submitted");
                return true;
            }
            catch
            {
                MessageBox.Show("Something went wrong :(");
                return false;
            }
        }

        public bool remove(int id)
        {
            try
            {
                var p1 = db.contacsReps.Where(p => p.ID == id).ToList()[0];
                string fullName = p1.Name + " " + p1.Family;

                if (MessageBox.Show($"{fullName} will be deleted.", "Warning", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    db.contacsReps.Remove(p1);
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<contacsRep> search(string key)
        {
            return db.contacsReps.Where(p =>  p.Name.Contains(key) || p.Family.Contains(key)).ToList();
        }

        public List<contacsRep> selectAll()
        {
            return db.contacsReps.ToList();
        }

        public List<contacsRep> selectById(int id)
        {
            return db.contacsReps.Where(p => p.ID == id ).ToList();
        }
    }
}
