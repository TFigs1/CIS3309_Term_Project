using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageTutor.ClassLibrary
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {

            string projectPath =
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                         .Parent.Parent.Parent.FullName;

            string dbPath = Path.Combine(projectPath, "LanguageTutor.accdb"); // change to your db file name

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
            using (OleDbConnection conn = new OleDbConnection(_connectionString))
            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                conn.Open();

                foreach (var param in parameters)
                    cmd.Parameters.AddWithValue("?", param);

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT @@IDENTITY";
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        // lesson tutor specific methods
        //public DataTable GetAllLessons()
        //{
        //    return ExecuteQuery("SELECT * FROM Lessons");
        //}

        //public DataTable GetLessonItems(int lessonId)
        //{
        //    return ExecuteQuery(
        //        "SELECT * FROM LessonItems WHERE LessonId = ?",
        //        lessonId
        //    );
        //}

        //public int InsertLesson(string title, string topic, string description, int minutes)
        //{
        //    return ExecuteInsertAndReturnId(
        //        "INSERT INTO Lessons (Title, Topic, Description, EstimatedMinutes, Completed, LastGrade) VALUES (?, ?, ?, ?, ?, ?)",
        //        title, topic, description, minutes, false, 0.0
        //    );
        //}

        //public void InsertLessonItem(int lessonId, string prompt, string answer, string imageUrl)
        //{
        //    ExecuteNonQuery(
        //        "INSERT INTO LessonItems (LessonId, Prompt, CorrectAnswer, ImageUrl) VALUES (?, ?, ?, ?)",
        //        lessonId, prompt, answer, imageUrl
        //    );
        //}

        //public void InsertLessonResult(int lessonId, int correct, int total, double duration)
        //{
        //    using (var conn = new OleDbConnection(_connectionString))
        //    using (var cmd = new OleDbCommand(
        //        "INSERT INTO LessonResults (LessonId, DateTaken, Correct, Total, DurationSeconds) VALUES (?, ?, ?, ?, ?)", conn))
        //    {
        //        conn.Open();

        //        cmd.Parameters.Add("?", OleDbType.Integer).Value = lessonId;
        //        cmd.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
        //        cmd.Parameters.Add("?", OleDbType.Integer).Value = correct;
        //        cmd.Parameters.Add("?", OleDbType.Integer).Value = total;
        //        cmd.Parameters.Add("?", OleDbType.Double).Value = duration;

        //        cmd.ExecuteNonQuery();
        //    }
        //}



        //public void DeleteLesson(int lessonId)
        //{
        //    ExecuteNonQuery("DELETE FROM LessonItems WHERE LessonId = ?", lessonId);
        //    ExecuteNonQuery("DELETE FROM Lessons WHERE LessonId = ?", lessonId);
        //}

        //public void UpdateLessonCompletedAndGrade(int lessonId, bool completed, double grade)
        //{
        //    using (var conn = new OleDbConnection(_connectionString))
        //    using (var cmd = new OleDbCommand(
        //        "UPDATE Lessons SET Completed = ?, LastGrade = ? WHERE LessonId = ?", conn))
        //    {
        //        conn.Open();

        //        cmd.Parameters.Add("?", OleDbType.Boolean).Value = completed;
        //        cmd.Parameters.Add("?", OleDbType.Double).Value = grade;
        //        cmd.Parameters.Add("?", OleDbType.Integer).Value = lessonId;

        //        cmd.ExecuteNonQuery();
        //    }
        //}
        //public DataTable SearchLessons(string keyword)
        //{
        //    keyword = $"%{keyword}%";
        //    return ExecuteQuery(
        //        "SELECT * FROM Lessons WHERE Title LIKE ? OR Topic LIKE ?",
        //        keyword,
        //        keyword
        //    );
        //}
        //public DataTable GetIncompleteLessons()
        //{
        //    return ExecuteQuery("SELECT * FROM Lessons WHERE Completed = False");
        //}
        //public DataTable GetLessonsSortedByGrade(bool ascending)
        //{
        //    string order = ascending ? "ASC" : "DESC";
        //    return ExecuteQuery($"SELECT * FROM Lessons ORDER BY LastGrade {order}");
        //}
        //public void UpdateLessonStatus(int lessonId, bool completed, double lastGrade)
        //{
        //    ExecuteNonQuery(
        //        "UPDATE Lessons SET Completed = ?, LastGrade = ? WHERE LessonId = ?",
        //        completed,
        //        lastGrade,
        //        lessonId
        //    );
        //}
        //public DataTable GetLessonsByMinGrade(double minGrade)
        //{

        //    string sql =
        //        "SELECT LessonId, Title, Topic, Description, EstimatedMinutes, LastGrade, Completed " +
        //        "FROM Lessons " +
        //        "WHERE IIf(IsNull([LastGrade]), 0, [LastGrade]) >= ?";

        //    return ExecuteQuery(sql, minGrade);
        //}





    }
}
