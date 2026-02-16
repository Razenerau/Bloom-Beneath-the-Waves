using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public float Speed;
    public float ReachDistance;
    public GameObject SelectedHex;
    public GameObject OldSelectedHex;

    //=========== CONSTANTS ======================
    public const float OneOverSqrt2 = 0.707106781f;
}
