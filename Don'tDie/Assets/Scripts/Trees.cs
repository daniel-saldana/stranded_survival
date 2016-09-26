using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour
{

    public int health = 4;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	if (health <= 0)
        {
            Destroy (gameObject);
        }
	}
}
