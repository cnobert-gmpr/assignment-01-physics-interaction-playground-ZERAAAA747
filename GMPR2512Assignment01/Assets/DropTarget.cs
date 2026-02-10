using UnityEngine;
using System.Collections;

public class DropTarget : MonoBehaviour
{
    [Header("Drop Target Settings")]
    [SerializeField] private float resetDelay = 3f;

    private Collider2D col;
    private SpriteRenderer sr;
    private bool isActive = true;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive) return;

        if (collision.gameObject.CompareTag("Ball"))
        {
            Hit();
        }
    }

    private void Hit()
    {
        isActive = false;
        col.enabled = false;
        sr.enabled = false;

        StartCoroutine(ResetTarget());
    }

    private IEnumerator ResetTarget()
    {
        yield return new WaitForSeconds(resetDelay);
        isActive = true;
        col.enabled = true;
        sr.enabled = true;
    }
}
