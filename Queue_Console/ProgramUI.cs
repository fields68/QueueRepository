using Queue_Repository;

public class ProgramUI
{
    QueueRepository _repo = new QueueRepository();

    public void Run()
    {
        Seed();
        Menu();
    }

    private void Menu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            Console.Clear();

            System.Console.WriteLine("Please select from the following options:\n"
                + "1. Add a new claim\n"
                + "2. View the next claim\n"
                + "3. See a list of all claims\n"
                + "4. Process (remove) the next claim\n"
                + "5. Exit");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    System.Console.WriteLine("Add a new claim");
                    break;
                case "2":
                    System.Console.WriteLine("View the next claim ");
                    break;
                case "3":
                    System.Console.WriteLine("See a list of all claims");
                    break;
                case "4":
                    System.Console.WriteLine("Process (remove) the next claim");
                    break;
                case "5":
                    Console.Clear();
                    System.Console.WriteLine("See you next time");

                    keepRunning = false;
                    break;
                default:
                    System.Console.WriteLine("Not a valid option. Please Input and option from list above.");
                    break;
            }

            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }



    private void Seed() { }
}