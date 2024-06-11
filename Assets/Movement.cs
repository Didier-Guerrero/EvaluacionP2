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
            initialRotation = transform.rotation; // Guardar la rotaci�n inicial de la c�mara
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcular la nueva posici�n de la c�mara manteniendo el offset
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y + offset.y, target.position.z + offset.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);

            // Mantener la rotaci�n inicial de la c�mara
            transform.rotation = initialRotation;
        }
    }
}
