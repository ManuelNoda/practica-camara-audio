using UnityEngine;

public class CameraInput : MonoBehaviour
{
    public CameraController cameraController;
    private int captureCounter = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            cameraController.StartCamera();

        if (Input.GetKeyDown(KeyCode.P))
            cameraController.PauseCamera();

        if (Input.GetKeyDown(KeyCode.D))
            cameraController.StopCamera();

        if (Input.GetKeyDown(KeyCode.X))
            SaveCapture();
    }

    void SaveCapture()
    {
        Texture2D tex = cameraController.CaptureFrame();
        if (tex == null) return;

        string folder = Application.dataPath + "/Capturas/";
        System.IO.Directory.CreateDirectory(folder);

        string path = folder + "foto_" + captureCounter++ + ".png";
        System.IO.File.WriteAllBytes(path, tex.EncodeToPNG());

        Debug.Log("Imagen guardada: " + path);
    }
}
