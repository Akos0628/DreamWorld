using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateVoice : MonoBehaviour
{
    [SerializeField]
    private WitService wit;
	public InputActionProperty showButton;

	// Update is called once per frame
	void Update()
    {
        if(wit == null) 
            wit = GetComponent<WitService>();

		if (showButton.action.WasPressedThisFrame())
		{
            WitActivate();
		}

		if (showButton.action.WasReleasedThisFrame())
		{
			WitDeactivate();
		}
	}

    public void WitActivate()
    {
        if(!wit.Active)
            wit.Activate();
    }

	public void WitDeactivate()
	{
		wit.Deactivate();
	}
}
