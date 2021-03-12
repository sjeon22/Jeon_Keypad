using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class CombinationLoader
{
    private static string combinationFolderName = "Assets/Text/";
    private static string combinationFileName = "combination.txt";
    private static string combinationPath // variables can also be property, mini method
    {
        get  
        {
            return Path.Combine(combinationFolderName, combinationFileName);
        }
    }

    public static List<int> Load(List<int> defaultCombination)
    {
        EnsureFileExists(defaultCombination);
        return ReadCombinationFromFile();
    }

    private static void EnsureFileExists(List<int> defaultCombination)
    {
        if (!File.Exists(combinationPath))
            CreateFile(defaultCombination);
    }

    private static void CreateFile(List<int> defaultCombination) // holds defult combination
    {
        EnsureDirectoryExists();

        StreamWriter writer = new StreamWriter(combinationPath);
        foreach (int combinationEntry in defaultCombination)
        {
            writer.WriteLine(combinationEntry);
        }
        writer.Close();
    }

    private static void EnsureDirectoryExists() // ensure that folder exists, if not create
    {
        if (!Directory.Exists(combinationFolderName))
            Directory.CreateDirectory(combinationFolderName);
    }
    public static List<int> ReadCombinationFromFile()
    {
        List<int> combination = new List<int>();

        StreamReader reader = new StreamReader(combinationPath);
        string combinationNumber = string.Empty;
        while ((combinationNumber = reader.ReadLine()) != null) // put whatever readline gave us in combinationNumber and make sure its not null
        {
            int combinationInteger = int.Parse(combinationNumber); // string -> int
            combination.Add(combinationInteger);
        }
        reader.Close();

        return combination;
    }
}
