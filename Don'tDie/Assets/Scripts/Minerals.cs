using UnityEngine;
using System.Collections;

public class Minerals : MonoBehaviour
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
            bp.oreHeld += 1;
            Destroy(gameObject);
        }
    }
}
