using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokemon_TCG_Manager.ClassLibrary
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {

            string projectPath =
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                         .Parent.Parent.Parent.FullName;

            string dbPath = Path.Combine(projectPath, "Cards.accdb"); // change to your db file name

            _connectionString =
                $"Provider=Microsoft.ACE.OLEDB.16.0;Data Source={dbPath}";

            //MessageBox.Show("USING DB: " + dbPath);  // diagnostic
        }



        // general methods

        public DataTable ExecuteQuery(string sql, params object[] parameters)
        {
            DataTable table = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                foreach (var param in parameters)
                    cmd.Parameters.AddWithValue("?", param);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

        public int ExecuteNonQuery(string sql, params object[] parameters)
        {
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                conn.Open();
                foreach (var param in parameters)
                    cmd.Parameters.AddWithValue("?", param);

                return cmd.ExecuteNonQuery();
            }
        }

        public int ExecuteInsertAndReturnId(string sql, params object[] parameters)
        {
            using (var conn = new OleDbConnection(_connectionString))
            using (var cmd = new OleDbCommand(sql, conn))
            {
                conn.Open();

                // Add typed parameters instead of AddWithValue
                    foreach (var param in parameters)
                {
                    if (param is int)
                        cmd.Parameters.Add("?", OleDbType.Integer).Value = param;
                    else if (param is DateTime)
                        cmd.Parameters.Add("?", OleDbType.Date).Value = param;
                    else
                        cmd.Parameters.Add("?", OleDbType.VarWChar).Value = param ?? DBNull.Value;
                }

                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        // USER methods

        public DataTable GetUserByCredentials(string username, string password)
        {
            return ExecuteQuery(
                "SELECT * FROM tblUsers WHERE Username = ? AND Password = ?",
                username, password
            );
        }

        public bool UsernameExists(string username)
        {
            DataTable result = ExecuteQuery(
                "SELECT * FROM tblUsers WHERE Username = ?",
                username
            );
            return result.Rows.Count > 0;
        }

        public int CreateUser(string username, string password)
        {
            // Escape field names that might be reserved words
            return ExecuteInsertAndReturnId(
                "INSERT INTO tblUsers ([Username], [Password]) VALUES (?, ?)",
                username, password
            );
        }


        // card methods
        public DataTable GetAllCards()
        {
            return ExecuteQuery("SELECT * FROM tblCards ORDER BY CardName");
        }

        //  return sets table rows (SetID, SetName)
        public DataTable GetAllSets()
        {
            return ExecuteQuery("SELECT * FROM tblSets ORDER BY SetName");
        }

        public int InsertCard(Card c)
        {
            string sql =
                "INSERT INTO tblCards (SetID, CardNumber, CardName, Rarity, Supertype, Subtype, Health, Price, CardImage) " +
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";

            return ExecuteInsertAndReturnId(
                sql,
                c.SetID,
                c.CardNumber,
                c.CardName,
                c.Rarity,
                c.Supertype,
                c.Subtype,
                c.Health,
                c.Price,
                c.CardImage
            );
        }

        // update existing card
        public int UpdateCard(Card c)
        {
            string sql =
                "UPDATE tblCards SET SetID = ?, CardNumber = ?, CardName = ?, Rarity = ?, Supertype = ?, Subtype = ?, Health = ?, Price = ?, CardImage = ? " +
                "WHERE CardID = ?";

            return ExecuteNonQuery(
                sql,
                c.SetID,
                c.CardNumber,
                c.CardName,
                c.Rarity,
                c.Supertype,
                c.Subtype,
                c.Health,
                c.Price,
                c.CardImage,
                c.CardID
            );
        }

        public void InsertOwnedCard(int userId, int cardId, int quantity)
        {
            ExecuteNonQuery(
                "INSERT INTO tblOwnedCards (UserID, CardID, Quantity) VALUES (?, ?, ?)",
                userId,
                cardId,
                quantity
            );
        }

        public DataTable GetOwnedCards(int userId)
        {
            string sql =
                "SELECT tblCards.*, tblOwnedCards.Quantity " +
                "FROM tblCards INNER JOIN tblOwnedCards " +
                "ON tblCards.CardID = tblOwnedCards.CardID " +
                "WHERE tblOwnedCards.UserID = ? " +
                "ORDER BY tblCards.CardName";

            return ExecuteQuery(sql, userId);
        }

        public void DeleteOwnedCard(int userId, int cardId)
        {
            ExecuteNonQuery(
                "DELETE FROM tblOwnedCards WHERE UserID = ? AND CardID = ?",
                userId,
                cardId
            );
        }

    }
}
