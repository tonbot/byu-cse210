using System;

class Program
{
    static void Main(string[] args)
    {
        //creating an object of Activity class
        Activity activity = new Activity();
        //display menu and prompt user for menu option
        int option = activity.displayMenu();
        //start activity base on user option
        activity.startActivity(option);
    }
}