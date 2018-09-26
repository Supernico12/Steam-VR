using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;



public class WeaponController : MonoBehaviour
{


    [SerializeField] public WeaponTypes types;
    [SerializeField] Transform weaponShotPosition;
    public float MaxDistance;
    [SerializeField] GameObject HitParticles;
    [SerializeField] ParticleSystem Muzzle;
    [SerializeField] Transform MuzzleSpawnPosition;
    [SerializeField] GameObject Shell;
    [SerializeField] Transform shellSpawnPosition;
    [SerializeField] Vector3 force;
    [Header("Stats")]
    [SerializeField] public bool isAutomatic;
    [SerializeField] float ShootDelay;
    [SerializeField] float damage;
    [SerializeField] float maxAmmo;
    
    [HideInInspector]public bool hasMagazine = true;

    WeaponRecoil recoil;
    float currenttime;
    float currentAmmo;
    void Start()
    {
        currentAmmo = maxAmmo;
        hasMagazine= true;
        recoil = GetComponent<WeaponRecoil>();
    }

    void Update()
    {








    }
    public void Shoot()
    {
        if (currenttime < Time.time)
        {
            if(hasMagazine){
            if(currentAmmo > 0){
            currenttime = Time.time + 1 / ShootDelay;
            Shoot();

            RaycastHit hit;
            Muzzle.Play();
            /*
            if(Shell != null){
            Rigidbody rbshell =Instantiate( Shell , shellSpawnPosition.position , Random.rotation).GetComponent<Rigidbody>();
           
            if(rbshell != null){
                rbshell.AddForce( new Vector3 (force.x * transform.right.x , force.y * transform.up.y , 0f )  ,ForceMode.Impulse);
                Destroy(rbshell.gameObject, 5);
            }
             }
              */
            // recoil.OnShoot();
            if (Physics.Raycast(weaponShotPosition.position, weaponShotPosition.forward, out hit, MaxDistance))
            {
                ShotEffect(hit);
            }
            if(recoil != null)
                recoil.AddRecoil();
           currentAmmo--;
        }
        }
        }
    }

    void ShotEffect(RaycastHit hit)
    {
        
        
        Instantiate(HitParticles, hit.point, Quaternion.LookRotation(hit.normal));

        CharacterStats targetStats =hit.transform.GetComponent<CharacterStats>();
        if(targetStats != null){
            targetStats.TakeDamage(damage);
        }
    }

    public void Reload(float ammo){
        currentAmmo = ammo;
    }

    public float GetAmmo(){
        return currentAmmo;
    }


}
