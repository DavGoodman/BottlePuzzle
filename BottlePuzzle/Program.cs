namespace BottlePuzzle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bottle1 = new Bottle(5);
            var bottle2 = new Bottle(7);
            var wantedVolume = 1;
            var numberOfoperations = 1;

            while (true)
            {
                Console.WriteLine("Prøver med " + numberOfoperations + " operasjon(er).");
                var operations = new int[numberOfoperations];
                while (true)
                {
                    DoOperations(operations, bottle1, bottle2);
                    if (bottle1.content == wantedVolume || bottle2.content == wantedVolume)
                    {
                        Console.WriteLine("Fant løsning");
                        ShowOperations(operations);
                        Environment.Exit(0);
                        
                    }

                    var success = UpdateOperations(operations);
                    if(!success) break;
                }
                numberOfoperations++;
            }
        }

        private static bool UpdateOperations(int[] operations)
        {
            int i;
            for (i = operations.Length - 1; i >= 0; i--)
            {
                if (operations[i] < 8)
                {
                    operations[i]++;
                    break;
                }

                operations[i] = 0;
            }

            return i != -1;
        }

        private static void ShowOperations(int[] operations)
        {
            var texts = new[]
            {
                "Fylle flaske 1 fra springen",
                "Fylle flaske 2 fra springen",
                "Tømme flaske 1 i flaske 2",
                "Tømme flaske 2 i flaske 1",
                "Fylle opp flaske 2 med flaske 1",
                "Fylle opp flaske 1 med flaske 2",
                "Tømme flaske 1 (kaste vannet)",
                "Tømme flaske 2 (kaste vannet)",
            };
            foreach (int op in operations)
            {
                Console.WriteLine(" " + texts[op]);
            }
        }

        private static void DoOperations(int[] operations, Bottle bottle1, Bottle bottle2)
        {
            bottle1.Empty();
            bottle2.Empty();
            for (int i = 0; i < operations.Length; i++)
            {
                var operation = operations[i];
                if (operation == 0) bottle1.FillToTopFromTap();
                else if (operation == 1) bottle2.FillToTopFromTap();
                else if (operation == 2)
                {
                    if (bottle1.isEmpty()) break;
                    var success = bottle2.Fill(bottle1.Empty());
                    if (!success) break;
                }
                else if (operation == 3)
                {
                    if (bottle2.isEmpty()) break;
                    var success = bottle1.Fill(bottle2.Empty());
                    if (!success) break;
                }
                else if (operation == 4)
                {
                    var success = bottle2.FillToTop((bottle1));
                    if (!success) break;
                }
                else if (operation == 5)
                {
                    var success = bottle1.FillToTop((bottle2));
                    if (!success) break;
                }
                else if (operation == 6)
                {
                    bottle1.Empty();
                }
                else if (operation == 7)
                {
                    bottle2.Empty();
                }
            }
        }
    }
}