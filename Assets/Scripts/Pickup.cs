using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    Character player;

    private Inventory inventory;
    public GameObject itemButton;

    public CollectibleType currentCollectible;
    public enum CollectibleType
    {
        AmmoCrate,
        JumpPotion,
        LowGravPotion
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // item can be added to inventory if isFull = true
                    inventory.isFull[i] = true;

                    switch (currentCollectible)
                    {
                        case CollectibleType.AmmoCrate:
                            Debug.Log("Picked up Ammo!");
                            //player.canShoot = true;
                            break;

                        case CollectibleType.JumpPotion:
                            Debug.Log("Picked up Jump Potion!");
                            //player.canJump = true;
                            break;

                        case CollectibleType.LowGravPotion:
                            Debug.Log("Picked up Low Gravity Potion!");
                            //player.lowGrav();
                            break;
                    }

                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}