using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
	public float speed = 0.0f;
	public Vector3 vec;
	public Rigidbody rig;

    public CharacterMovesLikeABoss val;
    public Enemy food;

    // Use this for initialization
    void Start () 
	{
		rig = GetComponent<Rigidbody> ();
        val = FindObjectOfType<CharacterMovesLikeABoss>();


    }

	// Update is called once per frame
	void Update () 
	{
			vec = gameObject.transform.rotation * Vector3.forward;
			rig.velocity = vec * speed;
			Destroy (gameObject, 4);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.StartsWith("Level"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name.StartsWith("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
