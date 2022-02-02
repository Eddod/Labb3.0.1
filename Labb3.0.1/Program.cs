using Labb3._0._1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Labb3._0._1
{
    class Program
    {

        static void Personal(SampleDbContext db)
        {
            var Person = db.TblPersonal;
                         

            foreach (var item in Person)
            {
                
                Console.WriteLine("Namn : " + item.Namn );
                Console.WriteLine("Befattning : " + item.Befattning);
                Console.WriteLine("---------------------------");
                
            }
        }
        static void Befattning(SampleDbContext db, string roll)
        {
            var befattning = from Befattning in db.TblPersonal
                             where Befattning.Befattning == roll
                             orderby Befattning.Namn
                             select Befattning;

            foreach (var item in befattning)
            {
                Console.WriteLine("Namn : " + item.Namn);
                Console.WriteLine("Befattning : " + item.Befattning);
                Console.WriteLine("------------");
            }
        }
        static void Elever(SampleDbContext db)
        {
            Console.WriteLine("Välj [1] för att sortera eleverna efter förnamn");
            Console.WriteLine("Välj [2] för att sortera eleverna efter Efternamn");
            string input = Console.ReadLine();
            if (input.Equals("1"))
            {
                Console.WriteLine("Välj [1] för att sortera förnamnen i stigande ordning");
                Console.WriteLine("Välj [2] för att sortera förnamnen i fallande ordning");


                if (input.Equals("1"))
                {
                    Console.WriteLine("Elever");
                    var elever = db.TblElev.OrderBy(p => p.Förnamn);

                    foreach (var elev in elever)
                    {
                        Console.WriteLine("Elev : " + elev.Förnamn + " " + elev.Efternamn);
                        Console.WriteLine("KLASS : " + elev.Klass);
                        Console.WriteLine("------------------------------");

                    }
                    Console.ReadLine();
                }
                else if (input.Equals("2"))
                {
                    Console.WriteLine("Elever");
                    var elever = db.TblElev.OrderByDescending(p => p.Förnamn);

                    foreach (var elev in elever)
                    {
                        Console.WriteLine("Elev : " + elev.Förnamn + " " + elev.Efternamn);
                        Console.WriteLine("KLASS : " + elev.Klass);
                        Console.WriteLine("-------------------------------");

                    }
                    Console.ReadLine();
                }
            }
            else if (input.Equals("2"))
            {
                Console.WriteLine("Välj [1] för att sortera efternamnen i stigande ordning");
                Console.WriteLine("Välj [2] för att sortera efternamnen i fallande ordning");
                input = Console.ReadLine();

                if (input.Equals("1"))
                {
                    Console.WriteLine("Elever");
                    var elever = db.TblElev.OrderBy(p => p.Efternamn);

                    foreach (var elev in elever)
                    {
                        Console.WriteLine("Elev : " + elev.Förnamn + " " + elev.Efternamn);
                        Console.WriteLine("KLASS : " + elev.Klass);
                        Console.WriteLine("-------------------------------");
                    }
                    Console.ReadLine();
                }
                else if (input.Equals("2"))
                {
                    Console.WriteLine("Elever");
                    var elever = db.TblElev.OrderByDescending(p => p.Efternamn);

                    foreach (var elev in elever)
                    {
                        Console.WriteLine("Elev : " + elev.Förnamn + " " + elev.Efternamn);
                        Console.WriteLine("KLASS : " + elev.Klass);
                        Console.WriteLine("-------------------------------");
                    }
                    Console.ReadLine();
                }
            }
        }
        static void Klass(SampleDbContext db, string klass)
        {

            var Elever = db.TblElev.Where(x => x.Klass == klass);
            foreach (var item in Elever)
            {
                Console.WriteLine(item.Förnamn + item.Efternamn);
                Console.WriteLine("------");
            }
        }
        static void AddPersonal(SampleDbContext db)
        {
            Personal NyPersonal = new Personal();

            Console.WriteLine("Var god skriv in namnet på den nyanställda");
            string name = Console.ReadLine();
            NyPersonal.Namn = name;
            Console.WriteLine("Var god skriv in befattningen på den nyanställda");
            string yrkesroll = Console.ReadLine();
            NyPersonal.Befattning = yrkesroll;
            Console.WriteLine("Välkommen till gymnasiet {0}", name);
            db.Add(NyPersonal);
            db.SaveChanges();
        }
        static void AddElev(SampleDbContext db)
        {
            Elev NyElev = new Elev();


            Console.WriteLine("Var god skriv in personnumret på den nya eleven.");
            string persnmr = Console.ReadLine();
            NyElev.Personnummer = persnmr; /*db.TblElev.FromSqlRaw("INSERT INTO tblElev (Personnummer) VALUES {0}", persnmr);*/

            Console.WriteLine("Var god skriv in förnamnet på den nya eleven.");
            string Fnamn = Console.ReadLine();
            NyElev.Förnamn = Fnamn; /*db.TblElev.FromSqlRaw("INSERT INTO tblElev (Förnamn) VALUES {0}", Fnamn);*/

            Console.WriteLine("Var god skriv in efternamnet på den nya eleven.");
            string Enamn = Console.ReadLine();
            NyElev.Efternamn = Enamn; /*db.TblElev.FromSqlRaw("INSERT INTO tblElev (Efternamn) VALUES {0}", Enamn);*/

            Console.WriteLine("Var god skriv in klassen som eleven ska gå i.");
            string klass = Console.ReadLine();
            NyElev.Klass = klass;/*db.TblElev.FromSqlRaw("INSERT INTO tblElev (Klass){0} VALUES", klass);*/



            Console.WriteLine("Välkommen till {0}, {1} {2}", klass, Fnamn, Enamn);
            db.Add(NyElev);
            db.SaveChanges();


            Console.ReadLine();
        }
        static void SpecifikKlass(SampleDbContext db)
        {
            Console.WriteLine("Var god skriv in vilken klass du vill se eleverna ifrån");
            var Klasser = db.TblElev.Select(p => p.Klass).Distinct();


            foreach (var item in Klasser)
            {
                Console.WriteLine(item);
            }
            string input = Console.ReadLine();
            if (input.Equals("SAMHÄLL1"))
            {
                Console.Clear();
                Klass(db, "SAMHÄLL1");
                Console.ReadLine();
            }
            else if (input.Equals("SAMHÄLL3"))
            {
                Console.Clear();
                Klass(db, "SAMHÄLL3");
                Console.ReadLine();
            }
            else if (input.Equals("TEKNIK2"))
            {
                Console.Clear();
                Klass(db, "TEKNIK2");
            }
            else if (input.Equals("TEKNIK3"))
            {
                Console.Clear();
                Klass(db, "TEKNIK3");
            }
            else if (input.Equals("SUT21"))
            {
                Console.Clear();
                Klass(db, "SUT21");
            }
            
            
        }



        static void Main(string[] args)
        {
            using (var db = new SampleDbContext())
            {

                Console.WriteLine("Välkommen till PS! ");
                Console.WriteLine("[1] Hämta ut personal.");
                Console.WriteLine("[2] Hämta ut alla elever på skolan.");
                Console.WriteLine("[3] Hämta ut alla elever ur en viss klass");
                Console.WriteLine("[4] Lägg till elever.");
                Console.WriteLine("[5] Lägg till personal.");
                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Tryck [1] för att ta ut all Personal");
                        Console.WriteLine("Tryck [2] för att ta ut alla Lärare");
                        Console.WriteLine("Tryck [3] för att ta ut alla Vaktmästare");
                        Console.WriteLine("Tryck [4] för att ta ut alla Rektorer");

                        string inmat = Console.ReadLine();
                        if (inmat.Equals("1"))
                        {
                            Console.Clear();
                            Personal(db);
                            Console.ReadLine();
                        }
                        else if (inmat.Equals("2"))
                        {
                            Console.Clear();
                            Befattning(db, "Lärare");
                            Console.ReadLine();
                        }
                        else if (inmat.Equals("3"))
                        {
                            Console.Clear();
                            Befattning(db, "Vaktmästare");
                            Console.ReadLine();
                        }
                        else if (inmat.Equals("4"))
                        {
                            Console.Clear();
                            Befattning(db, "Rektor");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Var god mata in giltig siffra");
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Elever(db);
                        break;
                    case "3":
                        SpecifikKlass(db);
                        break;

                    case "4":
                        Console.Clear();
                        AddElev(db);
                        break;

                    case "5":
                        Console.Clear();
                        AddPersonal(db);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
