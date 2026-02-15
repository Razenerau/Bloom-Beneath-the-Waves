using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    Vector2 currentPosition;
    Vector2 oldPosition;

    public PlayerModel PlayerModel;
    public GameObject Player;
    public GameObject Pivot;

    private void FixedUpdate()
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
                if (PlayerModel.SelectedHex != null)
                {
                    PlayerModel.OldSelectedHex = PlayerModel.SelectedHex;
                    HexView oldHexView = PlayerModel.OldSelectedHex.GetComponent<HexView>();
                    oldHexView.SetDeselected();
                }
                PlayerModel.SelectedHex = collision.gameObject;
                Debug.Log(collision.gameObject.name);

                HexView selectedHexView = PlayerModel.SelectedHex.GetComponent<HexView>();
                selectedHexView.SetSelected();
                break;
        }
    }
}
