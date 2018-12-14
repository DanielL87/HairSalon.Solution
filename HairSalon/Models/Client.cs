using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Client
    {
        
        private int _id;
        private string _name;
        private int _stylistId;

    public Client (string name, int stylistId)
        {
            _name = name;
            _stylistId = stylistId;
        }

     public void SetId(int id)
        {
            _id = id;
        }

        //Getters

        public string GetName()
        {
            return _name;
        }

        public int GetStylistId()
        {
            return _stylistId;
        }

        public int GetId()
        {
            return _id;
        }

         public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM client;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);

                Client newClient = new Client(clientName, stylistId);
                newClient.SetId(clientId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return allClients;
        }

         public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO client (name, stylistId) VALUES (@ClientName, @StylistId);";

            cmd.Parameters.AddWithValue("@ClientName", this._name);
            cmd.Parameters.AddWithValue("@StylistId", this._stylistId);

            cmd.ExecuteNonQuery();   
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        //Finders

         public static Client FindById(int clientId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM client WHERE id='" + clientId + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string clientName="";
            int stylistId=0;
             
            while(rdr.Read())
            {
                clientName = rdr.GetString(1);
                stylistId = rdr.GetInt32(2);
            }

            Client newClient = new Client(clientName, stylistId);
            newClient.SetId(clientId);
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return newClient;
        }

         public static List<Client> FindByStylistId(int stylistId)
        {
            List<Client> clientsByStylist = new List<Client>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM client WHERE stylistId='" + stylistId + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                string clientName = rdr.GetString(1);
                int clientStylistId = rdr.GetInt32(2);
                Client newClient = new Client(clientName, clientStylistId);
                clientsByStylist.Add(newClient);
            }

            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return clientsByStylist;
        }


    //Override
        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client) otherClient;
                bool areIdsEqual = (this.GetId() == newClient.GetId());
                bool areNamesEqual = (this.GetName() == newClient.GetName());
                bool areStylistsEqual = (this.GetStylistId() == newClient.GetStylistId());
                return (areIdsEqual && areNamesEqual && areStylistsEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM client;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}        