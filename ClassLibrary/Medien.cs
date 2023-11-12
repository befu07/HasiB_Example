using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Medien
    {
        public string Titel { get; set; }
        public DateTime Erscheinungsdatum{ get; set; }
        public int Id { get; private set; }
        private static int nextId = 1;


        public Medien()
        {
            Id = nextId;
            nextId++;
        }
            public Medien(string titel, DateTime erscheinungsdatum)
        {
            Titel = titel;
            Erscheinungsdatum = erscheinungsdatum;
            Id = nextId;
            nextId++;
        }
    }
}
