using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfel.SQL;


namespace Portfel.Model
{
    public class Wallet
    {
        private List<User> users = new List<User>();
        
        public User actuallyUser { get; set; }

        public List<User> Users { get => users; set => users = value; }





    }
}
