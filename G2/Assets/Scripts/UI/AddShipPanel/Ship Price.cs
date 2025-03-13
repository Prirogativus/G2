using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShipPrice : MonoBehaviour
{
    AddShip addShipScript;
    TextMeshProUGUI textPanel;
    GameObject textPanelObject;

    public void Awake()
    {
        addShipScript = GetComponent<AddShip>();
        TextPanelSetup("Type 0 price", 0);
        TextPanelSetup("Type 1 price", 1);
        TextPanelSetup("Type 2 price", 2);
    }

    private void TextPanelSetup(string textPanelName, int shipType)
    {
        int shipPrice = 0;
        textPanelObject = GameObject.Find(textPanelName);
        textPanel = textPanelObject.GetComponent<TextMeshProUGUI>();
        switch (shipType)
        {
            case 0:
                shipPrice = addShipScript.smallShipPrice;
                textPanel.text = "Small ship price: " + shipPrice;
                break;
            case 1:
                shipPrice = addShipScript.mediumShipPrice;
                textPanel.text = "Average ship price: " + shipPrice;
                break;
            case 2:
                shipPrice = addShipScript.largeShipPrice;
                textPanel.text = "Large ship price: " + shipPrice;
                break;
        }
        
        
    }
}
