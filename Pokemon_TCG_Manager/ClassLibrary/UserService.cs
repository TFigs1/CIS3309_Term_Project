using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Pokemon_TCG_Manager.ClassLibrary
{
    public class UserService
    {
        private readonly DatabaseService _db;

        public UserService()
        {
            _db = new DatabaseService();
        }

        public bool Login(string username, string password, out int userId)
        {
            userId = -1;

            DataTable result = _db.GetUserByCredentials(username, password);

            if (result.Rows.Count == 0)
                return false;

            userId = Convert.ToInt32(result.Rows[0]["UserId"]);
            return true;
        }

        public string CreateUser(string username, string password)
        {
            if (_db.UsernameExists(username))
                return "Username already exists";

            _db.CreateUser(username, password);
            return "SUCCESS";
        }
    }
}
