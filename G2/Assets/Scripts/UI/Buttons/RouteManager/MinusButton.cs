using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusButton : MonoBehaviour
{
    public int shipType;
    AddShip addShipScript;
    void Awake()
    {
        addShipScript = (GameObject.Find("AddShipPanel")).GetComponent<AddShip>();
    }
    public void OnButtonClick()
    {
        switch (shipType)
        {
            case 0:
                addShipScript.smallShipAmount--;
                break;
            case 1:
                addShipScript.mediumShipAmount--;
                break;
            case 2:
                addShipScript.largeShipAmount--;
                break;
        }
    }
}
