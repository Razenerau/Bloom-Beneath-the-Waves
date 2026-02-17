using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public ItemType Type;
    public ActionType Action;
    public Vector2 Range = new Vector2(5, 5);
    public GameObject PlaceablePrefab;

    [Header("Only UI")]
    public bool IsStackable = true;
    public int MaxStack;
    public Sprite Icon;

    public enum ItemType
    {
        Structure,
        Material,
        Food,
        Tool,
        Decorator,
    }

    public enum ActionType
    {
        Attach,
        Mine
    }
}
