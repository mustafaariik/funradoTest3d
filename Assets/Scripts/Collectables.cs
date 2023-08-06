using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        PlayerLevel playerLevel = other.GetComponent<PlayerLevel>();

        if(playerLevel != null && gameObject.tag == "LevelUp")
        {
            gameObject.SetActive(false);
            Debug.Log(other.gameObject.tag);
            playerLevel.LevelUpCollected();
            
        }
        if(gameObject.tag == "key")
        {
            player.GetComponent<PlayerController>().SetHasKey(true);
            gameObject.SetActive(false);
        }
        
    }
    
}