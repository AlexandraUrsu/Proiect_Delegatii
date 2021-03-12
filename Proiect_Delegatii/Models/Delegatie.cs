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
        public string Locatie { get; set; }
        public DateTime Data_Plecare { get; set; }
        public DateTime Data_Intoarcere { get; set; }
        public DateTime Data { get; set; }
    }
}
