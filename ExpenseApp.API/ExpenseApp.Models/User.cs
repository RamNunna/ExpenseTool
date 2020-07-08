using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseApp.Entites
{
    public class User
    {
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }

        public User WithoutPassword()
        {
            throw new NotImplementedException();
        }
    }
}
