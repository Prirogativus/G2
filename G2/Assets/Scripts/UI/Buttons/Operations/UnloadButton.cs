using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadButton : MonoBehaviour
{
    public PortBehaviour port;

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
        port.currentOperation = OperationType.Unload;
    }
}
