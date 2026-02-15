using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Limites do jogador (metade de baixo)")]
    public float minX = -3.7f;
    public float maxX =  3.7f;
    public float minY = -6.0f;
    public float maxY =  0.0f;   // linha do meio (player não passa dela)

    [Header("Velocidade do jogador")]
    public float moveSpeed = 20f; // Ajuste da velocidade do movimento

    private Rigidbody2D rb;

    void Start()
    {
        // Inicializa o Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Posição do mouse no mundo
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mouseX = mouseWorld.x;
        float mouseY = mouseWorld.y;

        // Lógica de movimento com ifs para controlar os limites
        if (mouseX < minX)
        {
            mouseX = minX;
        }
        else if (mouseX > maxX)
        {
            mouseX = maxX;
        }

        if (mouseY < minY)
        {
            mouseY = minY;
        }
        else if (mouseY > maxY)
        {
            mouseY = maxY;
        }

        // Movimenta o jogador (mallet)
        rb.position = new Vector2(mouseX, mouseY);

        // Ajusta a velocidade do movimento (caso necessário)
        // Isso já deve estar resolvido com a mudança no valor de "moveSpeed"
    }
}
