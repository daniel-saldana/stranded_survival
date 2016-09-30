using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	//public GameObject meatPrefab = null;
    public int health = 5; 

	// Use this for initialization
	void Start ()
    {
        bs = FindObjectOfType<BaseStatesOfPlayer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            GameObject dest = (GameObject)Instantiate(Resources.Load("RawMeat"), transform.position, transform.rotation);


            Destroy(gameObject);
        }
    }
	/*public void OnDestroy()
    {
        Instantiate(meatPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }*/
}
