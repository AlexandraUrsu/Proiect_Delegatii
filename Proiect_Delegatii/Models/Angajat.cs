using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proiect_Delegatii.Models
{
    public class Angajat
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        [OneToMany]
        public List<ListAngajat> ListAngajati { get; set; }
    }
}
