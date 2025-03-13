using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastManager : MonoBehaviour
{
    public static RaycastManager Instance { get; private set; } // Singleton
    private RaycastHit hitInfo;
    public bool overUI = false;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // À Ã
        {
            overUI = IsPointerOverUI();
            Debug.Log(overUI);
            if (overUI) return;
            else 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hitInfo))
                {
                }
                else
                {
                    hitInfo = new RaycastHit();
                }
            }          
        }
    }
    public bool TryGetHit(out RaycastHit hit)
    {
        hit = hitInfo;
        return hit.collider != null;
    }
    private bool IsPointerOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var result in results)
        {
            if (result.gameObject.GetComponent<CanvasRenderer>() != null)
            {
                return true;
            }
        }

        return false;
    }
}

