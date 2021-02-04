using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLevelControlScript : MonoBehaviour
{
    public Vector2 lowerLeftCamLimit, upperRightCameraLimit;
    public Transform[] playerSpawnPoints = new Transform[5];
    public GameObject sceneEnemies;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivateLevelEnemies(bool setActive)
    {
        sceneEnemies.SetActive(setActive);
    }
}
