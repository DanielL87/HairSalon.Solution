using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Stylist
    {
        private int _id;
        private string _name;

        public Stylist (string name)
        {
          _name = name;  
        }

        //Setters
         public void SetId(int id)
        {
            _id = id;
        }

        //Getters
        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        //Blank___All

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylist (name) VALUES (@StylistName);";

            cmd.Parameters.AddWithValue("@StylistName", this._name);

            cmd.ExecuteNonQuery();   
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

         public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylist;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int stylistId = rdr.GetInt32(0);
                string stylistName = rdr.GetString(1);
                
                Stylist newStylist = new Stylist(stylistName);
                newStylist.SetId(stylistId);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return allStylists;
        }

         public static Stylist FindById(int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylist WHERE id='" + stylistId + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string stylistName="";
             
            while(rdr.Read())
            {
                stylistName = rdr.GetString(1);
            }

            Stylist newStylist = new Stylist(stylistName);
            newStylist.SetId(stylistId);
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return newStylist;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM stylist;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        //Override

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist) otherStylist;
                bool descriptionEquality = (this.GetName() == newStylist.GetName());
                return (descriptionEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }   


    }   
}     