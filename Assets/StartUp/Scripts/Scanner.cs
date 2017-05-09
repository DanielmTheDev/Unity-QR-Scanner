using UnityEngine;
using UnityEngine.UI;
using ZXing;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace StartUp.Scripts
{
    public class Scanner : MonoBehaviour
    {
        public bool Scanning { get; private set; }
        private BarcodeReader _reader;
        private Result _result;
        private WebCamTexture _webcamTexture;
        private Text _buttonText;

        private void Start()
        {
            _buttonText = GameObject.Find("Text").GetComponent<Text>();
            _reader = new BarcodeReader();
            Scanning = false;
        }

        private void Update()
        {
            if (!Scanning)
                return;
            CheckForQrCode();
        }

        public void StartScanning(WebCamTexture webcamTexture)
        {
            Scanning = true;
            SetButtonText();
            _webcamTexture = webcamTexture;
        }

        public void StopScanning()
        {
            Scanning = false;
            SetButtonText();
        }

        private void CheckForQrCode()
        {
            Color32[] pixels = _webcamTexture.GetPixels32();
            int width = _webcamTexture.width;
            int height = _webcamTexture.height;
            _result = _reader.Decode(pixels, width, height);

            if (_result == null)
                return;
            StopScanning();
            DisplaySuccessDialog();
        }

        private void SetButtonText()
        {
            _buttonText.text = Scanning ? "Stop" : "Scan";
        }

        private void DisplaySuccessDialog()
        {
            #if UNITY_EDITOR
            EditorUtility.DisplayDialog("QR Code found", _result.Text, "Ok", "Cancel");
            #endif
        }
    }
}