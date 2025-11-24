using UnityEngine;

public class PushToRecord : MonoBehaviour
{
    public AudioSource audioSource;
    private AudioClip recordedClip;

    public int sampleRate = 44100;

    private bool isRecording = false;

    void Update()
    {
        // Cuando P se PRESIONA → empezar la grabación
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartRecording();
        }

        // Cuando P se SUELTA → detener la grabación
        if (Input.GetKeyUp(KeyCode.P))
        {
            StopRecording();
        }
    }

    void StartRecording()
    {
        if (!isRecording)
        {
            isRecording = true;
            recordedClip = Microphone.Start("", false, 10, sampleRate); // máximo 10 segundos
            Debug.Log("Grabando...");
        }
    }

    void StopRecording()
    {
        if (isRecording)
        {
            isRecording = false;
            Microphone.End("");
            Debug.Log("Grabación detenida.");

            // Asignar clip al AudioSource
            audioSource.clip = recordedClip;
        }
    }

    public void PlayRecorded()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
