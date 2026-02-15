using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexView : MonoBehaviour
{
    public SpriteRenderer sp;
    public HexModel HexModel;

  

    public void SetSelected()
    {
        sp.color = HexModel.SelectedColor;
    }

    public void SetDeselected()
    {
        sp.color = HexModel.DefaultColor;
    }

    public int GetSortingLayer()
    {
        return sp.sortingOrder;
    }

    private void Start()
    {
        sp.sortingOrder = 0 - (int)gameObject.transform.position.y * 3;
    }
}
