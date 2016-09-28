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
    }

    public void OnTriggerStay (Collider other)
    {
        if(other.gameObject.name == "Stove" && Input.GetKeyDown(KeyCode.Space) && baseState.canCookMeat)
        {
            baseState.rawMeat -= 1;
            baseState.cookedMeat += 1;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Stove")
        {
            baseState.canCookMeat = false;
        }

        if(other.gameObject.name == "Mineral")
        {

        }
    }
}
