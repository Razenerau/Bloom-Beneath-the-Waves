using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlotController> inventorySlots = new List<InventorySlotController>();
    public GameObject IntventoryItemPrefab;

    public void AddItem(Item newItem)
    {
        foreach (InventorySlotController slot in inventorySlots)
        {
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(newItem, slot);
                return;
            }
            else if (itemInSlot.gameObject.name == newItem.name && newItem.IsStackable && itemInSlot.Amount < newItem.MaxStack)
            {
                itemInSlot.IncreaseAmount(1);
                return;
            }
        }
    }

    public void SpawnNewItem(Item newItem, InventorySlotController inventorySlot)
    {
        GameObject newItemGameObject = Instantiate(IntventoryItemPrefab, inventorySlot.transform);
        InventoryItem inventoryItem = newItemGameObject.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(newItem);
    }
}
