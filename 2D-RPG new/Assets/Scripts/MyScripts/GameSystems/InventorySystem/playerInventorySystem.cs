using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class playerInventorySystem: MonoBehaviour
{
    //0-14 are consummable types
    public InventoryItemTileClass[] consummableItemTypes = new InventoryItemTileClass[15];

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            consummableItemTypes[i].itemType = 0;
            int tempvalue = consummableItemTypes[i].itemCount = 0;
            if(i<5)consummableItemTypes[i].consummableType = 0;
            else if (i > 4 && i < 10) consummableItemTypes[i].consummableType = 1;
            else consummableItemTypes[i].consummableType = 2;

            consummableItemTypes[i].isEmpty = true;
            consummableItemTypes[i].isUnlocked = true;

            consummableItemTypes[i].maxItemCount = 20;

            consummableItemTypes[i].itemCountText.text = tempvalue.ToString();
            consummableItemTypes[i].activeTileSprite.sprite = consummableItemTypes[i].tileSprites[0];
        }
    }

    private void Update()
    {
        
    }

    public bool processPickUp(int pickUpObjectID)
    {
        if (pickUpObjectID < 15)
        {
            if (consummableItemTypes[pickUpObjectID].isUnlocked == true)
            {
                if (consummableItemTypes[pickUpObjectID].itemCount == 0)
                {
                    consummableItemTypes[pickUpObjectID].itemCount += 1;
                    consummableItemTypes[pickUpObjectID].activeTileSprite.sprite = 
                        consummableItemTypes[pickUpObjectID].tileSprites[1];
                    consummableItemTypes[pickUpObjectID].itemCountText.text = "1";
                    return true;
                }
                if(consummableItemTypes[pickUpObjectID].itemCount < consummableItemTypes[pickUpObjectID].maxItemCount)
                {
                    int newValue = ++consummableItemTypes[pickUpObjectID].itemCount;
                    consummableItemTypes[pickUpObjectID].itemCountText.text = newValue.ToString();
                    return true;
                }
            }
        }
        return false;
    }

    public bool useInventoryItem(int itemID)
    {
        if (consummableItemTypes[itemID].itemCount > 0)
        {
            int newValue = --consummableItemTypes[itemID].itemCount;
            consummableItemTypes[itemID].itemCountText.text = newValue.ToString();

            if (newValue == 0)
            {
                consummableItemTypes[itemID].activeTileSprite.sprite =
                        consummableItemTypes[itemID].tileSprites[0];
            }
            return true;
        }
        return false;
    }
}
