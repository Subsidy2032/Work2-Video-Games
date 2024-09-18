using System;
using UnityEngine;

public class AttachToHook : MonoBehaviour
{
    private bool isHooked = false;
    private Transform hookTransform;
    private HookSwing hookSwing;

    public void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {
            isHooked = true;
            hookTransform = collision.transform;

            hookSwing = FindObjectOfType<HookSwing>();
            hookSwing.maxHookRetractY = collision.transform.position.y;
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
