﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[Serializable]
public class CharacterMovesLikeABoss : MonoBehaviour
{
    public Vector3 pos;
    public Rigidbody rig;
	public float speed = 5;
    public float walkSpeed = 5;
	public float sprintSpeed = 15;
    //public float distance;

	public int currentRawMeat = 0;
	public int currentCookedMeat = 0;
	public int currentMinerals = 0;
	public int currentRawFruit = 0;
	public int currentCookedFruit = 0;
	public int currentSpears = 0;

	public Stat health;
	public Stat energy;

    public GameObject deathScreen = null;

    public GameObject bulletPrefab = null;
    public Vector3 vel;

    public GameObject spawnPoint;


    void Start ()
    {
        rig = GetComponent<Rigidbody>();
		speed = speed * Time.deltaTime;
		sprintSpeed = sprintSpeed * Time.deltaTime;
		walkSpeed = walkSpeed * Time.deltaTime;
	}

	public void Awake()
	{
		health.Initialize ();
		energy.Initialize ();
		deathScreen.SetActive(false);
	}
	
	void Update ()
    {
		if (energy.CurrentVal <= 5) 
		{
			energy.CurrentVal = 4;
			health.CurrentVal -= Time.deltaTime;
		} else
			health.CurrentVal = health.CurrentVal;
			energy.CurrentVal -= Time.deltaTime;

		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			speed = sprintSpeed;
			energy.CurrentVal -= Time.deltaTime * 1.5f;
		} else
			speed = walkSpeed;
			energy.CurrentVal = energy.CurrentVal;



		if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, spawnPoint.transform.position, transform.rotation);
        }

		/*
		 * Figuring out a "Jump" button
		 * 
		 * if (Input.GetKey(KeyCode.Space))
		{
			rig.AddForce  * Vector3.up;
		}*/

        if (Input.GetKey(KeyCode.W))
        {
            pos = gameObject.transform.rotation * new Vector3(pos.x,0,1);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            pos = gameObject.transform.rotation * new Vector3 (-1,0,pos.z);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            pos = gameObject.transform.rotation * new Vector3 (pos.x,0,-1);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            pos = gameObject.transform.rotation * new Vector3 (1,0,pos.z);
        }

        else
        {
            pos = Vector3.zero;
        }
       rig.velocity = pos * speed;
       vel = rig.velocity;

		if (Input.GetKeyDown (KeyCode.Alpha1) && currentRawFruit > 0) 
		{
			health.CurrentVal += 5;
			energy.CurrentVal += 5;
			currentRawFruit -= 1;
		}

		if (Input.GetKeyDown (KeyCode.Alpha2) && currentRawMeat > 0) 
		{
			health.CurrentVal += 10;
			energy.CurrentVal += 10;
			currentRawMeat -= 1;
		}

		if (health.CurrentVal <=0)
		{
			speed = 0;
			walkSpeed = 0;
			sprintSpeed = 0;
			deathScreen.SetActive (true);
		}

		if (health.CurrentVal >= health.MaxVal) 
		{
			health.CurrentVal = health.MaxVal;
		}
		if (energy.CurrentVal >= energy.MaxVal) 
		{
			energy.CurrentVal = energy.MaxVal;
		}
    }

	public void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name.StartsWith ("Enemy")) 
		{
			health.CurrentVal -= 20;
		}
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.name.StartsWith ("Meat")) 
		{
			currentRawMeat++;
			Destroy (other.gameObject);
		}

		if (other.gameObject.name.StartsWith ("Fruit")) 
		{
			currentRawFruit++;
			Destroy (other.gameObject);
		}

		if (other.gameObject.name.StartsWith ("Minerals")) 
		{
			currentMinerals++;
			Destroy (other.gameObject);
		}

		if (other.gameObject.name.StartsWith ("Spear")) 
		{
			currentSpears++;
			Destroy (other.gameObject);
		}
	

		/*
		if (other.gameObject.name.StartsWith ("MineralPickup"))
		{
			mineralsHeld ++;
		}
		if (other.gameObject.name.StartsWith ("Fruit"))
		{
			fruitHeld ++;
		}
		if (other.gameObject.name.StartsWith ("SpearPickup"))
		{
			spearHeld = true;
		}
		if (other.gameObject.tag == ("Pickup"))
		{
			Destroy(other.gameObject);
		}
		*/
	}

    /*public void OnDestroy()
    {
        loseText.SetActive(true);
    }*/
}
