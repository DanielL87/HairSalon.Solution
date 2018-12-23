using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;

namespace HairSalon.Models
{
    public class Specialty
    {
        private int _id;
        private string _description;

        public Specialty(string description, int id=0)
        {
            _id = id;
            _description = description;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetDescription()
        {
            return _description;
        }

           public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialtys = new List<Specialty>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialty;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int specialtyId = rdr.GetInt32(0);
                string specialtyDescription = rdr.GetString(1);
                

                Specialty newSpecialty = new Specialty(specialtyDescription);
                newSpecialty.SetId(specialtyId);
                allSpecialtys.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return allSpecialtys;
        }

        public static Specialty FindById(int specialtyId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialty WHERE id='" + specialtyId + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string specialtyName="";
             
            while(rdr.Read())
            {
                specialtyName = rdr.GetString(1);
            }

            Specialty foundSpecialty = new Specialty(specialtyName);
            foundSpecialty.SetId(specialtyId);
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return foundSpecialty;
        }

         public void AddStylist(Stylist newStylist)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylist_specialty (stylist_id, specialty_id) VALUES (@StylistsId, @SpecialtyId);";
            
            MySqlParameter Stylists_id = new MySqlParameter();
            Stylists_id.ParameterName = "@StylistsId";
            Stylists_id.Value = _id;
            cmd.Parameters.Add(Stylists_id);

            MySqlParameter Specialty_id = new MySqlParameter();
            Specialty_id.ParameterName = "@SpecialtyId";
            Specialty_id.Value = newStylist.GetId();
            cmd.Parameters.Add(Specialty_id);
        
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public List<Stylist> GetStylists()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylist.* FROM specialty
                JOIN stylist_specialty ON (specialty.id = stylist_specialty.specialty_id)
                JOIN stylist ON (stylist_specialty.stylist_id = stylist.id)
                WHERE specialty.id = @specialtyId;";
            MySqlParameter specialtiesIdParameter = new MySqlParameter();
            specialtiesIdParameter.ParameterName = "@specialtyId";
            specialtiesIdParameter.Value = _id;
            cmd.Parameters.Add(specialtiesIdParameter);
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            List<Stylist> Stylists = new List<Stylist>{};
            while(rdr.Read())
            {
            int StylistId = rdr.GetInt32(0);
            string StylistName = rdr.GetString(1);
            Stylist newStylist = new Stylist(StylistName);
            Stylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return Stylists;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialty (description) VALUES (@Description);";

            cmd.Parameters.AddWithValue("@Description", this._description);
            

            cmd.ExecuteNonQuery();   
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

          //Override
        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty) otherSpecialty;
                bool areIdsEqual = (this.GetId() == newSpecialty.GetId());
                bool areDescriptionsEqual = (this.GetDescription() == newSpecialty.GetDescription());
                return (areIdsEqual && areDescriptionsEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetDescription().GetHashCode();
        }



        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialty;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


    }
}