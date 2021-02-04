using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpScript : MonoBehaviour
{
    public int pickUpObjectID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("WTF??");
            bool pickUpPossible = collision.transform.GetComponent<playerInventorySystem>().processPickUp(pickUpObjectID);
            if (pickUpPossible == true)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
