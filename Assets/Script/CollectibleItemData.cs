using UnityEngine;
public enum CollectibleItemType
{
    FastItem,
    TimeItem
}

[CreateAssetMenu(fileName = "New Collectible Item", menuName = "Game/Collectible Item")]

public class CollectibleItemData : ScriptableObject
{
    public CollectibleItemType itemType;
    public string itemName;
    public int itemValue;
    public Sprite itemIcon;
}
