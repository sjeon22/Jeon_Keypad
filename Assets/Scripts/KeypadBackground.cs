using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadBackground : MonoBehaviour // new class bc it doesn't have to do with unlock logic 
{
    public GameObject UnlockButton; // Gameobject bc 'inactive' function is of the game, not the button
    public Image BackgroundImage;

    public void HideUnlockButton() // easiest way to hide is to make it 'inactive' 
    {
        UnlockButton.SetActive(false);
    }

    public void ChangeToSuccessColor()
    {
        BackgroundImage.color = Color.green;
    }

    public void ChangeToFailedColor()
    {
        BackgroundImage.color = Color.red;
    }

    public void ChangeToDefaultColor()
    {
        BackgroundImage.color = Color.grey;
    }
}
