using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 2f;
    private Quaternion initialRotation;

    void Start()
    {
        if (target != null)
        {
            initialRotation = transform.rotation; // Guardar la rotación inicial de la cámara
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcular la nueva posición de la cámara manteniendo el offset
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y + offset.y, target.position.z + offset.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);

            // Mantener la rotación inicial de la cámara
            transform.rotation = initialRotation;
        }
    }
}
