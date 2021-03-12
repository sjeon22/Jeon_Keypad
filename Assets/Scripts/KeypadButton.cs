using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KeypadButton : MonoBehaviour
{
    public int ButtonValue; // created 'ButtonValue' with datatype of int
    public Keypad Keypad; // called another class(a type) Keypad and named it 'Keypad'

    public void OnClick() 
    {
        Keypad.RegisterButtonClick(ButtonValue); // from class Keypad, brought RBC method and calls 'ButtonValue'
    }
}
