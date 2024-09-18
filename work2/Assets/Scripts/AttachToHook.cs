using System;
using UnityEngine;

public class AttachToHook : MonoBehaviour
{
    private bool isHooked = false;
    private Transform hookTransform;

    public void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detected collision");
        if (collision.gameObject.CompareTag("Hook"))
        {
            Debug.Log("Detected collition with hook");
            isHooked = true;
            hookTransform = collision.transform;
        }
    }

    void Update()
    {
        if (isHooked && hookTransform != null)
        {
            transform.position = hookTransform.position;
        }
    }
}
