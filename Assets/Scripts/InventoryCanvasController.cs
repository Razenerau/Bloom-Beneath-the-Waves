using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvasController : MonoBehaviour
{
    public static InventoryCanvasController Instance;

    private void Awake()
    {
        Instance = this;
    }
}
