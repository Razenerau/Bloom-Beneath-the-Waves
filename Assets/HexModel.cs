using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexModel : MonoBehaviour
{
    [Header("Variables")]
    public bool IsOccupied = false;

    [Header("Color")]
    public Color DefaultColor = Color.white;
    public Color SelectedColor = Color.yellow;
}
