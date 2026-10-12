using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public TextMeshProUGUI levelText, hitpointText, goldText, upgradeCostText, xpText;

    // Logic
    public Image weaponSprite;
    public RectTransform xpBar;

    // Weapon Upgrade
    public void OnUpgradeClick()
    {
        Debug.Log("Attempted upgrade");
    }

    // Update the character info
    public void UpdateMenu()
    {
        // Weapon

        // Meta
        hitpointText.text = GameManager.instance.player.hitpoint.ToString();
        goldText.text = GameManager.instance.gold.ToString();

        // xp bar
        xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}
