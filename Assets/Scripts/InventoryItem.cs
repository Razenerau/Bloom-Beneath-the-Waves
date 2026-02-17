using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image Icon;
    public int Amount;
    public TextMeshProUGUI AmountText;

    [HideInInspector] public Item Item;
    [HideInInspector] public Transform ParentAfterDrag;
    [HideInInspector] public Transform ParentDuringDrag;

    private void Awake()
    {
        AmountText.SetText($"{Amount}");
    }
    public void InitializeItem(Item newItem)
    {
        Item = newItem;
        Icon.sprite = newItem.Icon;
        name = newItem.name;
        AmountText.SetText($"{Amount}");
    }

    public void IncreaseAmount(int num)
    {
        Amount += num;
        AmountText.SetText($"{Amount}");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentAfterDrag = transform.parent;
        ParentDuringDrag = InventoryCanvasController.Instance.transform;
        transform.SetParent(ParentDuringDrag);
        transform.SetAsLastSibling();

        Icon.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ParentAfterDrag);
        gameObject.transform.localScale = Vector3.one;

        Icon.raycastTarget = true;
    }
}

