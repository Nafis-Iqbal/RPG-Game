using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class QuestVariablesControlScript : MonoBehaviour
{
    [System.Serializable]
    public class ConvoObjects{
        public DialogueSystemTrigger convoObject;
        public float lastUsedTime;
        public float breakDuration;
        public bool isTriggered;
    }

    public ConvoObjects[] convoObjects = new ConvoObjects[15];
    [HideInInspector]
    public int isConvoObjectTriggered;

    public float conditionsCheckIntervalInSeconds;
    private float lastTimeChecked;

    private int convoObjectsLength;

    // Start is called before the first frame update
    void Start()
    {
        convoObjectsLength = convoObjects.Length;
        for(int i = 0; i < convoObjectsLength; i++)
        {
            convoObjects[i].isTriggered = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastTimeChecked > conditionsCheckIntervalInSeconds)//condition to decrease cpu load
        {
            lastTimeChecked = Time.time;
            if (isConvoObjectTriggered > 0)
            {
                for (int i = 0; i < convoObjectsLength; i++)
                {
                    if (convoObjects[i].isTriggered == false) continue;
                    else if (Time.time - convoObjects[i].lastUsedTime > convoObjects[i].breakDuration)
                    {
                        convoObjects[i].convoObject.enabled = true;
                        convoObjects[i].isTriggered = false;
                        isConvoObjectTriggered--;
                    }
                }
            }
        }       
    }

    public void updateConvoObjectTime(int index)
    {
        isConvoObjectTriggered++ ;
        convoObjects[index].isTriggered = true;
        convoObjects[index].convoObject.enabled = false;
        convoObjects[index].lastUsedTime = Time.time;
    }
}
