using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VrReload : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public GameObject topCollider;
    Transform position;
    Transform basePosition;
    int ammunition;

    
    void Start()
    {
        ammunition = 10;
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        Transform position = GetComponent<Transform>();
        //grabInteractable.selectEntered.AddListener(x => PreDetatch());
        grabInteractable.selectExited.AddListener(x => Detatch());

    }
    void Detatch(){
        transform.parent.GetComponent<VrShooting>().RemoveMagazine(); //działa dopiero po puszczeniu - selectEntered nie działa z praktycznie niczym
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        topCollider.GetComponent<BoxCollider>().enabled = true;
    }
    public void Attatch(GameObject parent){
        transform.parent = parent.transform;
        topCollider.GetComponent<BoxCollider>().enabled = false;
        //grabInteractable.interactionManager.CancelInteractableSelection(grabInteractable);
        gameObject.transform.SetLocalPositionAndRotation(parent.GetComponent<VrShooting>().GetMagazineTransform(), parent.GetComponent<VrShooting>().GetMagazineRotation());
        parent.GetComponent<VrShooting>().LoadMagazine(this);
        GetComponent<Rigidbody>().isKinematic = true;

    }
    public int GetAmmunition(){
        return ammunition;
    }
    public void AmmunitionUsed(){
        ammunition--;
    }
}
