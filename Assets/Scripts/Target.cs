using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 10; // Points for hitting this target
    public ScoringSystem scoringSystem;

    void Start()
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            scoringSystem.AddScore(points);
            Destroy(gameObject,3); // Remove the target
        }
    }
}