using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class Cube : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;
    public GameObject prefabToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(1f, 1f, 1f);
        transform.Rotate(vec.normalized * rotateSpeed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
                //player.scale();
                if (GameManager.instance != null)
                {
                    GameManager.instance.SpawnRandomPrefab();
                    GameManager.instance.AddScore(1); 
                }
            }
            Destroy(gameObject);
        }
    }
}
