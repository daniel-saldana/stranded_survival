﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public GameObject player;
	public Transform playerPos;

	public int health = 5; 
	public float speed = 0.0f;
	//public bool active = false;

	public GameObject meatPrefab = null;

    // Use this for initialization
    void Start () 
	{
		player = GameObject.Find ("Player");
		playerPos = player.transform;
    }


    public void Update()
    {
		//transform.LookAt (playerPos);
		if (health <= 0)
		{
			Destroy(gameObject);
		}
		Follow ();
    }

	// Update is called once per frame
	void Follow () 
	{
		if (player) 
		{
			transform.position = Vector3.MoveTowards (transform.position, playerPos.position, speed * Time.deltaTime);
		}
	}

	/*public void OnTriggerStay (Collider other)
	{
		if (active == true) 
		{
			if (player) 
			{
				Follow ();
			}
		}
	}*/
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.StartsWith ("PlayerBullet"))
        {
			health -= 1;
			Destroy (other.gameObject);
        }
		/*if (other.gameObject.name.StartsWith ("PlayerTool"))
		{
			health --;
		}*/

    }
	public void OnDestroy()
    {
        Instantiate(meatPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
