using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] int playerLevelNumber = 1;

    public void LevelUpCollected()
    {
        playerLevelNumber += 5;
    }

    public int GetPlayerLevel()
    {
        return playerLevelNumber;
    }
}