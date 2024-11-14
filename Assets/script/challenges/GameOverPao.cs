using UnityEngine;
using UnityEngine.SceneManagement;  // Para usar o SceneManager

public class GameOverPao : MonoBehaviour
{
    // Nome da cena que será carregada (menu principal)
    public string mainMenuSceneName = "MainMenu";  // Certifique-se de que a cena "MainMenu" exista no seu projeto!

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou em contato tem a tag "Player"
        if (other.CompareTag("Player"))
        {
            // Exibe uma mensagem de log
            Debug.Log("Jogador colidiu com o pão. Indo para o menu principal...");

            // Carrega a cena principal
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
