using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{
    public string regionName;
    public int regionIndex;
    public float[] prices;
    public int randomResource;
    public ProductType regionalResource;

    public void Awake()
    {
        SetRandomResource();
    }
    public void SetRandomResource()
    {
        randomResource = UnityEngine.Random.Range(0, Enum.GetValues(typeof(ProductType)).Length);
        regionalResource = (ProductType)randomResource;
    }
}
