using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButtonsEventHandler : MonoBehaviour, IVirtualButtonEventHandler {

	private GameObject model;
	private bool isRotateLeft;
	private bool isRotateRight;
	private bool isScalePlus;
	private bool isScaleMinus;

	public int _RotationSpeed;

	// Use this for initialization
	void Start () 
	{
		model = GameObject.Find ("3dModel");
		VirtualButtonBehaviour[] vuforiaButtons = GetComponentsInChildren<VirtualButtonBehaviour>();
		foreach (VirtualButtonBehaviour buttons in vuforiaButtons) {
			buttons.RegisterEventHandler (this);
		}
	}

	void Update () 
	{
		if (isRotateLeft) 
		{
            model.transform.Rotate (Vector3.down * Time.deltaTime * _RotationSpeed, Space.Self);
		}
		if (isRotateRight) 
		{
            model.transform.Rotate (Vector3.up * Time.deltaTime * _RotationSpeed, Space.Self);
		}
		if (isScalePlus) 
		{
			model.transform.localScale += new Vector3 (0.000015f, 0.000015f, 0.000015f);
		}
		if (isScaleMinus)
		{
			model.transform.localScale -= new Vector3 (0.000015f, 0.000015f, 0.000015f);
		}
	}


	public void OnButtonPressed (VirtualButtonAbstractBehaviour vb)
	{
		switch (vb.VirtualButtonName) {
		case "RotateLeft":
			isRotateLeft = true;
			break;
		case "RotateRight":
			isRotateRight = true;
			break;
		case "ScalePlus":
			isScalePlus = true;
			break;
		case "ScaleMinus":
			isScaleMinus = true;
			break;
		}
	}

	public void OnButtonReleased (VirtualButtonAbstractBehaviour vb)
	{
		switch (vb.VirtualButtonName) {
		case "RotateLeft":
			isRotateLeft = false;
			break;
		case "RotateRight":
			isRotateRight = false;
			break;
		case "ScalePlus":
			isScalePlus = false;
			break;
		case "ScaleMinus":
			isScaleMinus = false;
			break;
		}
	}
}
