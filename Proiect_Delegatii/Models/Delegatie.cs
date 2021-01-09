using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Delegatii.Models
{
    public class Delegatie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Descriere { get; set; }
        public DateTime Data { get; set; }
        
    }
}
