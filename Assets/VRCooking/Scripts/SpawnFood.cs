using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
	public GameObject primeHand;
	public GameObject secondHand;
	public Vector3 spawnSpot = new Vector3(9,10,10);
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
            GameObject duplicate = (GameObject)Instantiate(gameObject, spawnSpot, Quaternion.identity);
			duplicate.tag = "food";
        }
    }
}
