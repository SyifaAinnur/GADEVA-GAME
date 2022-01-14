using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] ItemBase item;
    [SerializeField] Dialog dialogAchievment;

    [HideInInspector] public AudioSource audioAchievment;


    public IEnumerator GiveItem(PlayerController player)
    {
        //add item to inventory
        // foreach (string item in dialogAchievment.linesAchievment)
        // {
        //     yield return DialogManager.Instance.ShowDialog(dialogAchievment);
        // }
        yield return DialogManager.Instance.ShowDialog(dialogAchievment, null, this.gameObject, audioAchievment);
        Debug.Log("give item" + item.ItemName);
        player.inventory.AddItem(item);
        
    }

    public bool CanBeGiven()
    {
        return item != null;
    }
}
