using System;
using System.IO;

class Entry
{

    static public int optionNumber = 0;
    static String readResponse = "";
    static List<String> responseList = new List<String>();
    static List<String> content = new List<String>();
    static MenuGenerator menu = new MenuGenerator();
    string dateText = "";
    DateTime theCurrentTime = DateTime.Now;
    String fileName = "";
    string[] entryArray = {
        "What five traits do you value most in potential partners?",
        "What do you value most in relationships (trust, respect, sense of humor, etc.)?",
        "What aspects of your life are you most grateful for?",
        "What can you do to improve your work performance?",
        "When do you trust yourself most?",
        "What was the strongest emotion I felt today?",
        "What do you fear most?",
        "What difficult thoughts or emotions come up most frequently for you?",
        "What place makes you feel most peaceful?",
        "What do you most want to accomplish in life?"
      };
      //this function will display the menu 
    public void displayMenu(int optionNumber)
    {
        if (optionNumber == 0)
        {
            optionNumber = menu.displayMenuOption();
        }
        switch (optionNumber)
        {
            case 1:
                writeEntry();
                break;
            case 2:
                displayContent();
                break;
            case 3:
                loadJournal();
                break;
            case 4:
                saveJournal();
                break;
            case 5:
                quit();
                break;
            default:
                Console.WriteLine("Sorry invalid input");
                break;
        }
    }

    private void quit()
    {
        Console.WriteLine("THANK YOU, SEE YOU NEXT TIME");
        return;
    }

    private void saveJournal()
    {
        Console.WriteLine("Enter File name....");
        fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            for (int i = 0; i < content.Count; i++)
            {
                outputFile.WriteLine(content[i]);
            }
        }
        optionNumber = 0;
        displayMenu(optionNumber);
    }

    private void loadJournal()
    {
        Console.WriteLine("Enter file name to load from");
        fileName = Console.ReadLine();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            content.Add(line);
        }
        optionNumber = 0;
        displayMenu(optionNumber);
    }

    //this function will display all entries saved in a content List 
    private void displayContent()
    {
        for (int i = 0; i < content.Count; i++)
        {
            Console.WriteLine(content[i]);
        }
        optionNumber = 0;
        displayMenu(optionNumber);
    }

    //this function will show prompt and as well recording the response 
    public void writeEntry()
    {
        Random rnd = new Random();
        //get user option
        int qNum = rnd.Next(entryArray.Length);
        //display the prompt question
        Console.WriteLine(entryArray[qNum]);
        //indicate user typing
        Console.Write("> ");
        //get the user input
        readResponse = Console.ReadLine();
        //current date
        dateText = theCurrentTime.ToShortDateString();
        //save content 
        content.Add("Date: " + dateText + " - " + "Prompt: " + entryArray[qNum]);
        content.Add(readResponse);
        content.Add(" ");
        //set default option number selected
        optionNumber = 0;
        //display menu
        displayMenu(optionNumber);
    }



}
