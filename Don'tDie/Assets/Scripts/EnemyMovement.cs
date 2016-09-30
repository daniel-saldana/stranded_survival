using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public GameObject player;

	public Transform playerPos;

	public float speed = 0.0f;
	public bool active = false;

    public int health = 10;
    public BaseStatesOfPlayer bs;

    // Use this for initialization
    void Start () 
	{
		player = GameObject.Find ("Player");
		playerPos = player.transform;
        bs = FindObjectOfType<BaseStatesOfPlayer>();
    }


    public void Update()
    {
        if (health <= 0)
        {
            GameObject dest = (GameObject)Instantiate(Resources.Load("RawMeat"), transform.position, transform.rotation);


            Destroy(gameObject);
        }

    }

	// Update is called once per frame
	void Follow () 
	{
		if (player) 
		{
			transform.position = Vector3.MoveTowards (transform.position, playerPos.position, speed);
		}
	}

	public void OnTriggerStay (Collider other)
	{
		if (active == true) 
		{
			if (player) 
			{
				Follow ();
			}
		}
	}
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name.StartsWith("PlayerBullet") || other.gameObject.name.StartsWith("Spear") || other.gameObject.name.StartsWith("Hand"))
        {
            health -= bs.weaponStrength;
        }
    }
}
