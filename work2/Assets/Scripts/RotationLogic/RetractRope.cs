using UnityEngine;

public class RetractRope : MonoBehaviour
{
    private HookSwing hookSwing;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hookSwing = GetComponent<HookSwing>();
        hookSwing.maxHookRetractY = collision.transform.position.y;
    }
}
