using UnityEngine;

public class TimeItem : MonoBehaviour
{
        public CollectibleItemData ItemData;
    // Start is called once before 
    // the first execution of Update after the MonoBehaviour is created
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
            string itemName = ItemData != null ? ItemData.itemName : "Unknown Item";
            Debug.Log("Player collected: " + itemName);
            if (player != null)
            {
               
            }
            Destroy(gameObject);
        }
    }
}
