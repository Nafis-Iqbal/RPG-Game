using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomWorldObjectScript : MonoBehaviour
{
    [Tooltip("if the object itself is interactable or not")]
    public bool interactable;
    public Animator buttonUIPopUp;
    [Tooltip("the name of action this object makes the player do")]
    public string interactionAction;
    public Transform interactionPosition;

    public CharacterInteractionScript interactionScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactable == false) return;
        if (collision.CompareTag("Player"))
        {
            buttonUIPopUp.SetBool("ButtonActive", true);
            interactionScript.interactable = true;
            interactionScript.currentAction = interactionAction;
            interactionScript.targetPosition = interactionPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactable == false) return;
        if (collision.CompareTag("Player"))
        {
            buttonUIPopUp.SetBool("ButtonActive", false);
            interactionScript.interactable = false;
        }
    }
}
