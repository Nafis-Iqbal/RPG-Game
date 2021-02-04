using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCombatManager : MonoBehaviour
{
    //Camera Filter State Indicators
    public bool stealthMode, combatMode, eagleVisionMode,explorationMode;

    //Enemy Alert States
    public bool playerHidden, enemyAlerted;
    public int enemyCountInRoom;

    ObjectPooler objectPooler;

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
}
