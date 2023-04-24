using System;

namespace BilVærksted
{
    struct Bil
    {
        public string Mærke;
        public string Model;
        public int ProduktionsÅr;
        public DateTime SenesteBesøgsDato;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bil[] biler = new Bil[2];

            // Tilføjelse af data til bil-array
            biler[0] = new Bil       // Opret et nyt "Bill"-objekt og tildel det til det første element i "biler"-arrayet
            {
                Mærke = "Alfa Romeo",
                Model = "Giulia",
                ProduktionsÅr = 2009,
                SenesteBesøgsDato = new DateTime(2018, 05, 15)  // Tildel et nyt "DateTime" objekt med værdierne 2018-05-15 til feltet "SenesteBesøgsDato" i det første "Bil" objekt
            };

            biler[1] = new Bil       // Opret et nyt "Bill"-objekt og tildel det til det første element i "biler"-arrayet
            {
                Mærke = "Fiat",
                Model = "Punto",
                ProduktionsÅr = 2019,
                SenesteBesøgsDato = new DateTime(2021, 01, 10)  // Tildel et nyt "DateTime" objekt med værdierne 2018-05-15 til feltet "SenesteBesøgsDato" i det første "Bil" objekt
            };
            // Datainput af medarbejderen
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("======================================");
            Console.WriteLine("||   Velkommen til BilVærksted!   ||");
            Console.WriteLine("======================================");
            Console.WriteLine();

            // Indtastning af data fra medarbejderen
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Indtast bilens mærke:");
            string mærke = Console.ReadLine();

            Console.WriteLine("Indtast bilens model:");
            string model = Console.ReadLine();

            Console.WriteLine("Indtast bilens produktionsår:");
            int produktionsÅr = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Indtast bilens seneste besøgsdato (i formatet dd-MM-yyyy):");  //Den kontrollerer, om de indtastede data er korrekte, herunder om datoen for besøget på siden er i det korrekte format (dd-MM-åååå).
            DateTime senesteBesøgsDato;
            if (DateTime.TryParseExact(Console.ReadLine(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out senesteBesøgsDato))   //Hvis den indtastede dato for besøget på webstedet er i det forkerte format, viser den en meddelelse om det forkerte datoformat.  
            {
                // Tjek om bilen kræver service
                bool kræverService = false;
                foreach (var bil in biler)
                {
                    if (bil.Mærke == mærke && bil.Model == model && bil.ProduktionsÅr < produktionsÅr && bil.SenesteBesøgsDato < senesteBesøgsDato)
                    {
                        kræverService = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("======================================");
                        Console.WriteLine("||  Bilen kræver service!         ||");
                        Console.WriteLine("======================================");
                        Console.WriteLine("||  Bilen har følgende fabriksfejl:||");
                        Console.WriteLine("||  - Udstødning                  ||");
                        Console.WriteLine("||  - Styretøj                    ||");
                        Console.WriteLine("======================================");
                        Console.WriteLine();
                        break;
                    }
                }

                if (kræverService)       //Hvis den finder en bil af samme mærke, model, ældre produktionsår og tidligere dato for servicebesøg, anser den bilen for at have behov for service, viser en fabriksfejlmeddelelse og bryder løkken.
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("||  Bilen skal på værksted.         ||");
                    Console.WriteLine("======================================");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("||  Bilen behøver ikke værksted.   ||");
                    Console.WriteLine("======================================");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("||  Ugyldigt datoformat. Applikationen vil blive lukket. ||");
                Console.WriteLine("===========================================================");
            }

            Console.ResetColor(); //Nulstil konsolfarver og venter på, at der trykkes på en tast, før programmet slutter.
            Console.ReadKey();
        }
    }
}
