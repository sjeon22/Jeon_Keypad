using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public KeypadBackground background;
    private Combination combination;
    private List<int> buttonsEntered; // type list, <> this is notation to tell 'what type'  

    // Start is called before the first frame update
    void Start()
    {
        combination = new Combination();
        ResetButtonEntries();
    }

    public void RegisterButtonClick(int buttonValue)
    {
        buttonsEntered.Add(buttonValue); // to the list add buttonvalue
        print(String.Join(", ", buttonsEntered)); // w/o type string it will print 'System Collection Generic List 1'
                                                  // String <- wrapper class (?), needs 'using System'
    }

    public void TryToUnlock() // if entered correrct combination then unlock, else, fail
    {
        if (IsCorrectCombination())
            Unlock();
        else
            FailToUnlock();

        ResetButtonEntries(); // this re-ceates entry list
    }

    private bool IsCorrectCombination() // bool - true/false return these when correct/incorrect
    {
        if (HaveNoButtonsBeenClicked())
            return false;
        
        if (HaveWrongNumberOfButtonsBeenClicked())
            return false;

        return CheckCombination();
    }

    private bool HaveNoButtonsBeenClicked()
    {
        if (buttonsEntered.Count == 0)
            return true;
        return false;
    }

    private bool HaveWrongNumberOfButtonsBeenClicked()
    {
        if (buttonsEntered.Count == combination.GetCombinationLength())
            return false;
        return true;
    }

    private bool CheckCombination()
    {
        // go through each numbers typed and compared them with the combination
        for (int buttonIndex = 0; buttonIndex < buttonsEntered.Count; buttonIndex++)
        //at index 0, if index is less than buttons entered, everytime we go through the loop increase buttonIndex by 1 
        {
            // if number entered isn't the combination return false
            if (IsCorrectButton(buttonIndex) == false)
                return false;
        }
        return true;
    }

    private bool IsCorrectButton(int buttonIndex) // bool expects a return value
    {
        if (IsWrongEntry(buttonIndex))
            return false;
        return true;
    }

    private bool IsWrongEntry(int buttonIndex) // compares the entry with the combination
    {
        if (buttonsEntered[buttonIndex] == combination.GetCombinationDigit(buttonIndex)) // from combination class
            return false;
        return true; // yes it is wrong 
    }

    private void Unlock() // when it unlocks, hide the button and change the bg color to green
    {
        background.HideUnlockButton();
        background.ChangeToSuccessColor();
    }

    private void FailToUnlock() // make bg flash red
    {
        background.ChangeToFailedColor();
        StartCoroutine(ResetBackgroundColor());
    }

    private IEnumerator ResetBackgroundColor() // we want to give time before they print red bg
    {
        yield return new WaitForSeconds(0.25f);
        background.ChangeToDefaultColor();
    }

    private void ResetButtonEntries() // made separate method to get away from duplicating code
    {
        buttonsEntered = new List<int>();
    }
}
