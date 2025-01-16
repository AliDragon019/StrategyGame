using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{
    int maxNumber;
    int minNumber;

    string currentMethod;

    public Country country;
    public Province currentProvince;

    public GameObject actionsPanel;
    public GameObject infoPanel;
    public GameObject approvePanel;

    public GameObject numberInput;

    public Text money;
    public Text countryName;

    void Awake(){
        ShowObject(actionsPanel);
        ShowObject(approvePanel);
        ShowObject(numberInput);
    }

    // Start is called before the first frame update
    void Start()
    {
        HideObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(numberInput);
        
        countryName.text = country.countryName;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Money: " + country.money;
    }

    public void ShowObject(GameObject obj){
        obj.SetActive(true);
    }
    
    public void HideObject(GameObject obj){
        obj.SetActive(false);
    }

    #region NumberInput
    
    // Make the CheckNumber detect wether you want to check the money or the army
    public void CheckNumber(){
        InputField input = numberInput.GetComponent<InputField>();
        int number = int.Parse(input.text);

        if(number > maxNumber){
            input.text = maxNumber.ToString();
        } else if(number < minNumber){
            input.text = minNumber.ToString();
        }
    }

    #endregion

    public void SelectProvince(Province province){
        ShowObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(numberInput);

        currentProvince = province;
        Debug.Log(currentProvince.provinceName);
    }

    public void SelectBackground(){
        HideObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(numberInput);

        currentProvince = null;
    }

    public void Approve(){
        ShowObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(numberInput);

        int number = int.Parse(numberInput.GetComponent<InputField>().text);
        switch (currentMethod){
            case "recruit":
            country.money -= number;
            currentProvince.army += number;
            break;

            case "disband":
            country.money += number;
            currentProvince.army -= number;
            break;
            
            default: break;
        }
    }

    public void Cancel(){
        ShowObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(numberInput);
    }

    public void Move(){

    }

    public void Recruit(){
        HideObject(actionsPanel);
        ShowObject(approvePanel);
        ShowObject(numberInput);
        
        currentMethod = "recruit";
        minNumber = 0;
        maxNumber = country.money;
        

        numberInput.GetComponent<InputField>().text = minNumber.ToString();
        numberInput.GetComponent<InputField>().Select();
    }

    public void Disband(){
        HideObject(actionsPanel);
        ShowObject(approvePanel);
        ShowObject(numberInput);
        
        currentMethod = "disband";
        minNumber = 0;
        maxNumber = currentProvince.army;
        
        numberInput.GetComponent<InputField>().text = minNumber.ToString();
        numberInput.GetComponent<InputField>().Select();
    }
    
    public void Build(){

    }
}
