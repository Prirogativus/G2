using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowShipAmount : MonoBehaviour
{
    public int shipType;
    public int amount;
    AddShip addShip;
    TextMeshProUGUI textPanel;
    private void Awake()
    {
        addShip = (GameObject.Find("AddShipPanel")).GetComponent<AddShip>();
        textPanel = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        switch (shipType)
        {
            case 0:
                amount = addShip.smallShipAmount;
                break;
            case 1:
                amount = addShip.mediumShipAmount;
                break;
            case 2:
                amount = addShip.largeShipAmount;
                break;
        }
        textPanel = textPanel.GetComponent<TextMeshProUGUI>();
        textPanel.text = amount.ToString();
    }
}
