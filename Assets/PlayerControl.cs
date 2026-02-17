using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("vars")]
    public float minX = -3.7f;
    public float maxX =  3.7f;
    public float minY = -6.0f;
    public float maxY =  0.0f;
    public float speed = 11f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mouseWorld.x;
        float mouseY = mouseWorld.y;

        if (mouseX < minX) mouseX = minX;
        else if (mouseX > maxX) mouseX = maxX;

        if (mouseY < minY) mouseY = minY;
        else if (mouseY > maxY) mouseY = maxY;

        Vector2 target = new Vector2(mouseX, mouseY);
        Vector2 dir = (target - rb.position);

        rb.linearVelocity = dir * speed;
    }
}
