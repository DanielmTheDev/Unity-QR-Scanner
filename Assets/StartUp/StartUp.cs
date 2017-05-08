using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ZXing;
using System;

public class StartUp : MonoBehaviour
{
	public WebCamTexture webcamTexture { get; private set; }
	public UnityEngine.UI.RawImage image;
	public BarcodeReader Reader;

	event EventHandler OnReady;

	void Awake ()
	{
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
	}
	// Use this for initialization
	void Start ()
	{
		Reader = new BarcodeReader ();
		webcamTexture = new WebCamTexture ();
		image.texture = webcamTexture;
		image.material.mainTexture = webcamTexture;
		webcamTexture.Play ();
	}

	public void OnClick ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
