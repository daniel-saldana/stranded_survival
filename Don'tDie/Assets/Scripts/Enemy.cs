using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public int health = 10;
    public BaseStatesOfPlayer bs;

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

    public void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.name.StartsWith("PlayerBullet"))// || other.gameObject.name.StartsWith("Spear") || other.gameObject.name.StartsWith("Hand"))
        {
            health -= bs.weaponStrength;
        }
    }
}
