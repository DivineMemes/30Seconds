using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public string playerName;
    
	public void TextChanged(string input)
    {
        playerName = input;
    }
}
