using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	public GameObject player;

	public Transform playerPos;

	public float speed = 0.0f;
	public bool active = false;

    // Use this for initialization
    void Start () 
	{
		player = GameObject.Find ("Player");
		playerPos = player.transform;
    }


    public void Update()
    {
       
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
    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name.StartsWith ("PlayerBullet"))
        {
            Destroy(gameObject);
        }
    }
}
