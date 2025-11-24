using UnityEngine;

public class wasd : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 moveInput;

    public AudioSource recorderAudioSource; // el AudioSource del PushToRecord

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        if (recorderAudioSource != null)
            recorderAudioSource.loop = true;
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (UnityEngine.InputSystem.Keyboard.current.wKey.isPressed) moveZ = 1f;
        if (UnityEngine.InputSystem.Keyboard.current.sKey.isPressed) moveZ = -1f;
        if (UnityEngine.InputSystem.Keyboard.current.aKey.isPressed) moveX = -1f;
        if (UnityEngine.InputSystem.Keyboard.current.dKey.isPressed) moveX = 1f;

        moveInput = new Vector3(moveX, 0f, moveZ).normalized;

        // Reproducir el clip mientras haya movimiento
        if (moveInput.magnitude > 0 && recorderAudioSource.clip != null)
        {
            if (!recorderAudioSource.isPlaying)
                recorderAudioSource.Play();
        }
        else
        {
            if (recorderAudioSource.isPlaying)
                recorderAudioSource.Stop();
        }
    }

    void FixedUpdate()
    {
        Vector3 move = moveInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
}
