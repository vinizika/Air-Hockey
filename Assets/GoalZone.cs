using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [Header("ponto pro player ou pro bot?")]
    public bool pointForPlayer = false; 

    [Header("vars")]
    public Transform puck;             
    public GameManager gameManager;   

    private Collider2D goalCol;

    void Start()
    {
        goalCol = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (puck == null || gameManager == null || goalCol == null) return;
        if (gameManager.isResetting) return; 

        Vector2 p = puck.position;
        if (goalCol.bounds.Contains(p))
        {
            if (pointForPlayer) gameManager.AddPointPlayer();
            else gameManager.AddPointBot();
        }
    }
}
