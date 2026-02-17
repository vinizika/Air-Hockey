using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("vars")]
    public Transform puck;
    public Rigidbody2D puckRb;

    [Header("setup")]
    public float resetDelay = 0.6f;
    public Vector2 puckStartPos = Vector2.zero;
    public float initialSpeed = 8f;

    [Header("score")]
    public int playerScore = 0;
    public int botScore = 0;

    [HideInInspector] public bool isResetting = false;

    private float timer = 0f;

    void Start()
    {
        if (puckRb == null && puck != null) puckRb = puck.GetComponent<Rigidbody2D>();
        LaunchPuck(); 
    }

    void Update()
    {
        if (isResetting)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                isResetting = false;
                LaunchPuck();
            }
        }
    }

    public void AddPointPlayer()
    {
        playerScore++;
        ResetPuck();
    }

    public void AddPointBot()
    {
        botScore++;
        ResetPuck();
    }

    private void ResetPuck()
    {
        if (puck == null || puckRb == null) return;

        isResetting = true;
        timer = resetDelay;

        puckRb.linearVelocity = Vector2.zero;
        puckRb.angularVelocity = 0f;
        puck.position = new Vector3(puckStartPos.x, puckStartPos.y, puck.position.z);
    }

    private void LaunchPuck()
    {
        if (puckRb == null) return;

        float dirX = (Random.value < 0.5f) ? -1f : 1f;
        float dirY = Random.Range(-0.6f, 0.6f);

        Vector2 dir = new Vector2(dirX, dirY).normalized;
        puckRb.linearVelocity = dir * initialSpeed;
    }
}
