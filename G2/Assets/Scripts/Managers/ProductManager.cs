using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    [System.Serializable]
    public class Product
    {
        public string productName;
        public int productPrice;
    }

    public Product[] products = new Product[7];

    private void Awake()
    {
        products[0] = new Product { productName = "Product1", productPrice = 10 };
        products[1] = new Product { productName = "Product2", productPrice = 15 };
        products[2] = new Product { productName = "Product3", productPrice = 20 };
        products[3] = new Product { productName = "Product4", productPrice = 25 };
        products[4] = new Product { productName = "Product5", productPrice = 30 };
        products[5] = new Product { productName = "Product6", productPrice = 35 };
        products[6] = new Product { productName = "Product7", productPrice = 40 };
    }
}
