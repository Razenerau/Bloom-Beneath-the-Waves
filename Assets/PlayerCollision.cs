using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public InventoryManager InventoryManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;

        switch (tag)
        {
            case "Pickup":
                PickUpModel pickUpModel = collision.GetComponent<PickUpModel>();
                Item item = pickUpModel.item;
                InventoryManager.AddItem(item);
                Destroy(collision.gameObject);
                break;
        }
    }
}
