using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexView : MonoBehaviour
{
    public SpriteRenderer sp;

    public Color DefaultColor = Color.white;
    public Color SelectedColor = Color.yellow;

    public void SetSelected()
    {
        sp.color = SelectedColor;
    }

    public void SetDeselected()
    {
        sp.color = DefaultColor;
    }
}
