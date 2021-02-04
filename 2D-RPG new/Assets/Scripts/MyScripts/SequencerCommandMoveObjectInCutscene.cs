using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using PixelCrushers.DialogueSystem.SequencerCommands;

public class SequencerCommandMoveObjectInCutscene : SequencerCommand
{
    //MoveObjectInCutscene(aiTargetObject,targetTransform,faceFixedMode)
    private Movement playerMovementScript;

    public Transform aiTargetObject;
    public Transform targetTransform;
    public bool faceFixedMode;
    private float angle=0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("noooo1");
        aiTargetObject = GetSubject(0);
        targetTransform = GetSubject(1);
        faceFixedMode = GetParameterAsBool(2);

        playerMovementScript = aiTargetObject.GetComponent<Movement>();

        //playerMovementScript.isCutsceneModeOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //playerMovementScript.CutsceneMode(true, targetTransform);
        /*
        Debug.Log("noooo2");
        playerMovementScript.path.endReachedDistance = 1;
        if (aiTargetObject.GetComponent<AIPath>().reachedDestination)
        {
            playerMovementScript.animator.SetFloat("Speed", 0f);

            if (!faceFixedMode)
            {

                float speed = (2 * Mathf.PI) / 15;  //2*PI in degress is 360, so you get 5 seconds to complete a circle
                float radius = 50;

                angle += speed * Time.deltaTime; //if you want to switch direction, use -= instead of +=
                float x = Mathf.Cos(angle) * radius;
                float y = Mathf.Sin(angle) * radius;

                playerMovementScript.targetForDirection = new Vector2(x, y);

            }
            else
            {
                playerMovementScript.targetForDirection = playerMovementScript.player.position;
            }

        }
        else
        {
            playerMovementScript.MoveEnemy();
            playerMovementScript.aIDestinationSetter.target = targetTransform;
            playerMovementScript.targetForDirection = targetTransform.position;
        }
        */


    }
}
