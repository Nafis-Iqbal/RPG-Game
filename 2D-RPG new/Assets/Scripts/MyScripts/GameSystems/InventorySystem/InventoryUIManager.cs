using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    [HideInInspector]
    public int currentActiveTab;
    public GameObject[] itemTabs = new GameObject[4];
    public Button goLeftButton, goRightButton;
    public string[] tabNames = new string[4];
    public Text activeTabText, leftTabText, rightTabText;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            itemTabs[i].SetActive(false);
        }
        //set consummable panel to true;
        itemTabs[0].SetActive(true);
        goLeftButton.interactable = false;
        activeTabText.text = tabNames[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadInventory()
    {

    }

    public void goLeftTab()
    {
        if (currentActiveTab > 0)
        {
            goRightButton.interactable = true;
            itemTabs[currentActiveTab].SetActive(false);
            currentActiveTab--;
            itemTabs[currentActiveTab].SetActive(true);
            activeTabText.text = tabNames[currentActiveTab];

            if (currentActiveTab == 0)
            {
                goLeftButton.interactable = false;
                leftTabText.text = "";
            }
            else
            {
                leftTabText.text = tabNames[currentActiveTab-1];
            }
            rightTabText.text = tabNames[currentActiveTab + 1];
        }
    }

    public void goRightTab()
    {
        if (currentActiveTab < 3)
        {
            goLeftButton.interactable = true;
            itemTabs[currentActiveTab].SetActive(false);
            currentActiveTab++;
            itemTabs[currentActiveTab].SetActive(true);
            activeTabText.text = tabNames[currentActiveTab];

            if (currentActiveTab == 3)
            {
                goRightButton.interactable = false;
                rightTabText.text = "";
            }
            else
            {
                rightTabText.text = tabNames[currentActiveTab + 1];
            }
            leftTabText.text = tabNames[currentActiveTab - 1];
        }
    }
}
