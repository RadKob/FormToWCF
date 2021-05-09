using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FormToWCF.ServiceReference1;

namespace FormToWCF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            ServiceReference1.Person person = new ServiceReference1.Person();
            person.ID = Convert.ToInt32(txtID.Text);
            person.Name = txtName.Text;
            person.Surname = txtSurname.Text;
            person.Email = txtEmail.Text;
            Service1Client service = new Service1Client();
            if (service.InsertPersonToDB(person) == 1)
            {
                MessageBox.Show("Insert Success");
            }
            else
            {
                MessageBox.Show("Insert Error");
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            ServiceReference1.Person person = new ServiceReference1.Person()
            {
                ID = Convert.ToInt32(txtID.Text),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
            };
            Service1Client service = new Service1Client();
            if (service.UpdatePersonToDB(person) == 1)
            {
                MessageBox.Show("Update Success");
            }
            else
            {
                MessageBox.Show("Update Error");
            }
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            ServiceReference1.Person person = new ServiceReference1.Person()
            {
                ID = Convert.ToInt32(txtID.Text) 
            };
            Service1Client service = new Service1Client();
            if (service.DeletePersonToDB(person) == 1)
            {
                MessageBox.Show("Delete Success");
            }
            else
            {
                MessageBox.Show("Delete Error");
            }
        }
        private void btnselect_Click(object sender, EventArgs e)
        {
            List<Person> personL = new List<Person>();
            Person person = new Person()
            {
                ID = Convert.ToInt32(txtID.Text)
            };
            Service1Client service = new Service1Client();
            personL.Add(service.SelectPersonToDB(person));
            arena.DataSource = personL;
        }

        private void btnallselect_Click(object sender, EventArgs e)
        {
            List<Person> personL = new List<Person>();
            Service1Client service = new Service1Client();

            arena.DataSource = service.SelectAllPersonToDB();
        }
    }
}
