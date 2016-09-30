using UnityEngine;
using System.Collections;

public class Plants : MonoBehaviour
{

    BaseStatesOfPlayer bp;

    // Use this for initialization
    void Start ()
    {
        bp = FindObjectOfType<BaseStatesOfPlayer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
      
    }

    public void OnCollisionEnter (Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            bp.treeBark += 1;
            Destroy(gameObject);
        }
    }
}
