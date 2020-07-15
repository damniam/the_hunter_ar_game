using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingController : MonoBehaviour
{

    public float damage = 35f;
    public float shotPower = 300;
    public float bulletSpeed = 500;

    public Camera fpsCamera;
    
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;

    
    public Text ammo1Text;
    public Text ammo2Text;
    public int magazine = 20;
    public int ammo;
    private bool ammoIsEmpty;
   
    private bool reloadCheck;
    public Animator gun;

    AudioSource shootSound;
    AudioSource reloadSound;
    // Use this for initialization
    void Start()
    {
        ammo = GameManager.Instance.CurrentPlayer.Ammo - 20;

        if (barrelLocation == null)
            barrelLocation = transform;
      

        // AudioSource[] audios = GetComponents<AudioSource>();
        // shootSound = audios[0];
        // reloadSound = audios[1];

        reloadCheck = true;
    }
    private void Update()
    {

    }

    IEnumerator waitForReload()
    {
        yield return new WaitForSeconds(3f);
        reloadCheck = true;
    }


    public void Shoot()
    {
        Debug.Log("Shoot");
        if (!ammoIsEmpty && reloadCheck)
        {
            //Ammo

            if (magazine == 0)
            {
                Debug.Log("0 ammo reload");
                magazine = 20;
                reloadCheck = false;
                StartCoroutine(waitForReload());
                reloadSound.Play();
            }

            magazine -= 1;
            ammo1Text.text = magazine.ToString();
            
            ammo -= 1;
            ammo2Text.text = ammo.ToString();
            

            if (ammo == 0)
            {
                ammoIsEmpty = true;
                magazine = 0;
                ammo1Text.text = magazine.ToString();  
            }


            // Raycasting

            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
            {

                ZombieAR target = hit.transform.GetComponent<ZombieAR>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * shotPower);
                }
                Debug.Log(hit.transform.name);
                
            }

            // Sound & Animation Play
            Debug.Log("halko");
            //shootSound.Play();
            

            GetComponent<Animator>().SetTrigger("Fire");
            
            GameObject tempFlash;
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * bulletSpeed);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

        }
    }

   public void CasingRelease()
    {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }

    public void Reload()
    {
        StartCoroutine(waitForReload());
        if(magazine != 20)
        {
            int full = 20 - magazine;
            ammo -= full;
            if (ammo > 0)
            {
                magazine = 20;
                ammo1Text.text = magazine.ToString();
                ammo2Text.text = ammo.ToString();
            }
        }
    }
}
