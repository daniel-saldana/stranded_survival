using UnityEngine;
using System.Collections;

public enum Weapons { Punch, Gun, Spear}

public class BaseStatesOfPlayer : MonoBehaviour
{
    //public int health;

    public int cookedMeat;

    public int rawMeat;

    public int wepCounter;

    public Weapons currentWeapon;

    public bool canCookMeat;

}
