using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	//public GameObject meatPrefab = null;
    public int health = 5; 

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
	/*public void OnDestroy()
    {
        Instantiate(meatPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }*/
}
