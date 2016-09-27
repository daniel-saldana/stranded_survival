using UnityEngine;
using System.Collections;

public class Minerals : MonoBehaviour
{
	//public GameObject mineralPickupPrefab = null;
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
	/*public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name.StartsWith ("PlayerTool"))
		{
			health --;
		}
	}*/
	/*public void OnDestroy()
	{
		Instantiate(mineralPickupPrefab, gameObject.transform.position, gameObject.transform.rotation);
	}*/
}
