using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int cameraIndex = 0;

    public WebCamTexture webcamTexture { get; private set; }

    void Start()
    {
        InitializeCamera();
        //sStartCamera();
    }

    public void InitializeCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogError("No hay cámaras disponibles.");
            return;
        }

        cameraIndex = Mathf.Clamp(cameraIndex, 0, devices.Length - 1);

        Debug.Log("Cámara seleccionada: " + devices[cameraIndex].name);

        webcamTexture = new WebCamTexture(devices[cameraIndex].name);
    }

    public void StartCamera()
    {
        if (webcamTexture != null && !webcamTexture.isPlaying)
        {
            webcamTexture.Play();
            Debug.Log("Cámara iniciada.");
        }
    }

    public void PauseCamera()
    {
        if (webcamTexture != null && webcamTexture.isPlaying)
        {
            webcamTexture.Pause();
            Debug.Log("Cámara pausada.");
        }
    }

    public void StopCamera()
    {
        if (webcamTexture != null)
        {
            webcamTexture.Stop();
            Debug.Log("Cámara detenida.");
        }
    }

    public Texture2D CaptureFrame()
    {
        if (webcamTexture == null || !webcamTexture.isPlaying)
        {
            Debug.LogWarning("No se puede capturar sin cámara activa.");
            return null;
        }

        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();

        return snap;
    }
}
