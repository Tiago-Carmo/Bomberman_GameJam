using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup2 : MonoBehaviour
{
   public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController2>().AddBomb();
                break;
            case ItemType.BlastRadius:
                player.GetComponent<BombController2>().explosionRadius++;
                break;
            case ItemType.SpeedIncrease:
                player.GetComponent<PlayerMovement2>().moveSpeed++;
                break;
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2"))
        {
            OnItemPickup(collision.gameObject);
        }
    }
}
