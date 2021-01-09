using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Delegatii.Models
{
    public class ListFiliala
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Filiala))]
        public int FilialaID { get; set; }
        public int AngajatID { get; set; }
    }
}
