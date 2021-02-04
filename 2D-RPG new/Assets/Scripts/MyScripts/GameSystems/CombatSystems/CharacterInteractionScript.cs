using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionScript : MonoBehaviour
{
    public string[] actionsList = new string[5];//1-> hide 2-> sleep 3-> fight
    public bool interactable;
    [HideInInspector]
    public int currentAction;
    [HideInInspector]
    public Transform targetPosition;
    public Movement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable == true)
        {
            Debug.Log("GG");
            if (Input.GetKeyDown(KeyCode.E) == true)
            {
                Debug.Log("Why153");
                playerMovementScript.isCharacterControllable = false;
                playerMovementScript.CutsceneModeSettings(true,false, targetPosition);
            }
        }
        
    }


}
