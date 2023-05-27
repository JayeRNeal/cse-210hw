using System;
using System.IO;

class Program
{
    static void Main(string[] args){
        Scripture myScripture = new Scripture();
        myScripture.Display();
        string entry = "";
        while (myScripture.CompletelyHidden() is false && entry.ToLower() !="q") //
        {
            Console.Write("Press enter to hide words or type 'q' to quit ");
            entry = Console.ReadLine();
            myScripture.HideWords();
            myScripture.Display();
        
        }
    }

public class Reference
{
    private string _bookName;

    private string _chapter;

    private string _verse;

    public string getBook()
    {
        return _bookName;
    }
    public string getChapter()
    {
        return _chapter; // misspell?
    }
    public string getVerse()
    {
        return _verse;
    }
    public string setBook(string Book)
    {
        _bookName = Book;
        return _bookName;
    }
    public string setChapter(string Chapter)
    {
        _chapter = Chapter;
        return _chapter; // misspell?
    }
    public string setVerse1(string Verse1)
    {
        _verse = Verse1;
        return _verse;
    }


    public Reference()
    {

    }
    public Reference(string Book, string Chapter, string Verse)
    {
    _bookName = Book;
    _chapter = Chapter; // possible error
    _verse = Verse;
    }

    public Reference(string Book, string Chapter, string startVerse, string endVerse)
    {
    _bookName = Book; // fix error
    _chapter = Chapter;
    _verse = $"{startVerse}-{endVerse}";
    }
    public string GetReferenceToString()
    {
    return $"{_bookName} {_chapter}:{_verse}"; // fix error
    }
}
public class Scripture
{
    Reference myReference = new Reference("Joseph Smith - History","1","16","17");
    
    private List<Word> scripture = new List<Word>();

    public string passage = "I saw a pillar of light exactly over my head, above the brightness of the sun, which descended gradually until it fell upon me. When the light rested upon me I saw two Personages, whose brighntess and glory defy all description, standing above me in the air. One of them spake unto me, calling me by name and said, pointing to the other— This is My Beloved Son. Hear Him!";

    public string[] wordList;

    public Scripture()
    {
        SplitPassage();
    }

    public void SplitPassage()
    {
        wordList = passage.Split(" ");
        foreach (string word in wordList)
        {
            Word text = new Word(word);
            scripture.Add(text); 
        }
    }

    public void HideWords()
    {
        int i = 0;
        Random count = new Random();
        int randomCount = count.Next(1,5);

        while (i<randomCount && !(CompletelyHidden()))
        {
            Random random = new Random();
            int randomNum = random.Next(scripture.Count);

            if (!(scripture[randomNum].GetIsHidden()))
            {
                scripture[randomNum].Hide();
                i++;
            }
        }
    }
    public bool CompletelyHidden()
    {
        foreach (Word word in scripture)
        {
            if (!(word.GetIsHidden()))
            {
                return false;
            }
        }
        return true;
    }

    public string GetScriptureText()
    {
        string text = "";
        foreach (Word word in scripture)
        {
            text = text + " " + word.GetWord();
        }
        return text;
    }

    public void Display()
    {
        Console.Clear();

        Console.WriteLine($"{myReference.GetReferenceToString()} - {GetScriptureText()}"); // missing GetScriptureText() public string
    }

    public string setPassage(string Script)
    {
        passage = Script;
        return passage;
    }
public class Word
{
    private string _word;

    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public void Hide()
    {
        char[] characters = _word.ToCharArray();

        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != ',' && characters[i] != ':' && characters[i] != '.' && characters[i] !=';' && characters[i] !='"' && characters[i] !='?' && characters[i] !=']' && characters[i] !='[' && characters[i] !='}' && characters[i] !='{' && characters[i] !='(' && characters[i] !=')' && characters[i] !='!' && characters[i] !='~' && characters[i] !='`' && characters[i] != '—')
            {
            characters[i] = '_';
            }
        _word = new string(characters);
        _isHidden = true;
        }
    }
    public bool GetIsHidden()
    {
        return _isHidden;
    }
        public string GetWord()
        {
            return _word;
        }
    }
}    
}
