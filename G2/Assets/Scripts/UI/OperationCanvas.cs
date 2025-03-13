using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationCanvas : MonoBehaviour
{
    public RoutesEditorButton RoutesEditorButton;
    public PortBehaviour PortBehaviour;
    public bool IsActive = false;
    private void Awake()
    {
        PortBehaviour = GetComponentInParent<PortBehaviour>();
        RoutesEditorButton = FindObjectOfType<RoutesEditorButton>();
    }
    public void SetActive()
    {
        IsActive = true;
        this.gameObject.SetActive(IsActive);
    }
}
