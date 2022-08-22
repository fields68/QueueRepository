using Queue_Repository;


public class ProgramUI
{
    private QueueRepository _repo = new QueueRepository();

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
                    CreateNewClaim();
                    break;
                case "2":
                    ViewNextClaim();
                    break;
                case "3":
                    ViewAllClaims();
                    break;
                case "4":
                    DeleteNextClaim();
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

    // Create
    private void CreateNewClaim()
    {
        Console.Clear();

        ClaimInfo newClaim = new ClaimInfo();
        bool addResult = false;
        int claimInt = 0;

        // ClaimType
        System.Console.WriteLine(@"Please select the type of claim that you wish to submit:
                        
                        1. Car
                        2. Home
                        3. Theft");

        string? claimString = Console.ReadLine();
        try
        {
            claimInt = int.Parse(claimString);
        }
        catch
        {
            System.Console.WriteLine("Please enter a valid input. i.e. 1, 2, or3");
            goto Error;
        }
        switch (claimInt)
        {
            case 1:
                newClaim.ClaimType = (Queue_Repository.ClaimInfo.Claim)claimInt;
                break;
            case 2:
                newClaim.ClaimType = (Queue_Repository.ClaimInfo.Claim)claimInt;
                break;
            case 3:
                newClaim.ClaimType = (Queue_Repository.ClaimInfo.Claim)claimInt;
                break;
            default:
                System.Console.WriteLine("Please enter a valid input. i.e. 1, 2, or3");
                goto Error;
        }

        // Description
        Console.Clear();
        System.Console.WriteLine("Please write a description of the incident:");

        newClaim.Description = Console.ReadLine();

        // Claim Amount
        Console.Clear();
        System.Console.WriteLine("Please enter claim amount:");

        string? amountString = Console.ReadLine();
        try
        {
            newClaim.ClaimAmount = Math.Round(decimal.Parse(amountString), 2);
        }
        catch
        {
            System.Console.WriteLine("Please enter a valid number amount.");
            goto Error;
        }

        // Date of Incident
        Console.Clear();
        System.Console.WriteLine("Please enter the date when the incident occured: format yyyy,mm,dd");

        string? dIncidentString = Console.ReadLine();
        try
        {
            newClaim.DateOfIncident = DateOnly.Parse(dIncidentString);
        }
        catch
        {
            System.Console.WriteLine("Please enter a valid date. Ex. — 2022,06,25");
            goto Error;
        }

        // Date of Claim
        Console.Clear();
        System.Console.WriteLine("Please enter the date when the Claim was filed: format yyyy, mm, dd");

        string? dClaimString = Console.ReadLine();
        try
        {
            newClaim.DateOfClaim = DateOnly.Parse(dClaimString);
        }
        catch
        {
            System.Console.WriteLine("Please enter a valid date. Ex. — 2022,06,25");
            goto Error;
        }

        addResult = _repo.AddNewClaim(newClaim);

    Error:
        if (addResult)
        {
            Console.Clear();
            System.Console.WriteLine("Content successfully added!");
        }
        else
        {
            System.Console.WriteLine("There was an issue adding new claim");
        }
    }

    // View Next
    private void ViewNextClaim()
    {
        Console.Clear();

        Queue<ClaimInfo> claimQueue = _repo.GetAllClaims();

        if (claimQueue.Count > 0)
        {
            ClaimInfo viewNext = _repo.NextClaim();
            DisplayClaimInfo(viewNext);
        }
        else
        {
            System.Console.WriteLine("There are no claims to be viewed at this moment.");
        }
    }
    // View All
    private void ViewAllClaims()
    {
        Console.Clear();

        Queue<ClaimInfo> claimQueue = _repo.GetAllClaims();

        if (claimQueue.Count > 0)
        {
            foreach (ClaimInfo claim in claimQueue)
            {
                DisplayClaimInfo(claim);
            }
        }
        else
        {
            System.Console.WriteLine("There are no claims to be viewed at this moment.");
        }
    }

    // Delete Next Claim
    private void DeleteNextClaim()
    {
        Console.Clear();

        System.Console.WriteLine(@"
Are you sure you want to process this claim?
1. Yes
2. No");

        string? yesNo = Console.ReadLine();

        switch (yesNo)
        {
            case "1":

                if (_repo.GetAllClaims().Count > 0)
                {
                    Console.Clear();

                    // Had to call this within the if statement because it would cause an error if I loaded it before function could check if anything is in the queue.
                    ClaimInfo delNext = _repo.DeleteClaim();

                    System.Console.WriteLine($@"
    Claim —

        Claim Type: {delNext.ClaimType}
        
        Descritption:
        {delNext.Description}
        
        Claim Amount: ${delNext.ClaimAmount}
        
        Incident Date: {delNext.DateOfIncident}
        
        Claim Date: {delNext.DateOfClaim}
        
        {(delNext.IsValid ? "This claim was made within the 30 day time frame." : "This claim was NOT made within the 30 day time frame")} 

    has been processed you may proceed on to the next claim.");
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("No claim to process.");
                }
                break;
            case "2":
                break;
            default:
                System.Console.WriteLine("Please enter valid option. i.e 1 or 2");
                break;
        }
    }
    private void Seed()
    {
        ClaimInfo claim1 = new ClaimInfo(ClaimInfo.Claim.Car, "Giant Cupcake fell onto car.", 6135.00m, new DateOnly(2022, 07, 25), new DateOnly(2022, 08, 20));
        _repo.AddNewClaim(claim1);

        ClaimInfo claim2 = new ClaimInfo(ClaimInfo.Claim.Home, "House Fire.", 12065.00m, new DateOnly(2022, 06, 25), new DateOnly(2022, 08, 01));
        _repo.AddNewClaim(claim2);

        ClaimInfo claim3 = new ClaimInfo(ClaimInfo.Claim.Theft, "Jewerly missing from apartment. TV and laptop also stolen.", 6000.00m, new DateOnly(2022, 06, 25), new DateOnly(2022, 07, 01));
        _repo.AddNewClaim(claim3);
    }

    private void DisplayClaimInfo(ClaimInfo claim)
    {

        System.Console.WriteLine($@"
    Claim Type: {claim.ClaimType}
        
        Descritption:
        {claim.Description}
        
        Claim Amount: ${claim.ClaimAmount}
        
        Incident Date: {claim.DateOfIncident}
        
        Claim Date: {claim.DateOfClaim}
        
        {(claim.IsValid ? "This claim was made within the 30 day time frame." : "This claim was NOT made within the 30 day time frame")} ");
    }
}