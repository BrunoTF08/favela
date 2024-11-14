using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float vida = 100f; // Vida inicial do jogador

    public void TakeDamage(float amount)
    {
        vida -= amount; // Subtrai a quantidade de dano
        if (vida <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aqui você pode adicionar a lógica para quando o jogador morrer, como reiniciar o jogo ou mostrar uma tela de "Game Over"
        Debug.Log("O jogador morreu!");
    }
}