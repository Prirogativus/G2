using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ResourceButton : MonoBehaviour
{
    public int productID;
    public PortBehaviour port;
    public bool isValueSet = false;
    public OperationType tradeRule = OperationType.NoValue;
    public bool isChoosed = false;
    Transform current;
    private void Awake()
    {
        Transform current = transform;
        for (int i = 0; i < 3; i++) 
        {
            if (current.parent != null)
            {
                current = current.parent;
            }
        }
        port = current.GetComponent<PortBehaviour>();
    }
    public void OnButtonClick()
    {
        if (tradeRule == port.currentOperation || tradeRule == OperationType.NoValue)
        {
            isChoosed = !isChoosed;
            

            if (isChoosed && !isValueSet)
            {
                tradeRule = port.currentOperation;
                port.SetTradeRule(port.currentOperation, (ProductType)productID);
                isValueSet = true;
                switch (tradeRule)
                {
                    case OperationType.Sell:
                        this.GetComponent<Outline>().effectColor = Color.yellow;
                        break;
                    case OperationType.Unload:
                        this.GetComponent<Outline>().effectColor = Color.blue;
                        break;
                    case OperationType.Load:
                        this.GetComponent<Outline>().effectColor = Color.green;
                        break;
                }
            }
            else if (isChoosed == false && isValueSet)
            {
                this.GetComponent<Outline>().effectColor = Color.white;
                port._tradeRules.Remove((ProductType)productID);
            }
        }
    }
}
