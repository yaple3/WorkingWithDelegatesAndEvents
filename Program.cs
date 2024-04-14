namespace WorkingWithDelegatesAndEvents
{
    // create a delegate
    public delegate void RaceEventHandler(int winner);

    public class Race
    {
        // create a delegate event object
        public event RaceEventHandler footRace, carRace, bikeRace;

        public void Racing(int contestants, int laps)
        {
            Console.WriteLine("Ready\nSet\nGo!");
            Random r = new();
            int[] participants = new int[contestants];
            bool done = false;
            int champ = -1;
            // first to finish specified number of laps wins
            while (!done)
            {
                for (int i = 0; i < contestants; i++)
                {

                    if (participants[i] <= laps)
                    {
                        participants[i] += r.Next(1, 5);
                    }
                    else
                    {
                        champ = i;
                        done = true;
                        continue;
                    }
                }

            }

            TheWinner(champ);
        }
        private void TheWinner(int champ)
        {
            Console.WriteLine("We have a winner!");
            // invoke the delegate event object and pass champ to the method
            footRace(champ);

        }
    }

    internal class Program
    {
        public static void Main()
        {
            // create a class object
            Race round1 = new();
            // register with the footRace event
            round1.footRace += footRace;

            // trigger the event
            round1.Racing(5, 10);

            // register with the carRace event
            round1.carRace += carRace;

            //trigger the event
            round1.Racing(5, 10);

            // use a lambda expression to register with the bikeRace event
            round1.bikeRace += winner => Console.WriteLine($"Biker number {winner} is the winner.");

            // trigger the event
            round1.Racing(5, 10);

        }

        // event handlers
        public static void carRace(int winner)
        {
            Console.WriteLine($"Car number {winner} is the winner.");
        }
        public static void footRace(int winner)
        {
            Console.WriteLine($"Racer number {winner} is the winner.");
        }
    }
}