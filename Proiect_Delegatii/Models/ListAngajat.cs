using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Delegatii.Models
{
    public class ListAngajat
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Delegatie))]
        public int DelegatieID { get; set; }
        public int AngajatID { get; set; }
    }
}
