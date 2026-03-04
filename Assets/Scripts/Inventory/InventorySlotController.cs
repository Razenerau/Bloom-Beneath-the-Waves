using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotController : MonoBehaviour, IDropHandler
{
    public GameObject SlotHighlighter;

    public void Select()
    {
        SlotHighlighter.transform.position = gameObject.transform.position;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem draggedItem = dropped.GetComponent<InventoryItem>();
            draggedItem.ParentAfterDrag = this.transform;
        }
    }   
}
