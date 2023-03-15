using System;

class Hideword : VerseGenerator
{

    private String sentence = "";
    private String command = "";
    List<int> prevWordHide = new List<int> { };
    private string[] words = { };
    int index;
    int index2;
    string hiddenSentence;

    string verse = "";

    public void hide(bool newStart, int verseIndex)
    {
        if (newStart == true)
        {
            start(verseIndex);
        }
        // Choose a random word to hide
        index = getIndex();
        if (prevWordHide.Count >= words.Length - 1)
        {
            return;
        }
        if (prevWordHide.Contains(index))
        {
            hide(false, verseIndex);
            return;
        };
        prevWordHide.Add(index);
        //display the hidden world to the console 
        displayHiddenWord();
        //quit if user input is quit
        if (command == "quit") { quit(); return;}
        sentence = hiddenSentence;
        hide(false, verseIndex);
    }


    private void start(int verseIndex)
    {

        verse = getVerse(verseIndex);
        sentence = getVerseContent(verseIndex);
        words = sentence.Split(' ');
        Console.WriteLine(verse + " " + sentence);
        Console.WriteLine( " ");
        Console.WriteLine("Please press \"Enter\" to contniue or type \"Quit\" to cancel");
        Console.ReadLine();
        Console.Clear();
    }

    private int getIndex()
    {
        Random rand = new Random();
        return rand.Next(words.Length);
    }

    private void displayHiddenWord()
    {
        string wordToHide = words[index];
        // Replace the chosen word with asterisks
        hiddenSentence = sentence.Replace(wordToHide, "****");

        Console.WriteLine(verse + " " + hiddenSentence);
        Console.WriteLine(" ");
        Console.WriteLine("Please press \"Enter\" to contniue or type 'Quit' to cancel");
        command = Console.ReadLine();
        Console.Clear();
        // Wait for user to press Enter key
    }
    private void quit()
    {
        Console.WriteLine("THANK YOU, SEE YOU NEXT TIME");
        return;
    }


}
