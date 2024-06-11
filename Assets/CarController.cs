using UnityEngine;

public class CarController : MonoBehaviour
{
    public float constantSpeed = 10f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    private bool hasWon = false;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        if (hasWon) return;

        // Obtener la entrada del jugador
        float turnInput = Input.GetAxis("Horizontal"); // A/D o Arrow Left/Right
        float moveInput = Input.GetAxis("Vertical"); // W/S o Arrow Up/Down

        // Verificar si se está presionando la tecla W
        isMoving = moveInput > 0;

        // Rotar el coche
        if (turnInput != 0)
        {
            float turnAmount = turnInput * turnSpeed * Time.deltaTime;
            Quaternion turnOffset = Quaternion.Euler(0, turnAmount, 0);
            rb.MoveRotation(rb.rotation * turnOffset);
        }
    }

    void FixedUpdate()
    {
        if (hasWon) return;

        // Aplicar movimiento constante solo si se presiona la tecla W
        if (isMoving)
        {
            Vector3 forwardMovement = transform.forward * constantSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("meta"))
        {
            hasWon = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("¡Has ganado!");
        }
    }
}
