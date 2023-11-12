using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Film : Medien
    {
        public Person Regisseur { get; set; }
        public int LängeInMin { get; set; }

        public Film(string titel, DateTime erscheinungsdatum, Person regisseur, int längeInMin) : base (titel, erscheinungsdatum)
        {
            Regisseur = regisseur;
            LängeInMin = längeInMin;
        }




        public static List<Film> FilmList()
        {
            // TO-DO: implement

            List<Film> filmListe = new List<Film>();
            Random random = new Random();
            int maxLenght = 500;
            int countFilm = 100;

            for(int i = 0; i < countFilm; i++)
            {
                string titel = "Film" + i;
                DateTime erscheinungsdatum = new DateTime(random.Next(1990, DateTime.Now.Year), random.Next(1, 13), random.Next(1, 29));
                Person person = Person.PersonenListe[random.Next(0, Person.PersonenListe.Count)];
                int lenghtCount = random.Next(1, maxLenght + 1);

                filmListe.Add(new Film(titel, erscheinungsdatum, person, lenghtCount));
            }
            return filmListe;
            //List<Film> films = new List<Film>();
            //films.Add(new Film("Film 1", new DateTime(2012, 1, 20), Person.PersonenListe[0], 60));
            //films.Add(new Film("Film 2", new DateTime(2014, 1, 20), Person.PersonenListe[1], 50));
            //films.Add(new Film("Film 3", new DateTime(2015, 1, 20), Person.PersonenListe[2], 70));
            //films.Add(new Film("Film 4", new DateTime(2016, 1, 20), Person.PersonenListe[3], 60));
            //films.Add(new Film("Film 5", new DateTime(2017, 1, 20), Person.PersonenListe[4], 80));
            //films.Add(new Film("Film 6", new DateTime(2018, 1, 20), Person.PersonenListe[0], 90));
            //films.Add(new Film("Film 7", new DateTime(2019, 1, 20), Person.PersonenListe[2], 100));
            //films.Add(new Film("Film 8", new DateTime(2010, 1, 20), Person.PersonenListe[1], 40));
            //films.Add(new Film("Film 9", new DateTime(2011, 1, 20), Person.PersonenListe[3], 55));
            //films.Add(new Film("Film 10", new DateTime(2012, 1, 20), Person.PersonenListe[3], 69));
            //films.Add(new Film("Film 11", new DateTime(2013, 1, 20), Person.PersonenListe[1], 89));

            //return films;
        }

        //public static List<Film> FilmLidtOld(List<Person> personenListe)
        //{
        //    List<Film> films = new List<Film>();
        //    films.Add(new Film("Film 1", new DateTime(2012, 1, 20), personenListe[0], 60));
        //    films.Add(new Film("Film 2", new DateTime(2014, 1, 20), personenListe[1], 50));
        //    films.Add(new Film("Film 3", new DateTime(2015, 1, 20), personenListe[2], 70));
        //    films.Add(new Film("Film 4", new DateTime(2016, 1, 20), personenListe[3], 60));
        //    films.Add(new Film("Film 5", new DateTime(2017, 1, 20), personenListe[4], 80));
        //    films.Add(new Film("Film 6", new DateTime(2018, 1, 20), personenListe[0], 90));
        //    films.Add(new Film("Film 7", new DateTime(2019, 1, 20), personenListe[2], 100));
        //    films.Add(new Film("Film 8", new DateTime(2010, 1, 20), personenListe[1], 40));
        //    films.Add(new Film("Film 9", new DateTime(2011, 1, 20), personenListe[3], 55));
        //    films.Add(new Film("Film 10", new DateTime(2012, 1, 20), personenListe[3], 69));
        //    films.Add(new Film("Film 11", new DateTime(2013, 1, 20), personenListe[1], 89));

        //    return films;
        //}
    }
}
