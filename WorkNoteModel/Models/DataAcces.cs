using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WorkNoteModel.Models
{
    public class DataAcces
    {
        string conectionName = ConfigurationManager.ConnectionStrings["WorkNote"].ConnectionString;

        public SqlCommand InitializeSP(string SP_NAME)
        {
            SqlConnection conn = new SqlConnection(conectionName);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = SP_NAME;
            cmd.Connection = conn;
            return cmd;
        }

        public List<Acces> GetAcces()
        {
            List<Acces> AccesList = null;

            using (SqlCommand cmd = InitializeSP("Acces.SP_GetAcces"))
            {
                try
                {
                cmd.Connection.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Acces acces = new Acces();
                    acces.IdAcces = dataReader.GetInt32(dataReader.GetOrdinal("idAcces"));
                    acces.Name = dataReader.GetString(dataReader.GetOrdinal("name"));
                    acces.Ip = dataReader.GetString(dataReader.GetOrdinal("ip"));
                    acces.Adrees = dataReader.GetString(dataReader.GetOrdinal("adrees"));
                    acces.Type = dataReader.GetInt32(dataReader.GetOrdinal("type"));
                    acces.Note = dataReader.GetString(dataReader.GetOrdinal("note"));
                    acces.IdSource = dataReader.GetInt32(dataReader.GetOrdinal("idSource"));
                    acces.Date = dataReader.GetString(dataReader.GetOrdinal("date"));
       
                    AccesList.Add(acces);
                }
                cmd.Connection.Close();
                }
                catch(Exception error)
                {
                    Console.WriteLine(error.Message);
                }
                return AccesList;
            }
        }

        public List<AccesType> GetType()
        {
            List<AccesType> typeList = new List<AccesType>();

            using (SqlCommand cmd = InitializeSP("Acces.SP_GetType"))
            {
                try
                {
                    cmd.Connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        AccesType type = new AccesType();
                        type.IdType = dataReader.GetByte(dataReader.GetOrdinal("idType"));
                        type.Name = dataReader.GetString(dataReader.GetOrdinal("name"));

                        typeList.Add(type);
                    }
                    cmd.Connection.Close();
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
                return typeList;
            }
        }

        public string AddAcces(Acces acces)
        {
            string mensaje = "";
            try
            {
                using (SqlCommand cmd = InitializeSP("Acces.SP_Insert_Acces"))
                {
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@name", acces.Name);
                    cmd.Parameters.AddWithValue("@ip", acces.Ip);
                    cmd.Parameters.AddWithValue("@adrees", acces.Adrees);
                    cmd.Parameters.AddWithValue("@idType", acces.Type);
                    cmd.Parameters.AddWithValue("@note", acces.Note);
                    cmd.Parameters.AddWithValue("@idSource", acces.IdSource);
                    cmd.ExecuteReader();
                    cmd.Connection.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return mensaje;
        }
    }
}
