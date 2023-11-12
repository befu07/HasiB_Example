using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ClassLibrary
{
    public class Buch : Medien
    {
        public Person Autor { get; set; }
        public int Seitenanzahl { get; set; }

        public Buch(string titel, DateTime erscheinungsdatum, Person autor, int seitenanzahl) : base(titel, erscheinungsdatum)
        {
            Autor = autor;
            Seitenanzahl = seitenanzahl;
        }

        public string ToCsvString()
        {
            return $"{Titel}, {Erscheinungsdatum}, {Autor}, {Seitenanzahl}";
        }

        public static List<Buch> BookList()
        {

            List<Buch> bücherliste = new List<Buch>();
            Random rnd = new Random();
            int maxPages = 3000;
            int countBook = 100;

            for (int i = 0; i < countBook; i++)
            {
                string titel = "Buch " + i;
                //Person.personenListe = Person.PersonList();
                DateTime erscheinungsdatum = new DateTime(rnd.Next(1990, DateTime.Now.Year), rnd.Next(1, 13), rnd.Next(1, 29));
                Person person = Person.PersonenListe[rnd.Next(0, Person.PersonenListe.Count)];
                int pageCount = rnd.Next(1, maxPages + 1);

                bücherliste.Add(new Buch(titel, erscheinungsdatum, person, pageCount));
            }

            // Rufe die SerializeBookJSON-Methode auf, um die Daten zu speichern
            SerializeBookJSON(bücherliste);
            SerializeBookCSV(bücherliste);

            return bücherliste;

            //bücherliste.Add(new Buch("Buch 1", new DateOnly(2012, 1, 20), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages + 1)));
            //bücherliste.Add(new Buch("Buch 2", new DateOnly(2009, 2, 16), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages +1)));
            //bücherliste.Add(new Buch("Buch 3", new DateOnly(2012, 3, 01), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages +1)));
            //bücherliste.Add(new Buch("Buch 4", new DateOnly(2001, 4, 12), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages +1)));
            //bücherliste.Add(new Buch("Buch 5", new DateOnly(2009, 5, 22), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages +1)));
            //bücherliste.Add(new Buch("Buch 6", new DateOnly(2011, 6, 23), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages +1)));
            //bücherliste.Add(new Buch("Buch 7", new DateOnly(2012, 7, 24), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages + 1)));
            //bücherliste.Add(new Buch("Buch 8", new DateOnly(2018, 8, 25), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages +1)));
            //bücherliste.Add(new Buch("Buch 9", new DateOnly(2099, 9, 26), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages +1)));
            //bücherliste.Add(new Buch("Buch 10", new DateOnly(2004, 1, 02), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages + 1)));
            //bücherliste.Add(new Buch("Buch 11", new DateOnly(2019, 1, 11), personenListe[rnd.Next(0, personenListe.Count)], rnd.Next(1, maxPages + 1)));
        }



        //public static List<Buch> BookListOld(List<Person> personenListe)
        //{
        //    List<Buch> bücherliste = new List<Buch>();
        //    bücherliste.Add(new Buch("Buch 1", new DateOnly(2012, 1, 20), personenListe[0], 399));
        //    bücherliste.Add(new Buch("Buch 2", new DateOnly(2009, 2, 16), personenListe[1], 244));
        //    bücherliste.Add(new Buch("Buch 3", new DateOnly(2012, 3, 01), personenListe[2], 577));
        //    bücherliste.Add(new Buch("Buch 4", new DateOnly(2001, 4, 12), personenListe[3], 622));
        //    bücherliste.Add(new Buch("Buch 5", new DateOnly(2009, 5, 22), personenListe[4], 100));
        //    bücherliste.Add(new Buch("Buch 6", new DateOnly(2011, 6, 23), personenListe[0], 455));
        //    bücherliste.Add(new Buch("Buch 7", new DateOnly(2012, 7, 24), personenListe[1], 50));
        //    bücherliste.Add(new Buch("Buch 8", new DateOnly(2018, 8, 25), personenListe[2], 122));
        //    bücherliste.Add(new Buch("Buch 9", new DateOnly(2099, 9, 26), personenListe[3], 755));
        //    bücherliste.Add(new Buch("Buch 10", new DateOnly(2004, 1, 02), personenListe[4], 999));
        //    bücherliste.Add(new Buch("Buch 11", new DateOnly(2019, 1, 11), personenListe[0], 499));
        //    return bücherliste;
        //}

        //private static string path = @"C:\Users\Reha-TN\OneDrive - EDU BBRZ Reha\Desktop\AP02-JET\C# Programmieren\Plattform\Klassen\Modul2TestÜbung\verleihBuch.json";
        private static string path = @"..\verleihBuch.json";
        private static string pathCSV = @"..\verleihBuch.csv";

        public static void SerializeBookJSON(List<Buch> bücherListe)
        {
            string JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(bücherListe);

            try
            {
                System.IO.File.WriteAllText(path, JSONString);
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler beim Speichern der Datei: {0}", e.Message);
            }
        }
        //public static void SerializeBookCSV(List<Buch> bücherListe)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(pathCSV))
        //        {
        //            // Schreibe die CSV-Header-Zeile
        //            sw.WriteLine("Titel, Erscheinungsdatum, Autor, Seitenanzahl");

        //            // schreibe die Daten von jeder Buch-Instanz in die CSV-Datei
        //            foreach (Buch buch in bücherListe)
        //            {
        //                sw.WriteLine($"{buch.Titel}, {buch.Erscheinungsdatum}, {buch.Autor.Vorame} {buch.Autor.Nachname}, {buch.Seitenanzahl}");
        //            }
        //        }

        //        Console.WriteLine("Daten erfolgreich als CSV gespeichert.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Fehler beim Speichern der CSV-Datei: {0}", e.Message);
        //    }
        //}
        public static void SerializeBookCSV(List<Buch> bücherListe)
        {
            List<string> zeilen = new()
            {
                "Titel, Erscheinungsdatum, Autor, Seitenanzahl"
            }; // neue Liste, gleich mit Kopfzeile initialisieren. geht genauso auch new(); und in nächster Zeile zeilen.Add("bla")

            foreach (Buch buch in bücherListe)
            {
                zeilen.Add($"{buch.Titel}, {buch.Erscheinungsdatum}, {buch.Autor.Vorame} {buch.Autor.Nachname}, {buch.Seitenanzahl}");
            }

            // Anstatt einen Ewig langen Pfad anzugeben, bietet es sich an, die Dateien zu Testzwecken einfach im Debug-Ordner zu speichern.
            // \Modul2TestÜbung\Modul2Test�bung\Modul2Test�bung\bin\Debug\net7.0 

            // btw, umlaute im Projektnamen sind doof. 
            try
            {
                File.WriteAllLines("berniBuecher.csv", zeilen); // <<--- REICHT VOLLKOMMEN AUS!
                                                                // Filewriter ist, soweit ich weiß, für komplexere Sachen gedacht (nie wirklich verwendet)
                                                                // mit File.Write wird einfach eine neue Datei angelegt. Vorhandene wird überschrieben
                                                                // die Fehlermeldungen (abgesehen von denen, die durch die umlaute im namen und verzippen enstanden sind...)
                                                                // haben damit zu tun dass man dem Filewriter sagen muss, wann er fertig ist (glaube ich)

                Console.WriteLine("SerializeBookCSV: erfolgreich als CSV gespeichert.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler beim Speichern der CSV-Datei: {0}", e.Message);
            }

            // mit aufrufen 
            SerializeBookCSV_WithLinQ(bücherListe);
            SerializeBookCSV_WithStreamWriter(bücherListe);
        }
        public static void SerializeBookCSV_WithLinQ(List<Buch> bücherListe)
        {
            var header = "Titel, Erscheinungsdatum, Autor, Seitenanzahl";
            var rows = bücherListe.Select(buch => $"{buch.Titel}, {buch.Erscheinungsdatum}, {buch.Autor.Vorame} {buch.Autor.Nachname}, {buch.Seitenanzahl}");

            List<string> csvRows = new List<string>(rows).Prepend(header).ToList();
            //csvRows = csvRows.Prepend(header).ToList();

            File.WriteAllLines("CSV_mit_LinQ.csv", csvRows);

            Console.WriteLine("SerializeBookCSV_WithLinQ: erfolgreich als CSV gespeichert.");
        }
        public static void SerializeBookCSV_WithStreamWriter(List<Buch> bücherListe)
        {
            var rows = bücherListe.Select(buch => $"{buch.Titel}, {buch.Erscheinungsdatum}, {buch.Autor.Vorame} {buch.Autor.Nachname}, {buch.Seitenanzahl}");

            List<string> csvRows = new(){ "Titel, Erscheinungsdatum, Autor, Seitenanzahl" };
            csvRows.AddRange(rows);

            using (StreamWriter sw = new StreamWriter("StreamWriterTestFile.csv"))
            {
                var autoflush = sw.AutoFlush;   // <- standardmässig auf false, deshalb ...
                foreach (var row in csvRows)
                {
                    sw.WriteLine(row);
                }
                sw.Flush(); // ... das hier notwendig
                sw.Close();
                // aber wie schon oben gesagt, StreamWriter is für das hier übertrieben kompliziert.
                // Streamwriter braucht man, wenn man zB. im laufenenden Betrieb auf bestehende Dateien zugreifen und zeilen anfügen will
                // (wenn überhaupt - wirst so schnell nicht brauchen)
            }
            Console.WriteLine("SerializeBookCSV_WithStreamWriter: erfolgreich als CSV gespeichert.");

        }

    }
}