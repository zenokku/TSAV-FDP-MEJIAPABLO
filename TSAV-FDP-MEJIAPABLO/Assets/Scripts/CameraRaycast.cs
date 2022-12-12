using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public float interactionRange = 10;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
}
