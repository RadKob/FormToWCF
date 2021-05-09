using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjectWCF
{
    public class Service1 : IService1
    {
        public Service1()
        {
            ConnectionToBazaTestowa();
        }

        SqlConnection conn;
        SqlCommand cmd;

        SqlConnectionStringBuilder connStrB;

        public void ConnectionToBazaTestowa()
        {
            connStrB = new SqlConnectionStringBuilder();
            connStrB.DataSource = @"DESKTOP-KG6NVAH\MSEXPRESS";
            connStrB.InitialCatalog = "BazaTestowa";
            connStrB.Encrypt = true;
            connStrB.TrustServerCertificate = true;
            connStrB.ConnectTimeout = 30;
            connStrB.AsynchronousProcessing = true;
            connStrB.MultipleActiveResultSets = true;
            connStrB.IntegratedSecurity = true;

            conn = new SqlConnection(connStrB.ToString());
            cmd = conn.CreateCommand();
        }
        public int InsertPersonToDB(Person person)
        {
            try
            {
            cmd.CommandText = "insert into Users (ID, Name, Surname, Email) values (@ID, @Name, @Surname, @Email)";
            cmd.Parameters.AddWithValue("ID",person.ID);
            cmd.Parameters.AddWithValue("Name",person.Name);
            cmd.Parameters.AddWithValue("Surname",person.Surname);
            cmd.Parameters.AddWithValue("Email",person.Email);
            cmd.CommandType = CommandType.Text;
            conn.Open();
            return cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public int UpdatePersonToDB(Person person)
        {
            try
            {
                cmd.CommandText = "update Users set Name=@Name, Surname=@Surname, Email=@Email where ID=@ID";
                cmd.Parameters.AddWithValue("ID", person.ID);
                cmd.Parameters.AddWithValue("Name", person.Name);
                cmd.Parameters.AddWithValue("Surname", person.Surname);
                cmd.Parameters.AddWithValue("Email", person.Email);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public int DeletePersonToDB(Person person)
        {
            try
            {
                cmd.CommandText = "delete Users where ID=@ID";
                cmd.Parameters.AddWithValue("ID", person.ID);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public Person SelectPersonToDB(Person person)
        {
            Person p = new Person();
            try
            {
                cmd.CommandText = "select * from Users where ID=@ID";
                cmd.Parameters.AddWithValue("ID",person.ID);
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    person.ID = Convert.ToInt32(reader[0]);
                    person.Name = reader[1].ToString();
                    person.Surname = reader[2].ToString();
                    person.Email = reader[3].ToString();
                }
                return person;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public List<Person> SelectAllPersonToDB()
        {
            List<Person> personL = new List<Person>();
            try
            {
                cmd.CommandText = "select * from Users";
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Person p = new Person()
                    {
                        ID = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Email = reader[3].ToString(),
                    };
                    personL.Add(p);
                }
                return personL;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
