using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Custom Menu
[CreateAssetMenu(fileName = "Item1",menuName = "AddItem/Item")] 
public class Item : ScriptableObject
{
    public string itemName;
    public GameObject itemPrefab;
    public Sprite itemImage;
}
