using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal class Program
{
    private const string filePath = "words.txt";
    private static Dictionary<string, string> dictionary = new Dictionary<string, string>();


    static void Main( string[] args )
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        LoadDictionary();
        Console.WriteLine( "The dictionary is ready to use" );
        while ( true )
        {
            DisplayMenuOptions();
            ChooseMenuOption();
        }
    }

    static void ChooseMenuOption()
    {
        bool isValidInput = int.TryParse( Console.ReadLine(), out int choice );
        if ( !isValidInput )
        {
            Console.WriteLine( "Please enter a valid number." );
        }
        else
        {
            switch ( choice )
            {
                case 1:
                    TranslateWord();
                    break;
                case 2:
                    AddWord();
                    break;
                case 3:
                    Console.WriteLine( "Exiting the program..." );
                    Environment.Exit( 0 );
                    break;
                default:
                    Console.WriteLine( "Wrong Choice" );
                    break;
            }
        }
    }

    static void DisplayMenuOptions()
    {
        Console.WriteLine( "What do you want to do?" );
        Console.WriteLine( "1. Translate the word" );
        Console.WriteLine( "2. Add a word" );
        Console.WriteLine( "3. Exit" );
    }

    static void LoadDictionary()
    {
        if ( !File.Exists( filePath ) )
        {
            SaveDictionary();
        }

        foreach ( var line in File.ReadAllLines( filePath, Encoding.UTF8 ) )
        {
            var parts = line.Split( ':' );
            if ( parts.Length == 2 )
            {
                dictionary[ parts[ 0 ].Trim() ] = parts[ 1 ].Trim();
            }
        }
    }

    static void SaveDictionary()
    {
        var lines = dictionary.Select( x => $"{x.Key}:{x.Value}" ).ToList();
        File.WriteAllLines( filePath, lines, Encoding.UTF8 );
    }

    static void TranslateWord()
    {
        Console.Write( "Enter the word to translate: " );
        string word = Console.ReadLine().Trim();

        if ( dictionary.TryGetValue( word, out string translation ) )
        {
            Console.WriteLine( $"Translation of {word} - {translation}" );
        }
        else
        {
            Console.WriteLine( "Word not found. Want to add it to your dictionary? [Y/N]" );
            string response = Console.ReadLine().ToUpper();

            while ( response != "Y" && response != "N" )
            {
                Console.WriteLine( "Please enter Y or N." );
                response = Console.ReadLine().ToUpper();
            }

            if ( response == "Y" )
            {
                AddWord();
            }
        }
    }

    static void AddWord()
    {
        Console.Write( "Enter a word to add: " );
        string word = Console.ReadLine().Trim();

        if ( !dictionary.ContainsKey( word ) )
        {
            Console.Write( "Enter word translation: " );
            string translation = Console.ReadLine().Trim();
            dictionary[ word ] = translation;
            dictionary[ translation ] = word;
            SaveDictionary();
            Console.WriteLine( "The word has been added successfully." );
        }
        else
        {
            Console.WriteLine( "This word is already in the dictionary." );
        }
    }
}