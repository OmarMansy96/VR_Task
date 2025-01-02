using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 10; 
    public ScoringSystem scoringSystem;

    void Start()
    {
        scoringSystem = FindObjectOfType<ScoringSystem>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            scoringSystem.AddScore(points);
            Destroy(gameObject, 3);
        }

        
    }
}
