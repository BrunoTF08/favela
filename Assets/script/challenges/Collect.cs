using UnityEngine;
using UnityEngine.SceneManagement;  // Usado para carregar cenas
using UnityEngine.UI;  // Para usar UI, se necessário (como mostrar uma tela de "Game Over")

public class Collect : MonoBehaviour
{
    public string gameOverSceneName = "GameOver";  // Nome da cena que será carregada quando o objeto for coletado
    public AudioClip collectSound;  // Som a ser tocado ao coletar o objeto (opcional)
    private AudioSource audioSource;  // Componente AudioSource para tocar o som

    private void Start()
    {
        // Obtém o componente AudioSource do objeto (caso tenha)
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu com o coletável é o jogador
        if (other.CompareTag("Player"))
        {
            // Toca o som de coleta, se atribuído
            if (collectSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collectSound);
            }

            // Exibe uma mensagem no console para indicar que o objeto foi coletado
            Debug.Log("Objeto coletado! O jogo será terminado.");

            // Chama o método que termina o jogo
            EndGame();
        }
    }

    private void EndGame()
    {
        // Aqui você pode optar por terminar o jogo de diferentes formas:

        // 1. Carregar uma cena de "Game Over" ou "Fim de Jogo"
        if (!string.IsNullOrEmpty(gameOverSceneName))
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
        else
        {
            // 2. Fechar o jogo (usado apenas na versão compilada, não funciona no editor)
            Application.Quit();

            // Se estiver no editor, podemos simular a saída:
            Debug.Log("O jogo foi fechado!");
        }
    }
}
