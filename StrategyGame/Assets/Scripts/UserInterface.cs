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
    public Province secondProvince;

    public GameObject actionsPanel;
    public GameObject topPanel;
    public GameObject approvePanel;
    public GameObject buildPanel;
    public GameObject infoPanel;
    public GameObject secondInfoPanel;

    public GameObject numberInput;

    public Button approve;

    public Text money;
    public Text countryName;
    
    #region Selected Province Resources
    public Text provinceName;
    public Text army;
    public Text population;
    public Text economy;
    #endregion
    #region Second Province Resources
    public Text secondProvinceName;
    public Text secondArmy;
    public Text secondPopulation;
    public Text secondEconomy;
    #endregion


    void Awake(){
        ShowObject(actionsPanel);
        ShowObject(approvePanel);
        ShowObject(buildPanel);
        ShowObject(infoPanel);
        ShowObject(secondInfoPanel);
        ShowObject(numberInput);
    }

    // Start is called before the first frame update
    void Start()
    {
        HideObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(infoPanel);
        HideObject(secondInfoPanel);
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
            
            if(secondProvince != null){
                secondProvinceName.text = secondProvince.provinceName;
                secondArmy.text = secondProvince.army.ToString();
                secondPopulation.text = secondProvince.population.ToString();
                secondEconomy.text = secondProvince.economy.ToString();
            }
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

        if(currentMethod != "move") approve.interactable = true;
    }

    #endregion

    public void SelectProvince(Province province){
        ShowObject(actionsPanel);
        ShowObject(infoPanel);
        HideObject(buildPanel);
        
        switch(currentMethod){
            case "move":
                secondProvince = province;
                approve.interactable = true;
            break;

            default:
                HideObject(numberInput);
                HideObject(approvePanel);
                
                currentProvince = province;
                secondProvince = null;
            break;
        }
    }

    public void SelectBackground(){
        HideObject(actionsPanel);
        HideObject(infoPanel);
        HideObject(secondInfoPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(numberInput);

        currentMethod = null;
        currentProvince = null;
        secondProvince = null;
        approve.interactable = false;
    }

    public void Approve(){
        ShowObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(numberInput);
        HideObject(secondInfoPanel);

        int numberInputted = int.Parse(numberInput.GetComponent<InputField>().text);
        switch (currentMethod){
            case "move":
            currentProvince.army -= numberInputted;
            secondProvince.army += numberInputted;
            break;

            case "recruit":
            country.money -= numberInputted;
            currentProvince.army += numberInputted;
            break;

            case "disband":
            country.money += numberInputted;
            currentProvince.army -= numberInputted;
            break;

            case "build":

            break;
            
            default: break;
        }

        currentMethod = null;
        secondProvince = null;
        approve.interactable = false;
    }

    public void Cancel(){
        ShowObject(actionsPanel);
        HideObject(approvePanel);
        HideObject(buildPanel);
        HideObject(numberInput);
        HideObject(secondInfoPanel);

        currentMethod = null;
        secondProvince = null;
        approve.interactable = false;
    }

    public void Move(){
        HideObject(actionsPanel);
        ShowObject(approvePanel);
        ShowObject(numberInput);
        ShowObject(secondInfoPanel);

        approve.interactable = false;
        currentMethod = "move";
        minNumber = 0;
        maxNumber = currentProvince.army;

        
        numberInput.GetComponent<InputField>().text = minNumber.ToString();
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

        approve.interactable = false;
    }

    public void Fortress(){
        
        
        approve.interactable = true;
    }
    
    public void Tower(){
        
        
        approve.interactable = true;
    }
    
    public void Port(){
        
        
        approve.interactable = true;
    }
}
