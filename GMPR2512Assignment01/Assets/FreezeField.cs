using UnityEngine;
using System.Collections;

public class FreezeField : MonoBehaviour
{
    [SerializeField] private float freezeDuration = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        StartCoroutine(Freeze(rb));
    }

    private IEnumerator Freeze(Rigidbody2D rb)
    {
        Vector2 savedVelocity = rb.linearVelocity;
        float savedGravity = rb.gravityScale;

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(freezeDuration);

        rb.constraints = RigidbodyConstraints2D.None;
        rb.gravityScale = savedGravity;
        rb.linearVelocity = savedVelocity;
    }
}

