using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Person
    {
        public string Vorame { get; set; }

        private string nachname;
        public string Nachname
        {
            get
            {
                //if (nachname == "susi")
                //{
                //    return nachname + " ist schöner name!";
                //}
                //else
                //{
                    return nachname;
                //return nachname + " ist KEIN schoener name!";
                //}
            }
            set
            {
                nachname = value;       // ändert den wert im RAM
                SerializeJSON(personenListe);   // speichert den Inhalt auf der festplatte

            }
        }

        public Buch Buch { get; set; }
        public Film Film { get; set; }

        private static List<Person> personenListe = new List<Person>();
        public static List<Person> PersonenListe {
            get
            {
                return personenListe;
            }

            set
            {
                personenListe = value;
            }
        }
        
        // ist ein stadtisches Feld
        //public static List<Person> statischesFeld = PersonList();



        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}


        // da initialisiere ich eine Variable, die statisch ist (heißt, dass ich dafür kein instanz erstellen muss sondern über
        // den Klassennamen aufrufen, einlesen und verändern kann.
        //public static int zahl = 9;


        // eine Property (Eigenschaft), die ich einlesen und schreiben kann und der ich den Wert 3 als int übergebe
       // public int MyProperty { get; set; } = 3;

        public Person(string vorame, string nachame)
        {
            Vorame = vorame;
            Nachname = nachame;
            //if(personenListe == null)
            //{
            //    personenListe = PersonListLoad();   // Initialisiere die Liste, wenn sie noch null ist
            //}
            SerializeJSON(personenListe);
        }

        public static void PersonListLoad()
        {
            // 1. versuche zu deserialisieren (LADEN)
            //List<Person> personenlist = new List<Person>();
            personenListe = DeSerializeJSON();

            if (personenListe == null || personenListe.Count == 0)
            {
                // 2. wenn deserialisieren (LADEN) nicht möglich: erzeuge random random daten
                personenListe.Add(new Person("Max", "Mustermann"));
                personenListe.Add(new Person("Maier", "MusterFrau"));
                personenListe.Add(new Person("Susi", "Maier"));
                personenListe.Add(new Person("Hello", "Hansi"));
                personenListe.Add(new Person("Hüpf", "Heu"));
                personenListe.Add(new Person("Hüpf3243", "Heu2434"));

                //SerializeJSON(personenlist);
            }
        }

        //private static string path = @"C:\Users\Reha-TN\OneDrive - EDU BBRZ Reha\Desktop\AP02-JET\C# Programmieren\Plattform\Klassen\Modul2TestÜbung\verleihPerson.json";
        private static string path = @"..\verleihPerson.json";

        public static void SerializeJSON(List<Person> personenlist)
        {
            // 1. erzeuge string im json format
            string JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(personenlist);

            // 2. speicher jsonString auf Festplatte
            try
            {
                System.IO.File.WriteAllText(path, JSONString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("fehler beim speichern der Datei: " + ex.Message);
            }
        }

        public static List<Person> DeSerializeJSON()
        {
            // 1. lese inhalt der json-datei in den Ram
            //string JSONstring = System.IO.File.ReadAllText(path);

            // 2. mach aus dem json string as gewünschte objekt
            //List<Person> personList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(JSONstring);

            //zweite variante mit try und catch
            List<Person> personList = new List<Person>();
            try
            {
                // 1. lese inhalt der json-datei in den Ram
                string JSONstring = System.IO.File.ReadAllText(path);

                if (JSONstring != "null" && JSONstring.Length > 0)
                {
                    // 2. mach aus dem json string as gewünschte objekt
                    personList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Person>>(JSONstring);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim speichern der datei. " + ex.Message);
            }

            return personList;
        }
    }
}
