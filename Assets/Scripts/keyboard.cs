using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboard : MonoBehaviour
{
	public string OpenKeyboard()
	{
		TouchScreenKeyboard.Open("");
		return "";
	}
}
