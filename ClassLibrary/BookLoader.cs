using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public static class BookLoader
    {
        static readonly string csvPath = "CSV_mit_LinQ.csv";
        static private bool _firstLineFlag = true;
        static private HashSet<Buch> _books;

        public static string FirstLine { get; private set; }

        /// <summary>
        /// öffentliche Eigenschaft zum Auslesen der Bücher Liste
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public static List<Buch> Books
        {
            get
            {
                return _books.ToList();
            }
        }

       
        /// <summary>
        /// sogenannter "statischer Konstruktor"
        /// wird aufgerufen, wenn man zum ersten mal auf die Klasse zugreift (dabei ist egal, worauf genau zugegriffen wird)
        /// wird NUR EINMAL aufgerufen
        /// wird verwendet, um (wie in diesem Beispiel) Felder oder eigenschafen zu initialisieren
        /// </summary>
        static BookLoader()
        {
            // Überprüfung, ob Datei Existiert
            if (!File.Exists(csvPath))
                throw new FileNotFoundException("CSV_mit_LinQ.csv nicht im Ausgabeverzeichnis!");

            var csvLines = File.ReadAllLines(csvPath);

            _books = new();

            foreach(string line in csvLines)
            {
                if (_firstLineFlag)
                {
                    FirstLine = line;
                    _firstLineFlag = false;
                }
                else
                {
                    _books.Add(GetBuchFromCSVLine(line));
                }
            }

        }
        static private Buch GetBuchFromCSVLine(string line)
        {
            // Titel, Erscheinungsdatum, Autor, Seitenanzahl

            var split = line.Split(", ");
            string titel = split[0];
            if(!DateTime.TryParse(split[1], out DateTime erscheinungsdatum))
            {
                // Fehler, wenn TryParse falsch ergibt
                throw new ArgumentException();
            }
            if(!int.TryParse(split[3], out int seitenanzahl))
            {
                // Fehler, wenn TryParse falsch ergibt
                throw new ArgumentException();
            }

            // TODO: neue Klasse PersonLoader, der eine Sammlung aus Personen bereitstellt, Author von dort holen
            //Person author   = PersonLoader.GetPersonFromName(firstname, lastname);

            string fullname = split[2];
            string firstname = fullname.Split(' ')[0];
            string lastname = fullname.Split(' ')[1];
            Person author = null;


            return new Buch(titel, erscheinungsdatum, author, seitenanzahl);

        }
    }
}
