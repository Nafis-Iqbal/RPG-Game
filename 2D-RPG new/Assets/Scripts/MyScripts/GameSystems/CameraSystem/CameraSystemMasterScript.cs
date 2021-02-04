using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering;

public class CameraSystemMasterScript : MonoBehaviour
{
    #region CalculationVariables
    private bool coroutineExecuting;
    private float horizontalAxisValue, verticalAxisValue;
    #endregion

    //Auxillary Script Essentials
    public CinemachineBrain cameraBrainScript;
    public CinemachineVirtualCamera virtualCamScript;

    //Cinematics Animators
    public Animator blackBars, blackScreen, whiteScreen;
    public float levelSwitchDelay, cutsceneDelay, longDelay;

    #region Map System
    //rigidbody2d object for simulating menumap object following physics
    private Rigidbody2D rb2d;

    //menuMapObject for implementing map system
    public Transform playerObject, menuMapObject;
    private bool menuMapMode;
    private Vector2 mouseScrollVector2Value;
    private Vector3 tempVector3;

    //limit for zooming in & out of the map;here mouseScrollValue is either positive or negative
    public float zoomInLimit,zoomOutLimit,zoomInOutRate,mapScrollSpeed;
    private float tempFloat, mouseScrollValue, mapZoomMultiplier;
    public float leftPanBorder, rightPanBorder, upPanBorder, downPanBorder;

    //left right Scroll limits
    public Vector2 lowerLeftMapLimit, upperRightMapLimit;
    #endregion

    //Camera setups values;all values are used in "lens" section of vCAM
    public float normalModeZoom,stealthModeZoom,combatModeZoom,explorationModeZoom;

    //POST PROCESSING EFFECTS
    public Volume postProcessVolume;
    public VolumeProfile[] postProcessCameraFilterProfiles = new VolumeProfile[7];//0->Exploration 1->Stealth
    //2->Hidden 3->Combat 4->Happy 5->Sad 6->Mystery
    
    

    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume.profile = postProcessCameraFilterProfiles[1];
        virtualCamScript.Follow = playerObject.transform;
        virtualCamScript.m_Lens.OrthographicSize = normalModeZoom;
        coroutineExecuting = false;
        rb2d = menuMapObject.transform.GetComponent<Rigidbody2D>();
        menuMapObject.position = playerObject.position;
        mapZoomMultiplier = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (menuMapMode == true)
        {
            horizontalAxisValue = Input.GetAxis("Horizontal");
            verticalAxisValue = Input.GetAxis("Vertical");
           
            //moving menuMapObject around using keys
            menuMapObject.Translate(new Vector3(horizontalAxisValue, verticalAxisValue, 0.0f) * mapScrollSpeed * mapZoomMultiplier * Time.deltaTime);

            //moving menuMapObject around using mouse
            tempVector3 = menuMapObject.position;
            if (Input.mousePosition.y >= Screen.height - upPanBorder)
            {
                tempVector3.y += mapScrollSpeed * mapZoomMultiplier * Time.deltaTime * 2.0f;
            }
            if (Input.mousePosition.y <= downPanBorder)
            {
                tempVector3.y -= mapScrollSpeed * mapZoomMultiplier * Time.deltaTime * 2.0f;
            }
            if (Input.mousePosition.x >= Screen.width - rightPanBorder)
            {
                tempVector3.x += mapScrollSpeed * mapZoomMultiplier * Time.deltaTime * 2.0f;
            }
            if (Input.mousePosition.x <= leftPanBorder)
            {
                tempVector3.x -= mapScrollSpeed * mapZoomMultiplier * Time.deltaTime * 2.0f;
            }

            tempVector3.x = Mathf.Clamp(tempVector3.x, lowerLeftMapLimit.x, upperRightMapLimit.x);
            tempVector3.y = Mathf.Clamp(tempVector3.y, lowerLeftMapLimit.y, upperRightMapLimit.y);

            menuMapObject.transform.position = tempVector3;

            //taking mouse wheel input for map zooming
            mouseScrollVector2Value = Input.mouseScrollDelta;
            mouseScrollValue = mouseScrollVector2Value.y;

            if (mouseScrollValue != 0.0f)
            {
                tempFloat = virtualCamScript.m_Lens.OrthographicSize;
                mapZoomMultiplier = tempFloat / zoomInLimit;
                Debug.Log("what?" + tempFloat);
                if (mouseScrollValue > 0.0f)
                {                   
                    if(tempFloat - zoomInOutRate > zoomInLimit)
                    {
                        virtualCamScript.m_Lens.OrthographicSize -= zoomInOutRate;
                    }                  
                }
                else
                {              
                    if (tempFloat + zoomInOutRate < zoomOutLimit)
                    {
                        virtualCamScript.m_Lens.OrthographicSize += zoomInOutRate;
                    }
                }
            }
        }

    }

    #region MapMode
    public void enterMenuMapMode()
    {
        menuMapMode = true;

        //setting up lens zoom values
        virtualCamScript.m_Lens.OrthographicSize = zoomInLimit + 5.0f;

        virtualCamScript.Follow = menuMapObject;
    }

    public void exitMenuMapMode()
    {
        menuMapMode = false;
        mapZoomMultiplier = 1.0f;

        //reverting camera lens to normal
        virtualCamScript.m_Lens.OrthographicSize = normalModeZoom;

        virtualCamScript.Follow = playerObject;
        menuMapObject.position = playerObject.position;
    }
    #endregion

    public void cameraBlackScreen(bool fadeIn,int delayed = 0)
    {
        if (delayed == 0)
        {
            if (fadeIn == true)
            {
                blackScreen.SetBool("BlackIn", true);
            }
            else
            {
                blackScreen.SetBool("BlackIn", false);
            }
        }
        else
        {
            coroutineExecuting = true;
            if (delayed == 1)
            {
                StartCoroutine(cameraBlackScreenWithDelay(false, levelSwitchDelay));
            }
            else if (delayed == 2)
            {
                StartCoroutine(cameraBlackScreenWithDelay(false, cutsceneDelay));
            }
            else
            {
                StartCoroutine(cameraBlackScreenWithDelay(false, longDelay));
            }   
        }        
    }

    public void cameraWhiteScreen(bool fadeIn)
    {
        if (fadeIn == true)
        {
            whiteScreen.SetBool("WhiteIn", true);
        }
        else
        {
            whiteScreen.SetBool("WhiteIn", false);
        }
    }

    public void cameraBlackBars(bool barsIn)
    {
        if (barsIn == true)
        {
            blackBars.SetBool("BlackBarIn", true);
        }
        else
        {
            blackBars.SetBool("BlackBarIn", false);
        }
    }

    //camerablackscreen method with delay system
    IEnumerator cameraBlackScreenWithDelay(bool BlackIn, float delay)
    {
        if (coroutineExecuting == false)
        {
            yield break;
        }
        else
        {
            yield return new WaitForSeconds(delay);
            cameraBlackScreen(BlackIn);
            coroutineExecuting = false;
        }
    }

    public void stealthModeCamera()
    {
        postProcessVolume.profile = postProcessCameraFilterProfiles[1];
    }

    public void combatModeCamera()
    {
        postProcessVolume.profile = postProcessCameraFilterProfiles[3];
    }

    public void explorationModeCamera()
    {
        postProcessVolume.profile = postProcessCameraFilterProfiles[0];
    }

    public void hiddenModeCamera()
    {
        Debug.Log("This should work1!");
        postProcessVolume.profile = postProcessCameraFilterProfiles[2];
        Debug.Log("This should work!");
    }
}
