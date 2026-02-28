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

    [Header("Tilemap")]
    public Tilemap CurrentTilemap;
    public Vector3Int SelectedTilePos;
    public Vector3Int LastTilePos = new Vector3Int(int.MinValue, int.MinValue, int.MinValue);
    public float PlacementLift = 0.05f;
    

    //=========== CONSTANTS ======================
    public const float OneOverSqrt2 = 0.707106781f;
}
