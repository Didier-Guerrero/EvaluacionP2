using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá
    public float smoothSpeed = 0.125f; // La velocidad de suavizado de la cámara
    public Vector3 offset; // La distancia de la cámara al objeto

    void LateUpdate()
    {
        // Define la posición deseada de la cámara
        Vector3 desiredPosition = target.position + offset;
        // Interpola suavemente hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Asigna la posición suavizada a la cámara
        transform.position = smoothedPosition;

        // Asegura que la cámara mire desde arriba y esté rotada 90 grados a la derecha
        transform.rotation = Quaternion.Euler(90f, 90f, 0f);
    }
}
