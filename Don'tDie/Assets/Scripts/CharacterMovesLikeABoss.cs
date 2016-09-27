using UnityEngine;
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

    //public GameObject loseText = null;

    public GameObject bulletPrefab = null;
    public Vector3 vel;

    public GameObject spawnPoint;


    void Start ()
    {
        rig = GetComponent<Rigidbody>();
		speed = speed * Time.deltaTime;
		sprintSpeed = sprintSpeed * Time.deltaTime;
		walkSpeed = walkSpeed * Time.deltaTime;

       // loseText.SetActive(false);
    
	}

	public void Awake()
	{
		health.Initialize ();
		energy.Initialize ();
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
            pos = gameObject.transform.rotation * Vector3.forward;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            pos = gameObject.transform.rotation * Vector3.left;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            pos = gameObject.transform.rotation * Vector3.back;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            pos = gameObject.transform.rotation * Vector3.right;
        }

        else
        {
            pos = Vector3.zero;
        }
       rig.velocity = pos * speed;
       vel = rig.velocity;
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
