using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectPlacementController : MonoBehaviour
{
    public PlayerModel PlayerModel;
    public GameObject PlaceableObject;
    public GameObject SceneObjects;
    public static ObjectPlacementController Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlaceObject();
        }
    }

    private void PlaceObject1()
    {
        HexModel hexModel = PlayerModel.SelectedHex.GetComponent<HexModel>();
        if (!hexModel.IsOccupied)
        {
            hexModel.IsOccupied = true;
            Vector2 pos = PlayerModel.SelectedHex.transform.position;
            int sortingOrder = PlayerModel.SelectedHex.GetComponent<HexView>().GetSortingLayer() + 1;

            GameObject NewObject = Instantiate(PlaceableObject, pos, Quaternion.identity, SceneObjects.transform);
            NewObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = sortingOrder;
        }
    }

    private void PlaceObject()
    {
        Vector3 tileCenterPos = PlayerModel.CurrentTilemap.GetCellCenterWorld(PlayerModel.SelectedTilePos);
        Vector3 spawnPos = tileCenterPos + PlayerModel.CurrentTilemap.transform.forward * PlayerModel.PlacementLift;

        GameObject newObject = Instantiate(PlaceableObject, spawnPos, Quaternion.identity, SceneObjects.transform);

        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (!PlacementSaveData.Instance.OccupiedTilesByScene.ContainsKey(sceneName))
            PlacementSaveData.Instance.OccupiedTilesByScene[sceneName] = new();

        
        PlacementSaveData.Instance.OccupiedTilesByScene[sceneName].Add(PlayerModel.SelectedTilePos, PlaceableObject);
    }

    public void RebuildObject(Dictionary<Vector3Int, GameObject> objects)
    {
        foreach (KeyValuePair<Vector3Int, GameObject> entry in objects)
        {
            Vector3Int pos = entry.Key;
            GameObject obj = entry.Value;

            Vector3 tileCenterPos = PlayerModel.CurrentTilemap.GetCellCenterWorld(pos);
            Vector3 spawnPos = tileCenterPos + PlayerModel.CurrentTilemap.transform.forward * PlayerModel.PlacementLift;

            Instantiate(obj, spawnPos, Quaternion.identity, SceneObjects.transform);
        } 
    }
}
