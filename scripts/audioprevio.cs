using UnityEngine;

public class observadores : MonoBehaviour
{
    public EventoColision collision;
    public Transform escudo1;
    public Transform escudo2;
    Rigidbody rb;

    private AudioSource audioSource;
    public AudioClip sonidoTipo1;
    public AudioClip sonidoTipo2;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collision.colisionTipo1 += AddForceescudo1;
        collision.colisionTipo2 += AddForceescudo2;
        audioSource = GetComponent<AudioSource>();
    }

    void AddForceescudo1()
    {
        // Sonido tipo 1
        if (sonidoTipo1 != null)
            audioSource.PlayOneShot(sonidoTipo1);

        rb.AddForce((escudo1.transform.position - transform.position).normalized * 10, ForceMode.Impulse);
    }

    void AddForceescudo2()
    {
        // Sonido tipo 2
        if (sonidoTipo2 != null)
            audioSource.PlayOneShot(sonidoTipo2);

        rb.AddForce((escudo2.transform.position - transform.position).normalized * 10, ForceMode.Impulse);
    }
}