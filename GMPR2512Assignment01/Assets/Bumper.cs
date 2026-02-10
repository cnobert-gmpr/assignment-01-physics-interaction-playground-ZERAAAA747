using UnityEngine;

public class Bumper : MonoBehaviour
{
    [Header("Bumper Settings")]
    [SerializeField] private float impulseForce = 8f;
    [SerializeField] private Color hitColor = Color.yellow;
    [SerializeField] private float flashDuration = 0.1f;

    private SpriteRenderer sr;
    private Color originalColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D ballRb = collision.rigidbody;
        if (ballRb == null) return;

        Vector2 direction = (ballRb.position - (Vector2)transform.position).normalized;
        ballRb.AddForce(direction * impulseForce, ForceMode2D.Impulse);

        StopAllCoroutines();
        StartCoroutine(Flash());
    }

    private System.Collections.IEnumerator Flash()
    {
        sr.color = hitColor;
        yield return new WaitForSeconds(flashDuration);
        sr.color = originalColor;
    }
}
