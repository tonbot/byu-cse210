using System;

class Program
{
    static void Main(string[] args)
    {
        Hideword hideword =  new Hideword();
        Console.WriteLine("Please Select the verse to memorize today");
        int option = hideword.displayVerse();
        hideword.hide(true, option-1 );
    }
}