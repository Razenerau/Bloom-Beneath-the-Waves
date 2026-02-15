using UnityEngine;

public class PlayerPlacementController : MonoBehaviour
{
    public PlayerModel PlayerModel;
    public GameObject PlaceableObject;
    public GameObject SceneObjects;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 pos = PlayerModel.SelectedHex.transform.position;
            int sortingOrder = PlayerModel.SelectedHex.GetComponent<HexView>().GetSortingLayer() + 1;

            GameObject NewObject = Instantiate(PlaceableObject, pos, Quaternion.identity, SceneObjects.transform);
            NewObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = sortingOrder;
        }
    }
}
