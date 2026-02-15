using UnityEngine;

public class PuckControl : MonoBehaviour
{
    private Rigidbody2D rb;

    public float initialSpeed = 10f;

    void Start()
    {
        // Inicializa o Rigidbody2D da bolinha
        rb = GetComponent<Rigidbody2D>();

        // Lança a bolinha aleatoriamente na direção do eixo X ou Y
        LaunchPuck();
    }

    void LaunchPuck()
    {
        // Lança a bolinha em uma direção aleatória
        float directionX = Random.Range(0, 2) == 0 ? -1f : 1f; // aleatório entre -1 e 1 (direções X)
        float directionY = Random.Range(-1f, 1f);  // aleatório no eixo Y

        // Aplica uma força inicial
        rb.linearVelocity = new Vector2(directionX, directionY).normalized * initialSpeed;
    }
}
