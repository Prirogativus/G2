using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortInteraction : MonoBehaviour
{
    [SerializeField] private GameObject firstCanvasPrefab; // first canvas prefab
    private GameObject spawnedCanvas; // храним внутри ссылку на заспавненый канвасик


    void Update()
    {
        if (Input.GetMouseButtonDown(0))  //LKM
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                if (hit.collider.CompareTag("Platform")) 
                {
                    if (spawnedCanvas == null) // канвас еще не заспавнен
                    {
                        spawnedCanvas = Instantiate(firstCanvasPrefab, transform);
                    }
                }
            }
        }

    }
}