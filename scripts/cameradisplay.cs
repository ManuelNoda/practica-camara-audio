using UnityEngine;

public class CameraDisplay : MonoBehaviour
{
    public CameraController cameraController;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (cameraController != null && cameraController.webcamTexture != null)
        {
            mat.mainTexture = cameraController.webcamTexture;
        }
    }
}
