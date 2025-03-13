using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlatformOpenPlatformCanvas : MonoBehaviour
{
    public Canvas PlatformCanvas;

    private void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("platform"))
                {
                    PlatformCanvas.gameObject.SetActive(true);
                }
            }
        }
    }
}
