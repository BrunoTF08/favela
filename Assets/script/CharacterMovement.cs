using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public int maxJumps = 2;  // Limite de pulos
    private int currentJumps = 0;  // Contador de pulos realizados

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Movimento lateral
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0f,0f, horizontalInput);  // Movimento apenas no eixo X
        transform.Translate(movement * speed * Time.deltaTime);

        // Verifica se está no chão
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Se o jogador estiver no chão, resetamos o contador de pulos
        if (isGrounded)
        {
            currentJumps = 0;  // Reseta o contador de pulos quando o personagem toca o chão
            animator.SetBool("isJumping", false);  // Desativa animação de pulo quando no chão
        }

        // Verifica se o jogador pressionou o botão de pulo e se ele ainda tem pulos disponíveis
        if (Input.GetButtonDown("Jump") && (isGrounded || currentJumps < maxJumps))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            currentJumps++;  // Incrementa o contador de pulos
            animator.SetBool("isJumping", true);  // Ativa animação de pulo
        }

        // Se o personagem estiver se movendo, ativa a animação de corrida
        if (movement != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
