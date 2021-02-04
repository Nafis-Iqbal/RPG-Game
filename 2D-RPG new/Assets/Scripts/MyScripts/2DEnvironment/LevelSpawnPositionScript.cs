using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnPositionScript : MonoBehaviour
{
    public GameObject nextSceneLevelObject;
    public int nextSpawnPositionIndexInLevel;
    public CameraSystemMasterScript cameraScript;
    private bool coroutineExecuting;
    private Vector3 pTF;
    

    // Start is called before the first frame update
    void Start()
    {
        coroutineExecuting = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameControllerScript.gameController.isTransitionPossible == true && collision.CompareTag("Player") == true)
        {
            transitionToNextLevel(collision);
        }
    }
    public void transitionToNextLevel(Collider2D collision)
    {
        cameraScript.cameraBlackScreen(true);
        coroutineExecuting = true;
        cameraScript.cameraBlackScreen(false, 1);
        GameControllerScript.gameController.currentLevelEnemiesObject.SetActive(false);
        GameControllerScript.gameController.currentLevelEnemiesObject =
        nextSceneLevelObject.GetComponent<SceneLevelControlScript>().sceneEnemies;
        nextSceneLevelObject.GetComponent<SceneLevelControlScript>().deactivateLevelEnemies(true);
        pTF = nextSceneLevelObject.GetComponent<SceneLevelControlScript>().playerSpawnPoints[nextSpawnPositionIndexInLevel - 1].position;
        pTF.z -= 2.0f;
        collision.transform.position = pTF;
    }

    
}
