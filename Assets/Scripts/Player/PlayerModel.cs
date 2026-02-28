using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerModel : MonoBehaviour
{
    public float Speed;
    public float ReachDistance;
    public GameObject SelectedHex;
    public GameObject OldSelectedHex;

    public Tile SelectedTile;
    public Tile OldTile;

    //=========== CONSTANTS ======================
    public const float OneOverSqrt2 = 0.707106781f;
}
