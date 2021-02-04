using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidingPlaceScript : MonoBehaviour
{
    private SceneCombatManager combatManagerScript;
    public CameraSystemMasterScript cameraSystemScript;

    private int boundaryCount;

    // Start is called before the first frame update

    void Start()
    {
        boundaryCount = 0;
        combatManagerScript = GameObject.Find("SceneCombatManager").GetComponent<SceneCombatManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(combatManagerScript.enemyAlerted == false)
        {
            if (collision.CompareTag("PlayerBoundary") == true)
            {
                boundaryCount++;
                if (boundaryCount == 2)
                {
                    //change camera filter
                    combatManagerScript.playerHidden = true;
                    cameraSystemScript.hiddenModeCamera();
                }
            }
        }      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (combatManagerScript.enemyAlerted == false)
        {
            if (collision.CompareTag("PlayerBoundary") == true)
            {
                boundaryCount--;
                if (boundaryCount < 2)
                {
                    combatManagerScript.playerHidden = false;
                    cameraSystemScript.stealthModeCamera();
                    //change camera filter
                }
            }
        }     
    }
}
