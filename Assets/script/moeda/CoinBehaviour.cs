using UnityEngine;
 
public class CoinBehaviour : MonoBehaviour
{
    // Variáveis configuráveis no Unity Inspector
    public float rotationSpeed = 100f; // Velocidade de rotação da moeda
    public float floatAmplitude = 0.5f; // Amplitude do movimento de flutuação
    public float floatFrequency = 1f; // Frequência do movimento de flutuação
    public AudioClip pickupSound; // Som ao coletar a moeda
    public ParticleSystem pickupEffect; // Partícula ao coletar a moeda
 
    private Vector3 startPosition; // Posição inicial da moeda
 
    void Start()
    {
        // Salva a posição inicial
        startPosition = transform.position;
    }
 
    void Update()
    {
        // Faz a moeda girar
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
 
        // Faz a moeda flutuar
        float newY = startPosition.y + Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
 
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador coletou a moeda (supondo que o jogador tenha a tag "Player")
        if (other.CompareTag("Player"))
        {
            // Toca o som de coleta (se configurado)
            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }
 
            // Ativa o efeito de partículas (se configurado)
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }
 
            // Desativa a moeda (ou destrói)
            Destroy(gameObject);
        }
    }
}