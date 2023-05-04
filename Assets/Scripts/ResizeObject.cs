using Oculus.Interaction.Input;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.GraphicsBuffer;

public class ResizeObject : MonoBehaviour
{
    public XRDirectInteractor interactor;
    public InputActionProperty resizeAction;

	// Update is called once per frame
	void Update()
    {
        //var p = 1 + resizeAction.action.ReadValue<Vector2>().y/10f;
		//
		//if (p > 1.01f || p < 0.99f)
		//{
		//	if (interactor.selectTarget != null)
		//	{
		//		var newObject = Instantiate(interactor.selectTarget);
		//
		//		var initialObjectScale = newObject.transform.localScale;
		//		Vector3 newScale = new Vector3(p * initialObjectScale.x, p * initialObjectScale.y, p * initialObjectScale.z); // calculate new object scale with p
		//
		//		newObject.transform.localScale = newScale; // set new scale
		//	}
		//		
		//}
    }
}
