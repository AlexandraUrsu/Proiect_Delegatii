using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Delegatii.Models
{
    public class Filiala
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Judet { get; set; }
        public string Tara { get; set; }
        [OneToMany]
        public List<ListFiliala> ListFiliala { get; set; }
    }
}
