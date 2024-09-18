using System;
using UnityEngine;

public class AttachToHook : MonoBehaviour
{
    private bool isHooked = false;
    private Transform hookTransform;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Detected collition");
        if (collision.gameObject.CompareTag("Hook"))
        {
            Debug.Log("Detected collition with hook");
            isHooked = true;
            hookTransform = collision.transform; // Store the hook's transform
        }
    }

    void Update()
    {
        if (isHooked && hookTransform != null)
        {
            // Set the position of this object to be the same as the hook's position
            transform.position = hookTransform.position;
        }
    }
}
