using UnityEngine;

public class Nave : MonoBehaviour
{
    public float thrustForce = 5f;         // força normal
    public float turboMultiplier = 2f;     // multiplicador do turbo
    public float rotationSpeed = 100f;     // velocidade de rotação
    public float drag = 0.98f;             // resistência da água

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Entrada de rotação (Horizontal: -1 a 1)
        float rotationInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed * Time.deltaTime);

        // Entrada de propulsão (Vertical: -1 a 1)
        float thrustInput = Input.GetAxis("Vertical");

        // Verifica se o turbo está ativo (ex: Left Shift)
        bool turboActive = Input.GetKey(KeyCode.LeftShift);

        // Calcula força final
        float currentThrust = thrustForce * (turboActive ? turboMultiplier : 1f);

        if (thrustInput > 0)
        {
            velocity += transform.up * currentThrust * thrustInput * Time.deltaTime;
        }

        // Aplicar arrasto (simula resistência da água)
        velocity *= drag;

        // Atualizar posição
        transform.position += velocity * Time.deltaTime;
    }
}
