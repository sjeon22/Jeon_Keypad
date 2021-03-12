using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination // need to store and tell us combination 
{
    private List<int> combination; // private bc access combination through method, so that thing outside of class can't change the combination
    private List<int> defaultCombination = new List<int> { 2, 6, 1, 9 };

    public Combination() // constructor, doesn't have return value but doesn't put void 
    {
        combination = CombinationLoader.Load(defaultCombination);
    }

    public int GetCombinationDigit(int digitNumber)
    {
        if (digitNumber < 0)
            return 0;

        if (digitNumber >= combination.Count) // this will tell us how many are in the list 
            return 0; // return 0 if the digitNumber has more than whats in the list

        return combination[digitNumber];
    }

    public int GetCombinationLength()
    {
        return combination.Count; // will return how long the combination is 
    }
}
