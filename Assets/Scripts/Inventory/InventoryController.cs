using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject InventoryCanvas;
    public List<MonoBehaviour> PausableScripts = new List<MonoBehaviour>();
    public static bool isActive;

    private void Awake()
    {
        InventoryCanvas.SetActive(false);
        ToggleScripts(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isActive = InventoryCanvas.gameObject.activeSelf;
            InventoryCanvas.SetActive(!isActive);

            ToggleScripts(isActive);
        }
    }

    private void ToggleScripts(bool isEnabled)
    {
        foreach (var script in PausableScripts)
        {
            script.enabled = isEnabled;
        }
    }
}
