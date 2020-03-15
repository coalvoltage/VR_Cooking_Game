using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInRange : MonoBehaviour
{
	public GameObject primeHand;
	public GameObject secondHand;
	public bool isOpen = false;
	public bool isHolding = false;
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
        if(((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) > 0.1f 
			|| OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.1f)
			&& other.gameObject == secondHand && isHolding == false) ||
			((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.1f 
			|| OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch)> 0.1f)
			&& other.gameObject == primeHand && isHolding == false)) {
            isHolding = true;
        }
        else if(((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch) < 0.1f 
			|| OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) < 0.1f)
			&& other.gameObject == secondHand && isHolding == false) ||
			((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) < 0.1f 
			|| OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch) < 0.1f)
			&& other.gameObject == primeHand && isHolding == true)) {
			isHolding = false;
			isOpen = true;
			
		}
    }
}
