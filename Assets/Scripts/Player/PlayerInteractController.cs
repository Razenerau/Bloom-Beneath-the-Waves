using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteractController : MonoBehaviour
{
    Vector2 currentPosition;
    Vector2 oldPosition;

    public PlayerModel PlayerModel;
    public GameObject Player;
    public GameObject Pivot;
    public Tilemap Tilemap;

    public Vector3Int LastTilePos = new Vector3Int(int.MinValue, int.MinValue, int.MinValue);

    private void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        float distanceFromPlayer = Vector2.Distance(mouseWorldPos, Player.transform.position);

        if(distanceFromPlayer <= PlayerModel.ReachDistance)
        {
            transform.position = mouseWorldPos;
        }
        else
        {
            float deltaX = mouseWorldPos.x - Player.transform.position.x;
            float deltaY = mouseWorldPos.y - Player.transform.position.y;

            float angleRad = Mathf.Atan2(deltaY, deltaX);

            deltaX = PlayerModel.ReachDistance * Mathf.Cos(angleRad);
            deltaY = PlayerModel.ReachDistance * Mathf.Sin(angleRad);

            transform.localPosition = new Vector2(deltaX, deltaY);
        }
        
    }

    private void RotateAccordingToVelocity()
    {
        oldPosition = currentPosition;
        currentPosition = Player.transform.position;

        float deltaX = currentPosition.x - oldPosition.x;
        float deltaY = currentPosition.y - oldPosition.y;

        if (deltaX == 0 && deltaY == 0) return;

        float angleRad = Mathf.Atan2(deltaY, deltaX);
        Pivot.transform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Hex":
                if (PlayerModel.SelectedTile != null)
                {
                    //PlayerModel.OldSelectedHex = PlayerModel.SelectedHex;
                    //HexView oldHexView = PlayerModel.OldSelectedHex.GetComponent<HexView>();
                    //oldHexView.SetDeselected();

                    PlayerModel.OldTile = PlayerModel.SelectedTile;
                }
                //PlayerModel.SelectedHex = collision.gameObject;

                //Vector3 worldPoint = collision.ClosestPoint(transform.position);
                Vector3Int tilePos = Tilemap.WorldToCell(transform.position);
                TileBase newTile = Tilemap.GetTile(tilePos);

                //PlayerModel.SelectedTile = newTile;

                Debug.Log(collision.gameObject.name);

                //HexView selectedHexView = PlayerModel.SelectedHex.GetComponent<HexView>();
                //selectedHexView.SetSelected();
                break;
        }
    }

    private void LateUpdate()
    {
        Vector3 worldPos = TilemapRaycast.ProjectPointOntoTilemapPlane(Tilemap, transform.position);
        Vector3Int tilePos = Tilemap.WorldToCell(worldPos);

        // if tiles haven't changed
        if (tilePos == LastTilePos) return;

        // if left tile -> restore original color
        if (LastTilePos.x != int.MinValue)
        {
            Tilemap.SetColor(LastTilePos, Color.white);
        }

        if (Tilemap.HasTile(tilePos))
        {
            Tilemap.SetTileFlags(tilePos, TileFlags.None);
            Tilemap.SetColor(tilePos, Color.yellow);

            LastTilePos = tilePos;
        }
        else
        {
            LastTilePos = tilePos;
        }
    }
}
