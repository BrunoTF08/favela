using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    private Animator animator;
    public AudioSource audioSource;
    public AudioClip collectSound;

    private CharacterMovement controls;

    // Referência ao collider do jogador (se for baseado em colisão 3D)
    public string playerTag = "Player";  // Garantir que o jogador tenha a tag 'Player'

    void Awake()
    {
        controls = new CharacterMovement();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        // Verifica se os componentes estão atribuídos
        if (animator == null) Debug.LogError("Animator não encontrado.");
        if (audioSource == null) Debug.LogError("AudioSource não encontrado.");
        if (collectSound == null) Debug.LogError("CollectSound não está atribuído.");
    }



    // Chamado quando o jogador coleta a moeda
    public void CollectCoin()
    {
        Debug.Log("Moeda coletada!");
        PlaySound();
        animator.SetTrigger("Moeda");

        // Destrói o objeto após o tempo de duração do som, ou 0.5 segundos se o som estiver ausente
        Destroy(gameObject, collectSound != null ? collectSound.length : 0.05f);
    }

    // Toca o som de coleta da moeda
    private void PlaySound()
    {
        if (collectSound != null)
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position, audioSource ? audioSource.volume : 1.0f);
            Debug.Log("Som reproduzido: " + collectSound.name);
        }
        else
        {
            Debug.LogError("CollectSound está nulo.");
        }
    }

    // Detecção de colisão com o jogador (caso use colisões 3D)
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (other.CompareTag(playerTag))
        {
            CollectCoin();  // Chama a função de coleta da moeda
        }
    }

    // Se você estiver usando colisão física (caso não use triggers)
    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.collider.CompareTag(playerTag))
    //     {
    //         CollectCoin();
    //     }
    // }
}