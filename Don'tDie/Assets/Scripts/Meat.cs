using UnityEngine;
using System.Collections;

public class Meat : MonoBehaviour
{

    BaseStatesOfPlayer bp;

    // Use this for initialization
    void Start ()
    {
        bp = FindObjectOfType<BaseStatesOfPlayer>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            bp.rawMeat += 1;
            Destroy(gameObject);
        }
    }
}
