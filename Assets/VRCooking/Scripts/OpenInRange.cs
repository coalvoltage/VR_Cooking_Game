using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInRange : MonoBehaviour
{
	public GameObject primeHand;
	public GameObject secondHand;
	public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerStay(Collider other)
    {
        if(((OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.LTouch))
			&& other.gameObject == secondHand) ||
			((OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch) || OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch))
			&& other.gameObject == primeHand)) {
            isOpen = !isOpen;
        }
    }
}
