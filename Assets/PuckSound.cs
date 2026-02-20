using UnityEngine;

public class PuckSound : MonoBehaviour
{
    public AudioClip hitClip;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        if (source == null) source = gameObject.AddComponent<AudioSource>();

        source.playOnAwake = false;
        source.loop = false;
        source.spatialBlend = 0f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("COLIDIU COM: " + collision.gameObject.name);

        if (hitClip != null)
            source.PlayOneShot(hitClip);
    }
}