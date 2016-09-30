using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour
{

    public int health = 4;

    public BaseStatesOfPlayer bs;

    // Use this for initialization
    void Start () {
        bs = FindObjectOfType<BaseStatesOfPlayer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hand")
        {
            health -= bs.weaponStrength;
        }
    }
}
