using UnityEngine;
using System.Collections;

public class CookMeat : MonoBehaviour
{


    public BaseStatesOfPlayer baseState;

	// Use this for initialization
	void Start ()
    {
        baseState = GetComponent<BaseStatesOfPlayer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Stove" && baseState.rawMeat > 0)
        {
            baseState.canCookMeat = true;
        }

        if (other.gameObject.name == "Wood" && baseState.treeBark > 1)
        {
            baseState.canWoodWork = true;
        }
    }

    public void OnTriggerStay (Collider other)
    {
        if(other.gameObject.name == "Stove" && Input.GetKeyDown(KeyCode.E) && baseState.canCookMeat)
        {
            if (baseState.rawMeat > 0)
            {
                baseState.rawMeat -= 1;
                baseState.cookedMeat += 1;
            }

            else
            {
                Debug.Log("No Raw Meat To Cook");
            }
        }

        if (other.gameObject.name == "Wood" && Input.GetKeyDown(KeyCode.E) && baseState.canWoodWork)
        {
            if (baseState.treeBark > 1)
            {
                baseState.treeBark -= 2;
                baseState.spear += 1;
            }

            else
            {
                Debug.Log("No tree branches");
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Stove")
        {
            baseState.canCookMeat = false;
        }

        if(other.gameObject.name == "Wood")
        {
            baseState.canWoodWork = false;
        }
    }
}
