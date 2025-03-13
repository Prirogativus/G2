using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddShip : MonoBehaviour
{
    public int smallShipAmount;
    public int smallShipPrice = 200;
    public int mediumShipAmount;
    public int mediumShipPrice = 500;
    public int largeShipAmount;
    public int largeShipPrice = 1000;
    public int costOfOneLinePArt = 1;
    private TextMeshProUGUI textMeshProUGUI;
    LineLengthCalculator lineLengthCalculator;
    public int CalculateTotalCost()
    {
        int lineCost = (int)lineLengthCalculator.length * costOfOneLinePArt;
        int totalCost = smallShipAmount*smallShipPrice + mediumShipAmount*mediumShipPrice + largeShipAmount*largeShipPrice + lineCost;
        return totalCost;
    }
    void Awake()
    {
        lineLengthCalculator = (GameObject.Find("Route")).GetComponent<LineLengthCalculator>();
        textMeshProUGUI = (GameObject.Find("TotalCost")).GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        textMeshProUGUI.text = "Total cost: " + CalculateTotalCost(); 
    }
}
