using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[Serializable]
public class CharacterMovesLikeABoss : MonoBehaviour
{
    public Vector3 pos;
    public Rigidbody rig;
	public float speed;
    public float walkSpeed;
	public float sprintSpeed;
    //public float distance;


	public Stat health;
	public Stat energy;

    //public GameObject loseText = null;

    public GameObject bulletPrefab = null;
    public Vector3 vel;

    public GameObject spawnPoint;

    public KeyCode switchWepInput = KeyCode.Tab;

    public BaseStatesOfPlayer baseStates;

    void Start ()
    {
        rig = GetComponent<Rigidbody>();
        baseStates = GetComponent<BaseStatesOfPlayer>();

       // loseText.SetActive(false);
    
	}

	public void Awake()
	{
		health.Initialize ();
		energy.Initialize ();
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(switchWepInput))
        {
            SwitchWeapon();
        }

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

    void SwitchWeapon()
    {
        baseStates.wepCounter++;

        if (baseStates.wepCounter >= 3)
        {
            baseStates.wepCounter = 0;
        }

        if (baseStates.wepCounter == 0)
        {
            baseStates.currentWeapon = Weapons.Punch;
        }
        if (baseStates.wepCounter == 1)
        {
            baseStates.currentWeapon = Weapons.Spear;
        }
        if (baseStates.wepCounter == 2)
        {
            baseStates.currentWeapon = Weapons.Gun;
        }
    }



    /*public void OnDestroy()
    {
        loseText.SetActive(true);
    }*/
}
