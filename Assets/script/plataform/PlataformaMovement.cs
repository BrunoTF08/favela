using UnityEngine;

public class PlataformaMovement : MonoBehaviour
{
    public float moveSpeed = 2f;  // Velocidade do movimento da plataforma
    public float moveDistance = 3f;  // Distância máxima para cima e para baixo
    public Vector3 startPoint;  // Ponto inicial da plataforma

    private void Start()
    {
        // Salva o ponto de partida da plataforma (onde ela começa a se mover)
        startPoint = transform.position;
    }

    private void Update()
    {
        // Calcula o movimento oscilante com a função Mathf.PingPong
        float newY = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
        
        // Define a nova posição da plataforma (somente no eixo Y)
        transform.position = new Vector3(startPoint.x, startPoint.y + newY, startPoint.z);
    }
}
