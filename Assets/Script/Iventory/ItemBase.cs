using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemBase : ScriptableObject
{
    [SerializeField] int indexNumber;
    [SerializeField] string itemName;
    [SerializeField] Sprite icon;


    public int IndexNumber => indexNumber;
    public string ItemName => itemName;
    public Sprite Icon => icon;

}
