using StartUp.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace StartUp
{
    public class StartUp : MonoBehaviour
    {
        public RawImage Image;
        private WebCamTexture _webcamTexture;
        private Scanner _scanner;

        private void Start()
        {
            InitializeAndStartCamera();
            _scanner = gameObject.AddComponent<Scanner>();
        }

        public void OnClick()
        {
            if (!_scanner.Scanning)
                _scanner.StartScanning(_webcamTexture);
            else
                _scanner.StopScanning();
        }

        private void InitializeAndStartCamera()
        {
            _webcamTexture = new WebCamTexture();
            Image.texture = _webcamTexture;
            Image.material.mainTexture = _webcamTexture;
            _webcamTexture.Play();
        }
    }
}