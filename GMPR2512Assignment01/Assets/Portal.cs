using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform exitPoint;
    [SerializeField] private float exitForceMultiplier = 1f;
    [SerializeField] private float cooldown = 0.3f;

    private bool isCoolingDown = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isCoolingDown) return;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        StartCoroutine(Teleport(rb));
    }

    private IEnumerator Teleport(Rigidbody2D rb)
    {
        isCoolingDown = true;

        Vector2 velocity = rb.linearVelocity;
        rb.position = exitPoint.position;
        rb.linearVelocity = velocity * exitForceMultiplier;

        yield return new WaitForSeconds(cooldown);
        isCoolingDown = false;
    }
}

