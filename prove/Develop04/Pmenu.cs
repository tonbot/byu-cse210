using System;

class Pmenu
{

    private List<String> menu = new List<String> {
    "1. Start breathing activity",
    "2. Start reflecting activity",
    "3. Start listing  activity",
    "4. Quit",
};

    public List<String> getMenu()
    {
        return menu;
    }

    //this is displaying all menu
    public int displayMenu()
    {
        Console.WriteLine("Menu Options:");
        foreach (var item in menu)
        {
            Console.WriteLine(" " + " " + item);
        }
       return Convert.ToInt32(getUserInput("Select a choice from the menu: "));
    }

    //this only get option selected
    public String getMenuOption(int opt_num)
    {
        return menu[opt_num];
    }


    public String getUserInput(String prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

}