using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;

public class Scanner : MonoBehaviour
{
	private BarcodeReader Reader;
	private Result Result;
	private WebCamTexture WebcamTexture;

	public bool Scanning{ get; private set; }

	// Use this for initialization
	void Start ()
	{
		Reader = new BarcodeReader();
		Scanning = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!Scanning)
			return;
		Color32[] Pixels = WebcamTexture.GetPixels32 ();
		Result = Reader.Decode (Pixels, 400, 400);
		if (Result != null) {
			Debug.Log (Result.Text);
			Scanning = false;
		} else
			Debug.Log ("Nichts gefunden");
	}

	public void decodeImage (WebCamTexture webcamTexture)
	{
		Scanning = true;
		WebcamTexture = webcamTexture;
	}

	public void stopScanning ()
	{
		Scanning = false;
	}
}
