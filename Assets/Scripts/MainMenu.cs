using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private InputField hippoSpeed;
    [SerializeField]
    private InputField enemySpeed;
    [SerializeField]
    private InputField winScore;
    [SerializeField]
    private InputField rechargeTime;
    [SerializeField]
    private InputField enemyRecharge;
    [SerializeField]
    private InputField enemyCost;
    [SerializeField]
    private Dropdown chouseEnemy;
    [SerializeField]
    private Text textBox;
    
    public static int score;
    public static float hipSpeed;
    public static float recTime;
    private enemy enemy;
    public static float enemRecharge;
    // Start is called before the first frame update
    void Start()
    {
        
        try
        {
            chouseEnemy.captionText.text = "Trent";
            chouseEnemy.options[0].text = "Trent";
            chouseEnemy.options[1].text = "Mole";
            chouseEnemy.options[2].text = "Trent Heavy";
            hippoSpeed.text = "5";
            winScore.text = "10";
            rechargeTime.text = "2";
            enemyRecharge.text = "4";
            DropdownItemSelected(chouseEnemy);
            chouseEnemy.onValueChanged.AddListener(delegate { DropdownItemSelected(chouseEnemy); });
        }
        catch (NullReferenceException)
        {
        }

        try
        {
            enemy = enemy.GetComponent<enemy>();
        }
        catch (NullReferenceException)
        {
        }
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        try
        {
            int index = dropdown.value;
            textBox.text = dropdown.options[index].text;
        }
        catch (NullReferenceException)
        {
        }
       
    }
    
    // Update is called once per frame
    void Update()
    {
        try
        {
            score= Int32.Parse(winScore.text);
            hipSpeed = Int32.Parse(hippoSpeed.text);
            recTime = Int32.Parse(rechargeTime.text);
            enemRecharge = Int32.Parse(enemyRecharge.text);
            switch (chouseEnemy.value)
        {
            case 0:
                if (enemySpeed.text != "")
                {
                    enemy.chars[0].GetComponent<Char>().speedEnemy =Int32.Parse(enemySpeed.text); 

                }
                else
                {
                    enemy.chars[0].GetComponent<Char>().speedEnemy = 4;
                }
                if (enemyCost.text != "")
                {
                    enemy.chars[0].GetComponent<Char>().costEnemy =Int32.Parse(enemyCost.text); 
                }
                else
                {
                    enemy.chars[0].GetComponent<Char>().speedEnemy = 2;
                }
                break;
            case 1:
                if (enemySpeed.text != "")
                {
                    enemy.chars[1].GetComponent<Char>().speedEnemy =Int32.Parse(enemySpeed.text); 

                }
                else
                {
                    enemy.chars[1].GetComponent<Char>().speedEnemy = 7;
                }
                if (enemyCost.text != "")
                {
                    enemy.chars[1].GetComponent<Char>().costEnemy =Int32.Parse(enemyCost.text); 
                }
                else
                {
                    enemy.chars[1].GetComponent<Char>().speedEnemy = 3;
                }
                break;
            case 2:
                if (enemySpeed.text != "")
                {
                    enemy.chars[2].GetComponent<Char>().speedEnemy =Int32.Parse(enemySpeed.text); 

                }
                else
                {
                    enemy.chars[2].GetComponent<Char>().speedEnemy = 3;
                }
                if (enemyCost.text != "")
                {
                    enemy.chars[2].GetComponent<Char>().costEnemy =Int32.Parse(enemyCost.text); 
                }
                else
                {
                    enemy.chars[2].GetComponent<Char>().speedEnemy = 1;
                }
                break;
            
        }
        }
        catch (NullReferenceException)
        {
        }

        
    }
}
