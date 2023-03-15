using System;

class VerseGenerator {

  private List<String> verseContent = new List<String>{
      "rust in the Lord with all your heart and lean not on your own understanding;",
      "in all your ways submit to him, and he will make your paths straight",
      "Be not wise in thine own eyes: fear the Lord, and depart from evil.",
      "It shall be health to thy navel, and marrow to thy bones.",
  };
 private List<String> verse = new List<String>{
      "Proverbs 3:5 ",
      "Proverbs 3:6 ",
      "Proverbs 3:7 ",
      "Proverbs 3:8 ",
  };

public String getVerse(int index){
    return verse[index];
}


public String getVerseContent(int index){
    return verseContent[index];
}

public int displayVerse(){
  var i = 1;
  foreach (var item in verse)
  {
    Console.WriteLine(i + " " + item );
    i++;
  }
  int option = Convert.ToInt32(Console.ReadLine());
  return option;
}
}