using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow1 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public Transform eje;

    public bool inground;
    private RaycastHit hit;
    public float distance;
    public Vector3 v3;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + v3, Vector3.up * -1 * distance);
    }

    void Move()
    {
        Vector3 rotateTargetZ = eje.transform.forward;
        rotateTargetZ.y = 0;

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateTargetZ), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
        }
        else
        {
            if (inground)
            {
                rb.velocity = Vector3.zero;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateTargetZ * -1), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
        }

        Vector3 rotateTargetX = eje.transform.right;
        rotateTargetX.y = 0;

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateTargetX), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateTargetX * -1), 0.3f);
            var dir = transform.forward * speed * Time.fixedDeltaTime;
            dir.y = rb.velocity.y;
            rb.velocity = dir;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position + v3, transform.up * -1, out hit, distance))
        {
            if (hit.collider.tag == "piso")
            {
                inground = true;
            }
        }
        else
        {
            inground = false;
        }
    }
}
