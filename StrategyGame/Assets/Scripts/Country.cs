using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Country : MonoBehaviour
{
    public string countryName;
    public int money;
    public int profit;
    public int expenses;
    public int balance;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = countryName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
