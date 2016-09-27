using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour
{
	//public GameObject spearPickupPrefab = null;
    public int health = 4;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	if (health <= 0)
        {
            Destroy (gameObject);
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
		Instantiate(spearPickupPrefab, gameObject.transform.position, gameObject.transform.rotation);
	}*/
}
