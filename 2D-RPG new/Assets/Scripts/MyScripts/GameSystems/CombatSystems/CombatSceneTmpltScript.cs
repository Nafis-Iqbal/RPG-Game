using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSceneTmpltScript : MonoBehaviour
{
    public bool fixedEnemies, areaDefend, escortMisson;
    public bool isTimeOver;

    private SceneCombatManager combatManager;
    public Transform[] enemySpawnPoints = new Transform[10];

    public string[] enemyNames = new string[10];
    public int[] enemyLimits = new int[10];
    private int[] enemyBuffers = new int[10];
    public int[] spawnPattern = new int[10];//holds the index of enemies to be spawned in order
    public int[] patrollingEnemies = new int[10];//index indicates the enemy and the value indicates the number of said enemies

    public int totalEnemyCap;
    
    

    public float minimumSpawnDelay;
    private float lastSpawnedTime, timeSinceLastSpawn;

    private int spawnPointsSize,spawnPatternSize;
    private int lastUsedSpawnIndex;
    private int enemyToSpawn;
    private int lastSpawnedEnemyIndex;//it holds the index of the enemy to be spawned from the spawn pattern array as buffer

    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        lastUsedSpawnIndex = 0;
        lastSpawnedEnemyIndex = 0;
        lastSpawnedTime = 0.0f;
        isTimeOver = false;
        objectPooler = ObjectPooler.Instance;
        spawnPointsSize = enemySpawnPoints.Length;
        spawnPatternSize = spawnPattern.Length;

        combatManager = GameObject.Find("SceneCombatManager").GetComponent<SceneCombatManager>();

        for(int i = 0; i < enemyLimits.Length; i++)
        {
            enemyBuffers[i] = enemyLimits[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn = Time.deltaTime - lastSpawnedTime;
        if (timeSinceLastSpawn < minimumSpawnDelay) return;

        if (combatManager.enemyCountInRoom >= totalEnemyCap) return;

        if (escortMisson == true)
        {

            return;
        }
        else if (areaDefend == true)
        {
            if (isTimeOver == true) return;
        }
        //the rest of the code works the same both for fixed enemies and when defending
        lastUsedSpawnIndex++;
        lastUsedSpawnIndex = lastUsedSpawnIndex % spawnPointsSize;

        lastSpawnedEnemyIndex++;
        lastSpawnedEnemyIndex = lastSpawnedEnemyIndex % spawnPatternSize;

        enemyToSpawn = spawnPattern[lastSpawnedEnemyIndex];
        if (enemyBuffers[enemyToSpawn] > 0)
        {
            enemyBuffers[enemyToSpawn]--;
            spawnEnemyAtLocation(enemyNames[enemyToSpawn], lastUsedSpawnIndex);
        }
    }

    public void spawnEnemyAtLocation(string enemyTypeName,int spawnID)//spawns enemy with name in spawnID serial TF position
    {
        objectPooler.SpawnFromPool(enemyTypeName, enemySpawnPoints[spawnID].transform.position, Quaternion.identity);
    }

    public void combatFromPatrolling()
    {
        int temp=patrollingEnemies.Length;
        for(int i = 0; i < temp; i++)
        {
            enemyBuffers[i] -= patrollingEnemies[i];
        }
    }
}
