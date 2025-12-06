using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_TCG_Manager
{
    
    public static class Session
    {
        public static int LoggedInUserId { get; set; }
        public static string LoggedInUsername { get; set; }
    }
}
