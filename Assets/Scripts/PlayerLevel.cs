using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    public UnityEvent<PlayerLevel>OnLevelUpCollected;

    [SerializeField] int playerLevelNumber = 1;

    public void LevelUpCollected()
    {
        playerLevelNumber += 5;
        OnLevelUpCollected.Invoke(this);
    }

    public int GetPlayerLevel()
    {
        return playerLevelNumber;
    }
}
