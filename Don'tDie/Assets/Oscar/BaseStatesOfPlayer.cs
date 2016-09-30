using UnityEngine;
using System.Collections;

public enum Weapons { Punch, Gun, Spear}

public class BaseStatesOfPlayer : MonoBehaviour
{
    //public int playerhealth;
    public int treeBark;

    public int spear;

	public int oreHeld;

	public int bulletsHeld;

    public int cookedMeat;

    public int rawMeat;

    public int wepCounter;

    public Weapons currentWeapon;

    public bool canCookMeat;

	public bool doRockScience;

    public bool canWoodWork;
}
