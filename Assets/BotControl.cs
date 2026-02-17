using UnityEngine;

public class BotControl : MonoBehaviour
{
    [Header("vars")]
    public Transform puck;

    public float fixedY = 4.5f;

    public float minX = -3.7f;
    public float maxX =  3.7f;
    public float minY =  0.0f;
    public float maxY =  6.0f;
    public float speed = 15f;
    public float stuckSpeedThreshold = 0.05f; 
    public float stuckPushTime = 0.5f; 

    private Rigidbody2D rb;
    private Rigidbody2D puckRb;

    private float pushTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = new Vector2(rb.position.x, fixedY);

        if (puck != null)
            puckRb = puck.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (puck == null) return;
        if (puckRb == null) puckRb = puck.GetComponent<Rigidbody2D>();

        bool puckOnBotSide = puck.position.y > 0f;
        bool puckStopped = (puckRb != null && puckRb.linearVelocity.magnitude <= stuckSpeedThreshold);

        if (puckOnBotSide && puckStopped)
            pushTimer = stuckPushTime;

        Vector2 target;

        if (pushTimer > 0f)
        {
            pushTimer -= Time.deltaTime;

            float x = puck.position.x;
            float y = puck.position.y;

            if (x < minX) x = minX;
            else if (x > maxX) x = maxX;

            if (y < minY) y = minY;
            else if (y > maxY) y = maxY;

            target = new Vector2(x, y);
        }
        else
        {
            float x = puck.position.x;

            if (x < minX) x = minX;
            else if (x > maxX) x = maxX;

            float y = fixedY;
            if (y < minY) y = minY;
            else if (y > maxY) y = maxY;

            target = new Vector2(x, y);
        }

        Vector2 dir = target - rb.position;
        rb.linearVelocity = dir * speed; 
    }
}
