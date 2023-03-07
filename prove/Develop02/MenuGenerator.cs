using System;

class MenuGenerator
{
    public int displayMenuOption()
    {
        //create a list of option to display
        string[] optionArray = {
        "Please select one of the following Choices",
        "1. Write",
        "2. Display",
        "3. Load",
        "4. Save",
        "5. Quit",
       };
        foreach (var item in optionArray)
        {
            Console.WriteLine(item);
        }
        Console.Write("What would you like to do today? ");
        int selectedOption = Convert.ToInt32(Console.ReadLine());
        return selectedOption;
    }




}

