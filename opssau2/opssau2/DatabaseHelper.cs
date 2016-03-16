using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace opssau2
{
    public class DatabaseHelper
    {
        private static string GetConnectionString()
        {
            return WebConfigurationManager.ConnectionStrings["OPSSAU_CONNECTION_STRING"].ConnectionString;
        }

        public static bool ContainsCity(string cityName)
        {
            cityName = Char.ToUpper(cityName[0]) + cityName.Substring(1).ToLower();
            const string strSelect = "Select COUNT(*) From Город Where Город.Название=@name";

            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(strSelect, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@name", cityName);
                    conn.Open();
                    
                    var response = (int)cmd.ExecuteScalar();
                    conn.Close();

                    return response > 0;
                }
            }
        }

        public static void InsertCity(string name)
        {
            name = Char.ToUpper(name[0]) + name.Substring(1).ToLower();
            string SqlString = "Insert Into Город (Название) Values (?)";

            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(SqlString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Название", name);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public static int InsertPersonAndReturnId(string name, bool isCaptain, string email, string phone)
        {
            string insertCaptainString = "Insert Into Участник (ФИО, Капитан, Почта, Телефон) Values (?, ?, ?, ?)";
            string insertUsualString = "Insert Into Участник (ФИО, Капитан) Values (?, ?)";
            string selectString = "SELECT MAX(g.Код) FROM Участник g WHERE g.ФИО=@name;";
            int result;
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(isCaptain ? insertCaptainString : insertUsualString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("ФИО", name);
                    cmd.Parameters.AddWithValue("Капитан", isCaptain);
                    if (isCaptain)
                    {
                        cmd.Parameters.AddWithValue("Почта", email);
                        cmd.Parameters.AddWithValue("Телефон", phone);
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                using (OleDbCommand cmd = new OleDbCommand(selectString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@name", name);
                    result = (int) cmd.ExecuteScalar();
                }
                conn.Close();
            }
            return result;
        }

        public static void InsertTeam(string name, string captain, string second, string third, string city, string mail)
        {
            string insertString = "Insert Into Команда (Название, Капитан, Второй, Третий, Город) Values (?, ?, ?, ?, ?, ?)";
            using (OleDbConnection conn = new OleDbConnection(GetConnectionString()))
            {
                using (OleDbCommand cmd = new OleDbCommand(insertString, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("Название", name);
                    cmd.Parameters.AddWithValue("Капитан", captain);
                    cmd.Parameters.AddWithValue("Второй", second);
                    cmd.Parameters.AddWithValue("Третий", third);
                    cmd.Parameters.AddWithValue("Город", city);
                    cmd.Parameters.AddWithValue("Почта", mail);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    }
}