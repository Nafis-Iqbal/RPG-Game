using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class playerPickUpClass
{
    [Tooltip("Type of pickup item by index")]
    public int pickUpType;
    //0->consumables 1->craftingItems 2->itemsForSale 3->questItem;
    public Sprite inventoryImage, droppedImage;
    public string itemDescription;
    //Image of the pickUp

    #region consumables
    [Tooltip("Type of consummable.Health,Stamina or Potions")]
    public int consumableType;
    //0->Health 1->Stamina 2->Potions
    public int healthBonus, staminaBonus;
    //added points value for the consumable
    [Tooltip("Name of Potions to match and apply effects from the player script")]
    public string potionType;
    //String to indicate potion type for proper effect implementation on the player end
    #endregion

    #region crafting
    //crafting type details[not yet planned]
    #endregion

    #region salesItem
    [Tooltip("Type of sellable item,as certain item types get more value while selling to particular merchants types")]
    public int saleItemsType;
    //0->ArmourerMerchant 1->ConsummableMerchant 2->mysteriousArtifactsMerchant
    [Tooltip("The normal price without any special price multiplier")]
    public int basePrice;
    [Tooltip("multipliers for prices of goods when selling to appropiate merchants")]
    public int[] priceMultiplier = new int[3];
    #endregion

    #region questItem
    public int bonusXP;
    public int bonusSkillPoints;
    #endregion

}
