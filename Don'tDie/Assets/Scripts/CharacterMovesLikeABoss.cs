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

 //  public  Animator anim;


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
        baseStates.weaponStrength = 2;

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



		if (Input.GetButtonDown("Fire1") && baseStates.bulletsHeld > 0 && baseStates.currentWeapon == Weapons.Gun)
        {
            Instantiate(bulletPrefab, spawnPoint.transform.position, transform.rotation);
			baseStates.bulletsHeld -= 1;
        }

        if (Input.GetButtonDown("Fire1") && baseStates.spear > 0 && baseStates.currentWeapon == Weapons.Spear)
        {
            Instantiate(bulletPrefab, spawnPoint.transform.position, transform.rotation);
            baseStates.spear -= 1;
        }

       //if (Input.GetButtonDown("Fire1") && baseStates.currentWeapon == Weapons.Punch)
       // {
        //    anim.SetTrigger("HandChop");
       // }

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
            baseStates.weaponStrength = 3;
        }
        if (baseStates.wepCounter == 1)
        {
            baseStates.currentWeapon = Weapons.Spear;
            baseStates.weaponStrength = 10;
        }
        if (baseStates.wepCounter == 2)
        {
            baseStates.currentWeapon = Weapons.Gun;
            baseStates.weaponStrength = 5;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name.StartsWith("Enemy"))
        {
            health.CurrentVal -= 5;            
        }
    }



    /*public void OnDestroy()
    {
        loseText.SetActive(true);
    }*/
}
