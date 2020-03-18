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
        if((OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ||
           OVRInput.Get(OVRInput.RawButton.LHandTrigger) && other.gameObject == secondHand) ||
           (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) ||
           OVRInput.Get(OVRInput.RawButton.RHandTrigger)) && other.gameObject == primeHand)
        {
            isOpen = !isOpen;
            if (isOpen)
            {
                gameObject.transform.Rotate(0.0f, 90.0f, 0.0f, Space.World);
            }
            else
            {
                gameObject.transform.Rotate(0.0f, -90.0f, 0.0f, Space.World);
            }
        }
    }
}
