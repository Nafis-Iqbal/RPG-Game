using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class InventoryItemTileClass
{
    [Tooltip("0->consummable 1->crafting item 2->sell item 3->questitem")]
    public int itemType;
    [Tooltip("number of items of that item type")]
    public int itemCount;
    [Tooltip("number of maximum items of that item type")]
    public int maxItemCount;
    [Tooltip("0->food 1->drink 2->potion")]
    public int consummableType;
    public bool isEmpty;
    public bool isUnlocked;
    [Tooltip("0 for inactive sprite,1 for active sprite")]
    public Sprite[] tileSprites = new Sprite[2];

    public Text itemCountText;
    public Image activeTileSprite;
}
