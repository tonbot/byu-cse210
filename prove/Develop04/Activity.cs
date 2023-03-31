using System;

class Activity : Pmenu
{

    private String greetings = "";
    private String description = "";
    private String prompt = "";
    DateTime futureTime;
    string[] reflectPromptArr1 = {
        "---Think of a time when you stood up for someone else---",
        "---Think of a time when you did something really difficult---",
        "---Think of a time when you helped someone in need---",
        "---Think of a time when you did something truly selfless---",
      };

    string[] reflectPromptArr2 = {
        "Why was this experience meaningful to you? ",
        "Have you ever done anything like this before? ",
        "How did you get started? ",
        "How did you feel when it was complete? ",
          "What made this time different than other times when you were not as successful? ",
        "What is your favorite thing about this experience? ",
        "What could you learn from this experience that applies to other situations? ",
        "What did you learn about yourself through this experience? ",
         "How can you keep this experience in mind in the future? ",
      };
    string[] listingPromptArr1 = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
      };

    private List<String> listingArr = new List<String> {

};

    public void startActivity(int option)
    {

        Console.WriteLine();
        switch (option)
        {
            case 1:
                greetings = "Welcome to the Breathing Activity";
                description = "This activity will help you relax by walking you through breathing in and out slowly, clear your mind and focus on your breathing";
                prompt = "How long, in Seconds, would you like for your session: ";
                breathingActivity(greetings, description, prompt);
                break;
            case 2:
                greetings = "Welcome to the Reflecting Activity";
                description = "This activities will help you reflect on time in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
                prompt = "How long, in Seconds, would you like for your session: ";
                reflectingActivity(greetings, description, prompt);
                break;
            case 3:
                greetings = "Welcome to the Listing Activity";
                description = "This activities will let you reflect on the good things in your life by having you list as many thing as you can in a certain area";
                prompt = "How long, in Seconds, would you like for your session: ";
                listingActivity(greetings, description, prompt);
                break;

            default:
                quit();
                break;
        }
    }

    //    breathing activity logic
    private void breathingActivity(String greetings, String description, String prompt)
    {
        //show this content to the user
        displayContent(greetings, description);

        int seconds = Convert.ToInt32(getUserInput(prompt));

        Console.Clear();

        Console.WriteLine("Get ready...");

        spinner(1000);

        Console.WriteLine(" ");

        futureTime = getTime(seconds);

        Console.WriteLine(" ");

        startBreathing();

        endActivity(seconds, "Breathing Activity");

    }

    //    reflecting activity logic
    private void reflectingActivity(String greetings, String description, String prompt)
    {

        displayContent(greetings, description);

        int seconds = Convert.ToInt32(getUserInput(prompt));

        Console.Clear();

        Console.WriteLine("Get ready...");

        spinner(800);

        Console.WriteLine(" ");

        Console.WriteLine("Consider the following prompt:");

        Console.WriteLine(" ");

        Console.WriteLine(randQuesGenerator(reflectPromptArr1));

        Console.WriteLine(" ");

        Console.Write("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine(" ");

        Console.WriteLine("Now ponder on each of the following Questions as they related to this experience.");
        Console.Write("You may begin in: ");

        for (var i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        futureTime = getTime(seconds);

        Console.Clear();

        startReflecting();

        endActivity(seconds, "Reflecting Activity");

    }
    //    listing activity logic
    private void listingActivity(String greetings, String description, String prompt)
    {
        displayContent(greetings, description);

        int seconds = Convert.ToInt32(getUserInput(prompt));

        Console.Clear();

        Console.WriteLine("Get ready...");

        spinner(800);

        Console.WriteLine(" ");

        Console.WriteLine("List as many responses to the following prompt:");

        Console.WriteLine(" ");

        Console.WriteLine(randQuesGenerator(listingPromptArr1));
        Console.Write("You may begin in: ");
        for (var i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine(" ");
        futureTime = getTime(seconds);

        startListing();

        Console.WriteLine("You liste " + listingArr.Count() + " items");
        endActivity(seconds, "Listing Activity");
    }

    private void displayContent(String greetings, String description)
    {
        Console.WriteLine(greetings);
        Console.WriteLine(" ");
        Console.WriteLine(description);
        Console.WriteLine(" ");
    }



    private void startBreathing()
    {
        DateTime currentTime = DateTime.Now;
        if (currentTime < futureTime)
        {
            Console.WriteLine(" ");
            Console.Write("Breath in...");
            for (var i = 5; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine(" ");
            Console.Write("Now Breath out...");
            for (var i = 5; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine(" ");
            startBreathing();
        }
    }


    private void startReflecting()
    {
        DateTime currentTime = DateTime.Now;
        if (currentTime < futureTime)
        {
            //get random question to display

            Console.Write("> ");
            Console.WriteLine(randQuesGenerator(reflectPromptArr2));
            spinner(700);

            startReflecting();
        }
    }

    private void startListing()
    {
        DateTime currentTime = DateTime.Now;
        if (currentTime < futureTime)
        {
            //get random question to display
            Console.Write("> ");
           string input =  Console.ReadLine();
           listingArr.Add(input);
            startListing();
        }
    }


    //  spinner
    public void spinner(int sec)
    {
        for (var i = 0; i < 5; i++)
        {
            Console.Write("\\");
            Thread.Sleep(sec);// Erase the + character
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(sec);
            Console.Write("\b \b");
        }
    }

    // get the current time 
    public DateTime getTime(int seconds)
    {

        DateTime startTime = DateTime.Now;
        return startTime.AddSeconds(seconds);

    }

    public String randQuesGenerator(string[] quest)
    {
        Random rnd = new Random();

        int qNum = rnd.Next(quest.Length);

        return quest[qNum];
    }


    public void endActivity(int seconds, String activityName)
    {
        Console.WriteLine(" ");
        Console.WriteLine("Well done!!!");

        spinner(500);

        Console.WriteLine(" ");

        Console.WriteLine("You have completed another " + seconds + " seconds of the " + activityName);

        spinner(500);

        Console.Clear();

        int option = displayMenu();
        startActivity(option);
    }

    public void quit()
    {
        Console.Clear();
        return;
    }
}