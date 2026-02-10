using UnityEngine;
using System.Collections;

public class BallRespawn : MonoBehaviour
{
    [Header("Respawn Settings")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float respawnDelay = 1.5f;

    private Rigidbody2D rb;
    private bool isRespawning = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathZone") && !isRespawning)
        {
            StartCoroutine(RespawnRoutine());
        }
    }

    private IEnumerator RespawnRoutine()
    {
        isRespawning = true;

        rb.simulated = false;
        transform.position = new Vector3(999, 999, 0);

        yield return new WaitForSeconds(respawnDelay);

        transform.position = spawnPoint.position;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.simulated = true;

        isRespawning = false;
    }
}
