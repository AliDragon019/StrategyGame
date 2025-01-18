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
    public GameObject topPanel;
    public GameObject approvePanel;
    public GameObject buildPanel;
    public GameObject infoPanel;

    public GameObject numberInput;

    public Text money;
    public Text countryName;
    public Text provinceName;
    public Text army;
    public Text population;
    public Text economy;

    void Awake(){
        ShowObject(actionsPanel);
        ShowObject(approvePanel);
        ShowObject(buildPanel);
        ShowObject(infoPanel);
        ShowObject(numberInput);
    }

    // Start is called before the first frame update
    void Start()
    {
        HideObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(infoPanel);
        HideObject(numberInput);
        
        countryName.text = country.countryName;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "Money: " + country.money;

        if(currentProvince != null){
            provinceName.text = currentProvince.provinceName;
            army.text = "Army: " + currentProvince.army.ToString();
            population.text = "Population: " + currentProvince.population.ToString();
            economy.text = "Economy: " + currentProvince.economy.ToString();
        }
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
        ShowObject(infoPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(numberInput);

        currentProvince = province;
    }

    public void SelectBackground(){
        HideObject(actionsPanel);
        HideObject(infoPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(numberInput);

        currentProvince = null;
    }

    public void Approve(){
        ShowObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(numberInput);

        switch (currentMethod){
            case "recruit":
            int number = int.Parse(numberInput.GetComponent<InputField>().text);
            country.money -= number;
            currentProvince.army += number;
            break;

            case "disband":
            int num = int.Parse(numberInput.GetComponent<InputField>().text);
            country.money += num;
            currentProvince.army -= num;
            break;

            case "build":

            break;
            
            default: break;
        }

        currentMethod = null;
    }

    public void Cancel(){
        ShowObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(numberInput);

        currentMethod = null;
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
        HideObject(actionsPanel);
        ShowObject(approvePanel);
        ShowObject(buildPanel);
    }
}
