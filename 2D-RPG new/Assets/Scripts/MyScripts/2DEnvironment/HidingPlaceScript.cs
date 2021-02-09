using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingPlaceScript : MonoBehaviour
{
    public CameraSystemMasterScript cameraSystemScript;

    private int boundaryCount;

    // Start is called before the first frame update

    void Start()
    {
        boundaryCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(SceneCombatManager.sceneCombatManager.enemyAlerted == false)
        {
            if (collision.CompareTag("PlayerBoundary") == true)
            {
                boundaryCount++;
                if (boundaryCount == 2)
                {
                    //change camera filter
                    SceneCombatManager.sceneCombatManager.playerHidden = true;
                    cameraSystemScript.hiddenModeCamera();
                }
            }
        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (SceneCombatManager.sceneCombatManager.enemyAlerted == false)
        {
            if (collision.CompareTag("PlayerBoundary") == true)
            {
                boundaryCount--;
                if (boundaryCount < 2)
                {
                    SceneCombatManager.sceneCombatManager.playerHidden = false;
                    cameraSystemScript.stealthModeCamera();
                    //change camera filter
                }
            }
        }     
    }
}
