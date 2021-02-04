using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class GameControllerScript : MonoBehaviour
{
    public bool isTransitionPossible;
    public static GameControllerScript gameController;
    public GameObject gameCanvas;

    //SceneLevelsObjects
    public GameObject currentLevelEnemiesObject;

    //UI Stuff
    private bool journalMapsOpen;
    private CanvasGroup journalMapsTabUI;
    [SerializeField]
    private TabsUIManager journalMapUIScript;

    private void Awake()
    {
        //Creating Singleton
        if (GameControllerScript.gameController == null)
        {
            GameControllerScript.gameController = this;
        }
        else
        {
            if (GameControllerScript.gameController != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);

        gameCanvas.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        //SceneLevel Variables
        isTransitionPossible = true;

        //UI stuff
        journalMapsTabUI = GameObject.Find("JournalMapsInventoryUI").GetComponent<CanvasGroup>();
        journalMapsOpen = false;
        journalMapsTabUI.alpha = 0f;
        journalMapsTabUI.blocksRaycasts = false;
    }

    // Update is called once per frame
    void Update()
    {
        //UI Stuff
        //Inventory tab -> 2 ; Quest Log tab -> 3 ; Map tab -> 4
        if (Input.GetKeyDown(KeyCode.I))//opening inventory tab
        {
            openTabByIndex(2);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            openTabByIndex(3);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            openTabByIndex(4);
        }
        /*
        if (Input.GetKeyDown(KeyCode.V))
        {
            GameObject.Find("Archer1").GetComponent<Movement>().CutsceneMode(true, targetPosition);
        }
        */
    }

    void openTabByIndex(int index)
    {
        if (journalMapsOpen == false)
        {
            journalMapsOpen = true;
            journalMapsTabUI.alpha = 1f;
            journalMapsTabUI.blocksRaycasts = true;
            journalMapUIScript.loadTabWithIndex(index);
        }
        else
        {
            if (journalMapUIScript.currentActiveTab == index)
            {
                if (journalMapUIScript.mapTabIndex == index)
                {
                    journalMapUIScript.cameraSystemScript.exitMenuMapMode();
                }
                journalMapsOpen = false;
                journalMapsTabUI.alpha = 0f;
                journalMapsTabUI.blocksRaycasts = false;
            }
            else
            {
                journalMapUIScript.loadTabWithIndex(index);
            }
        }
    }

    public void turnGameObjectOn(GameObject targetGameObject)
    {
        targetGameObject.SetActive(true);
    }

    public void turnGameObjectOff(GameObject targetGameObject)
    {
        targetGameObject.SetActive(false);
    }
}
