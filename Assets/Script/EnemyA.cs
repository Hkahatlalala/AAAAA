using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public EnemyData EnemyData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            string enemyName = EnemyData != null ? EnemyData.enemyName : "Unknown Enemy";
            Debug.Log("Player encountered: " + enemyName);
            if (player != null)
            {
                if (GameManager.instance != null)
                {
                    
                }
            }
            Destroy(gameObject);
        }
    }
}
