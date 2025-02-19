using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VrShooting : MonoBehaviour
{
    public AudioSource bulletSound;
    public AudioSource noAmmoSound;
    public Transform bulletTransform;
    public GameObject bullet;
    public GameObject shell;
    public VrReload magazine;
    Vector3 magazineTransform;
    Quaternion magazineRotation;
    XRGrabInteractable grabInteractable;
    Rigidbody bulletPhysic;
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => Shoot());
        magazineTransform = magazine.transform.localPosition;
        magazineRotation = magazine.transform.localRotation;
    }

    void Shoot()
    {
        if (magazine != null)
        {
            if (magazine.GetAmmunition() > 0)
            {
                magazine.AmmunitionUsed();
                bulletSound.Play();
                GameObject shotBullet = GameObject.Instantiate(bullet);
                shotBullet.transform.position = bulletTransform.position;
                shotBullet.transform.rotation = bulletTransform.rotation;
                Rigidbody bulletPhysic = shotBullet.GetComponent<Rigidbody>();
                bulletPhysic.velocity = shotBullet.transform.forward * 15f;
            }
            else{
                noAmmoSound.Play();
            }
        }
        else{
            noAmmoSound.Play();
        }

    }
    void OnCollisionEnter(Collision other){
        if(magazine == null){
            if (other.gameObject.tag == "Magazine"){
                VrReload magazine = other.gameObject.GetComponent<VrReload>();
                magazine.Attatch(gameObject);
            }
        }
    }
    public void RemoveMagazine(){
        if (magazine != null){
            magazine = null;
        }
    }
    public void LoadMagazine(VrReload newMagazine){
        magazine = newMagazine;
    }
    public Vector3 GetMagazineTransform(){
        return magazineTransform;
    }
    public Quaternion GetMagazineRotation(){
        return magazineRotation;
    }
    void Reload(){

    }

}
