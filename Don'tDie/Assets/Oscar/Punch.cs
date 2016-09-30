using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

    public Animator anim;

    public BaseStatesOfPlayer baseStates;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        baseStates = FindObjectOfType<BaseStatesOfPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && baseStates.currentWeapon == Weapons.Punch)
        {
            anim.SetTrigger("HandChop");
        }

    }
}
