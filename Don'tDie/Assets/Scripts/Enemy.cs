using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

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
	public void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.name.StartsWith ("PlayerBullet"))
		{
			Destroy(gameObject);
		}
		if (other.gameObject.name.StartsWith ("PlayerTool"))
		{
			health -= 1;
		}
		if (other.gameObject.name.StartsWith ("Spear"))
		{
			health -= 2;
		}
	}
}
