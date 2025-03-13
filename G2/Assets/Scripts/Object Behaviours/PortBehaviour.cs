using System.Collections.Generic;
using UnityEngine;

public enum ProductType { Gold, Iron, Weapons, Fur, Dyes, Opium, Porcelain, Silk, Spices }
public enum OperationType { Sell, Unload, Load, NoValue }
public class PortBehaviour : MonoBehaviour
{
    //Свойства Порта
    public string portName;
    public int portID;
    public Region localRegion;
    // Снабжение
    public int MaxAmountOfSupplies = 10;//Значение дял изменения
    public int currentAmountOfSupplies = 1; // Потом поменять на код для корабля
    public int singleSupplyCost = 3;
    public int portSuppliesLevel = 1;
    public int portProductionLevel = 0;
    private int totalSupplyIncrease = 0;
    // Производство
    public ProductType productionResource;
    public float productionCooldown = 60f;
    // Operations
    public Dictionary<ProductType, OperationType> _tradeRules = new();
    public List<ProductType> warehouse;
    public OperationType currentOperation;
    public OperationCanvas operationCanvas;


    void Start()
    {
        DetectRegion();
        productionResource = localRegion.regionalResource;
        SetResources();
    }

    void Update()
    {
        PortProduction();
    }
    public void GetTotalSupplyIncrease()
    {
        int difference = MaxAmountOfSupplies - currentAmountOfSupplies;
        if (difference < portSuppliesLevel)
        {
            totalSupplyIncrease = difference;
            currentAmountOfSupplies = MaxAmountOfSupplies;
        }
        else
        {
            totalSupplyIncrease = portSuppliesLevel;
            currentAmountOfSupplies += totalSupplyIncrease;
        }
    }
    void PortProduction()
    {
        productionCooldown -= Time.deltaTime;
        if (portProductionLevel >= 1 && productionCooldown <= 0)
        {
            for (int i = 0; i < portProductionLevel; i++)
            {
                warehouse.Add(productionResource);
            }
            productionCooldown = 60;
        }
    }
    void DetectRegion()
    {
        Collider portCollider = GetComponent<Collider>();
        Region[] regions = FindObjectsOfType<Region>();

        foreach (Region region in regions)
        {
            Collider regionCollider = region.GetComponent<Collider>();

            if (regionCollider != null && portCollider.bounds.Intersects(regionCollider.bounds))
            {
                localRegion = region;
            }
        }
    }
    public void SetTradeRule(OperationType operationType, ProductType product)
    {
        _tradeRules[product] = operationType;
    }
    private void SetResources()
    {
        /* int resourceCount = Enum.GetValues(typeof(ProductType)).Length;
         for (int i = 0; i < resourceCount; i++)
         {
             _warehouse.Add((ProductType)i, 0);
         }*/
    }
}
