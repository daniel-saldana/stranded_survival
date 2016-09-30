using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour
{

	//public GameObject spearPickupPrefab = null;
    public int health = 4;

    public BaseStatesOfPlayer bs;

    // Use this for initialization
    void Start () {
        bs = FindObjectOfType<BaseStatesOfPlayer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hand")
        {
            health -= bs.weaponStrength;
        }
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
