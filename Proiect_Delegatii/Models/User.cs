using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Delegatii.Models
{
    public class User
    {
        [PrimaryKey]
        public string Username { get; set; }
        public string Parola { get; set; }
        public string Rol { get; set; }
        public int id { get; set; }
        public User() { }
        public User(string Username, string Parola)
        {
            this.Username = Username;
            this.Parola = Parola;
          
        }
        
    }
}
