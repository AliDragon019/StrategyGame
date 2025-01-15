using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Province : MonoBehaviour
{
    public string provinceName;
    public int population;
    public int economy;
    public int army;

    // Start is called before the first frame update
    void Start()
    {
        UserInterface userInterface = GameObject.FindObjectOfType<UserInterface>();
        gameObject.name = provinceName;
        
        gameObject.GetComponent<Button>().onClick.AddListener(() => {userInterface.SelectProvince(this);});
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
