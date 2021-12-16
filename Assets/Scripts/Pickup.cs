using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Pickup : MonoBehaviourPun
{
    public PickupType type;
    public int value;

    public enum PickupType
    {
        Gold,
        Health
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (type == PickupType.Gold)
                player.photonView.RPC("GiveGold", player.photonPlayer, value);
            else if (type == PickupType.Health)
                player.photonView.RPC("Heal", player.photonPlayer, value);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
