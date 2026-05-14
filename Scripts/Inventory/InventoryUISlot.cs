using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUISlot : MonoBehaviour
{
    public Image icon;
    //public TMP_Text amountText;

    public void Set(InventorySlot slot)
    {
        icon.sprite = slot.item.icon;
        //amountText.text = slot.amount.ToString();
    }
}