using System;
using UnityEngine;

public class AttachToHook : MonoBehaviour
{
    private bool isHooked = false;
    private Transform hookTransform;
    private HookSwing hookSwing;
    private float originalMaxHookRetractY;

    public void Start()
    {
        hookSwing = FindObjectOfType<HookSwing>();
        originalMaxHookRetractY = hookSwing.maxHookRetractY;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {
            isHooked = true;
            hookTransform = collision.transform;

            originalMaxHookRetractY = hookSwing.maxHookRetractY;
            hookSwing.maxHookRetractY = collision.transform.position.y;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hook"))
        {
            isHooked = false;
            hookSwing.maxHookRetractY = originalMaxHookRetractY; // Reset the value to original
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
