using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName= "New Magazine" , menuName= "Magazine")]
public class MagazineAmmo : ScriptableObject {

	public WeaponTypes type;
	

}


public enum WeaponTypes { Pistol , Rifle , Heavy , Sniper}