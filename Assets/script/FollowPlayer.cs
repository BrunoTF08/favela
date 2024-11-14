using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;  // Referência para o jogador
    public float followSpeed = 5f;  // Velocidade com que o chinelo vai seguir o jogador
    public float followDistance = 1f;  // Distância do chinelo em relação ao jogador
    public AudioClip reachPlayerSound;  // Som a ser tocado quando o chinelo atingir o jogador
    private AudioSource audioSource;  // Componente AudioSource para tocar o som
    public Transform respawnPoint;  // Ponto de respawn do jogador
    private bool hasPlayedSound = false;  // Flag para garantir que o som seja tocado uma vez

    private void Start()
    {
        // Obtém o componente AudioSource do objeto
        audioSource = GetComponent<AudioSource>();

        // Verifica se o componente AudioSource foi atribuído corretamente
        if (audioSource == null)
        {
            Debug.LogError("AudioSource não encontrado no objeto!");
        }
    }

    private void Update()
    {
        // Verifica se o jogador foi atribuído no Inspector
        if (player != null)
        {
            // Calcula a posição de destino para o chinelo
            Vector3 targetPosition = player.position - player.forward * followDistance;

            // Move o chinelo suavemente em direção à posição do jogador usando Lerp
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // Verifica se o chinelo chegou perto o suficiente do jogador
            if (!hasPlayedSound && Vector3.Distance(transform.position, player.position) <= followDistance)
            {
                // Toca o som quando o chinelo chega perto do jogador
                PlaySound();

                // Marca que o som foi tocado para não tocar novamente
                hasPlayedSound = true;
            }
        }
    }

    private void PlaySound()
    {
        // Verifica se o som foi atribuído
        if (reachPlayerSound != null)
        {
            // Reproduz o som
            audioSource.PlayOneShot(reachPlayerSound);
            Debug.Log("Som tocado: " + reachPlayerSound.name);
        }
        else
        {
            Debug.LogError("Som não atribuído no Inspector!");
        }
    }

    // Detecta quando o chinelo entra em contato com o jogador
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (other.CompareTag("Player"))
        {
            // Teleporta o jogador para o ponto de respawn
            if (respawnPoint != null)
            {
                other.transform.position = respawnPoint.position;
                Debug.Log("Jogador teleportado para o ponto de respawn!");
            }
            else
            {
                Debug.LogError("Ponto de respawn não atribuído no Inspector!");
            }
        }
    }
}
