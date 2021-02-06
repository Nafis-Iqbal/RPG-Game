using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

public class TabsUIManager : MonoBehaviour
{
    public CameraSystemMasterScript cameraSystemScript;

    [HideInInspector]
    public int currentActiveTab;
    public GameObject[] itemTabs = new GameObject[4];
    public Button goLeftButton, goRightButton;
    public string[] tabNames = new string[4];
    public Text activeTabText, leftTabText, rightTabText;
    public int totalTabs,mapTabIndex;
    public Image activeTabBackground;

    //Custom script modifications
    [SerializeField]
    private StandardUIQuestLogWindow PCQuestLogScript;
    [SerializeField]
    private StandardUIQuestTracker questTrackerHUD;

    private Color tempColor;
    public bool hasQuestLogTab;

    // Start is called before the first frame update
    void Start()
    {
        if (hasQuestLogTab == true)
        {
            //PCQuestLogScript.Open();
        }

        for (int i = 0; i < totalTabs; i++)
        {
            itemTabs[i].SetActive(false);
        }
        //set consummable panel to true;
        itemTabs[0].SetActive(true);
        goLeftButton.interactable = false;
        activeTabText.text = tabNames[0];
        currentActiveTab = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Nooooo");
            questTrackerHUD.ShowTracker();
        }
    }

    public void loadTabWithIndex(int index)
    {
        //loading required tab with button press
        if (currentActiveTab == mapTabIndex)
        {
            cameraSystemScript.exitMenuMapMode();
            //changing active tab alpha value
            changecColorAlphaTo(1.0f);
        }

        itemTabs[currentActiveTab].SetActive(false);
        currentActiveTab = index;
        itemTabs[currentActiveTab].SetActive(true);
        activeTabText.text = tabNames[currentActiveTab];

        if (currentActiveTab == mapTabIndex)
        {
            cameraSystemScript.enterMenuMapMode();
            //changing active tab alpha value
            changecColorAlphaTo(0.0f);
        }

        //setting up interface buttons & texts
        if (currentActiveTab == 0)
        {
            goLeftButton.interactable = false;
            leftTabText.text = "";
        }
        else
        {
            goLeftButton.interactable = true;
            leftTabText.text = tabNames[currentActiveTab - 1];
        }

        if (currentActiveTab == totalTabs-1)
        {
            goRightButton.interactable = false;
            rightTabText.text = "";
        }
        else
        {
            goRightButton.interactable = true;
            rightTabText.text = tabNames[currentActiveTab + 1];
        }
    }

    public void goLeftTab()
    {
        loadTabWithIndex(currentActiveTab - 1);      
    }

    public void goRightTab()
    {
        loadTabWithIndex(currentActiveTab + 1);
    }

    public void changecColorAlphaTo(float alphaValue)
    {
        tempColor = activeTabBackground.color;
        tempColor.a = alphaValue;
        activeTabBackground.color = tempColor;
    }
}
