using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCombatManager : MonoBehaviour
{
    public static SceneCombatManager sceneCombatManager;
    //Camera Filter State Indicators
    public bool stealthMode, combatMode, eagleVisionMode,explorationMode;

    //Enemy Alert States
    public bool playerHidden, enemyAlerted;
    public bool playerInDisguise;
    public int enemyCountInRoom;

    ObjectPooler objectPooler;

    private void Awake()
    {
        //Creating Singleton
        if (SceneCombatManager.sceneCombatManager == null)
        {
            SceneCombatManager.sceneCombatManager = this;
        }
        else
        {
            if (SceneCombatManager.sceneCombatManager != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnEnemyAtLocation()
    {
        //GameObject currentObject = objectPooler.SpawnFromPool(enemyType, enemySpawnPoints[spawnPoint].transform.position, Quaternion.identity) as GameObject;
    }

    public void isPlayerHidden()
    {
        playerHidden = true;
    }

    public void isPlayerNotHidden()
    {
        playerHidden = false;
    }

    public void isPlayerInDisguise()
    {
        playerInDisguise = true;
    }

    public void isPlayerNotInDisguise()
    {
        playerInDisguise = false;
    }

    public void isEnemiesAlerted()
    {
        enemyAlerted = true;
    }

    public void isEnemiesNotAlerted()
    {
        enemyAlerted = false;
    }

    public void isEnemyKilled()
    {
        enemyCountInRoom--;
    }

    public void newEnemyEnteredInRoom()
    {
        enemyCountInRoom++;
    }

    public void updateNewRoomEnemyCountInRoom(int newEnemyCount)
    {
        enemyCountInRoom = newEnemyCount;
    }

}
