using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WikiInfoScript : MonoBehaviour
{
    //Dictionary to hold object names & descriptions for ease of name entry
    private IDictionary<string, string> objectDescriptionsDict = new Dictionary<string, string>();
    private IDictionary<string, Sprite> objectImagesDict = new Dictionary<string, Sprite>();

    //Custom struct to enter names,description & images   
    public WikiInfoItemClass[] objectDescriptionArray = new WikiInfoItemClass[5];

    //objects holding visual Infos
    public Text descriptionText;
    public Image objectImage;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {                   
            //Debug.Log(objectDescriptionArray[i].objectName + " t" + i + " " + objectDescriptionArray[i].objectDescription);
            objectDescriptionsDict.Add(objectDescriptionArray[i].objectName, objectDescriptionArray[i].objectDescription);
            objectImagesDict.Add(objectDescriptionArray[i].objectName, objectDescriptionArray[i].objectImage);        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateDescriptionPanelWith(string objectName)
    {
        descriptionText.text = objectDescriptionsDict[objectName];
        objectImage.sprite = objectImagesDict[objectName];
    }
}
