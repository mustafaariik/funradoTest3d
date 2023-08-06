using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();

        if(playerLevel != null && gameObject.tag == "LevelUp" && gameObject.activeSelf)
        { 
            gameObject.SetActive(false);    
            playerLevel.LevelUpCollected();
        }
        if(gameObject.tag == "key")
        {
            player.GetComponent<PlayerController>().SetHasKey(true);
            gameObject.SetActive(false);
            //door.SetActive(false);
        }
    }
}