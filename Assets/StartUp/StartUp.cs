using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using ZXing;
using System;

public class StartUp : MonoBehaviour
{
	private Text ButtonText;
	public RawImage Image;
	private WebCamTexture WebcamTexture;
	Scanner Scanner;


	void Awake ()
	{
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
	}
	// Use this for initialization
	void Start ()
	{
		InitializeAndStartCamera ();
		Scanner = gameObject.AddComponent<Scanner> ();
		ButtonText = GameObject.Find ("Text").GetComponent<Text> ();
	}

	public void OnClick ()
	{
		if (!Scanner.Scanning)
			Scanner.decodeImage (WebcamTexture);
		else
			Scanner.stopScanning ();
		setButtonText ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void InitializeAndStartCamera ()
	{
		WebcamTexture = new WebCamTexture ();
		Image.texture = WebcamTexture;
		Image.material.mainTexture = WebcamTexture;
		WebcamTexture.Play ();
	}

	void setButtonText ()
	{
		ButtonText.text = Scanner.Scanning == true ? "Stop" : "Scan";
	}
}
