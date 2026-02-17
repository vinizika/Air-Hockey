using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float initialSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        LaunchPuck();
    }

    void LaunchPuck()
    {
        float directionX = Random.Range(0, 2) == 0 ? -1f : 1f; 
        float directionY = Random.Range(-1f, 1f); 

        rb.linearVelocity = new Vector2(directionX, directionY).normalized * initialSpeed;
    }
}
