using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Proverbs 3:5-6", "Trust in the LORD with all your heart, and do not lean on your own understanding. In all your ways acknowledge him, and he will make straight your paths.");
        Console.WriteLine("Press enter to begin memorizing the scripture or type 'quit' to exit.");
        string input = Console.ReadLine();

        while (input != "quit")
        {
            Console.Clear();
            scripture.HideRandomWords();
            Console.WriteLine(scripture.GetHiddenText());

            if (scripture.AllWordsHidden())
                break;

            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            input = Console.ReadLine();
        }
    }
}

class Scripture
{
    private string reference;
    private List<Verse> verses;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        verses = new List<Verse>();
        string[] verseArray = text.Split('.');
        foreach (string verseText in verseArray)
        {
            verses.Add(new Verse(verseText.Trim()));
        }
    }

    public bool AllWordsHidden()
    {
        return verses.All(verse => verse.AllWordsHidden());
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        foreach (Verse verse in verses)
        {
            List<Word> visibleWords = verse.GetVisibleWords();
            if (visibleWords.Count > 0)
            {
                int index = random.Next(visibleWords.Count);
                visibleWords[index].Hide();
            }
        }
    }

    public string GetHiddenText()
    {
        string hiddenText = reference + "\n";
        foreach (Verse verse in verses)
        {
            hiddenText += verse.GetHiddenText() + "\n";
        }
        return hiddenText;
    }
}

class Verse
{
    private List<Word> words;

    public Verse(string text)
    {
        words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            words.Add(new Word(word));
        }
    }

    public List<Word> GetVisibleWords()
    {
        return words.Where(word => !word.IsHidden()).ToList();
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden());
    }

    public string GetHiddenText()
    {
        string hiddenText = "";
        foreach (Word word in words)
        {
            hiddenText += word.GetHiddenText() + " ";
        }
        return hiddenText.Trim();
    }
}

class Word
{
    private string text;
    private bool hidden;

    public Word(string text)
    {
        this.text = text;
        hidden = false;
    }

    public bool IsHidden()
    {
        return hidden;
    }

    public void Hide()
    {
        hidden = true;
    }

    public string GetHiddenText()
    {
        return hidden ? "_____" : text;
    }
}
