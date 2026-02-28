using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectIDModel : MonoBehaviour
{
    public List<ObjectID> entries = new List<ObjectID>();
}

[System.Serializable]
public class ObjectID : MonoBehaviour
{
    public int ID;
    public GameObject Prefab;
}
