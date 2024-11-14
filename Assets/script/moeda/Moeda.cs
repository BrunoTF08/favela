using UnityEngine;
 
public class Moeda : MonoBehaviour
{
    // Velocidade de rotação em graus por segundo
    public float rotationSpeed = 100f;
 
    void Update()
    {
        // Faz a moeda girar ao redor de seu eixo Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.Self);
    }
}