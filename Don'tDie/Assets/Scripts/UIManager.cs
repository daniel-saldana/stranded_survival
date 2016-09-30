using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour 
{

    public BaseStatesOfPlayer baseStates;

    public Text rawMeat;
    public Text cookedMeat;
    public Text ores;
    public Text bullets;
    public Text currentWeapon;
    public Text spear;
    public Text treeBark;
    public GameObject materialPanel;
    public bool panelOn;

    public CharacterMovesLikeABoss cb;
	// Use this for initialization
	void Start () 
	{
        cb = FindObjectOfType<CharacterMovesLikeABoss>();
        baseStates = FindObjectOfType<BaseStatesOfPlayer>();
        panelOn = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
        bullets.text = "Bullets = " + baseStates.bulletsHeld;
        rawMeat.text = "Raw Meat = " + baseStates.rawMeat;
        cookedMeat.text = "Cooked Meat = " + baseStates.cookedMeat;
        ores.text = "Ores = " + baseStates.oreHeld;
        currentWeapon.text = " Current Weapon: " + baseStates.currentWeapon;
        spear.text = "Spears = " + baseStates.spear;
        treeBark.text = "Tree Bark = " + baseStates.treeBark;

        if(panelOn)
        {

            materialPanel.SetActive(true);
        }
        else
        {
            materialPanel.SetActive(false);
        }
	}

    public void ChangePanel()
    {
        panelOn = !panelOn;
    }

    public void EatRawMeat()
    {
        if(baseStates.rawMeat > 0)
        {
            baseStates.rawMeat -= 1;
            cb.energy.CurrentVal += 10;
            cb.health.CurrentVal -= 5; 
        }
    }

    public void EatMeat()
    {
        if (baseStates.cookedMeat > 0)
        {
            baseStates.cookedMeat -= 1;
            cb.energy.CurrentVal += 15;
            cb.health.CurrentVal += 10;
        }
    }

    public void EatTreeBark()
    {
        if (baseStates.treeBark > 0)
        {
            baseStates.treeBark -= 1;
            cb.energy.CurrentVal += 5;
        }
    }

}
