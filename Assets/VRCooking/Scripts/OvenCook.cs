using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenCook : MonoBehaviour
{
    public OpenInRange ovenDoor;
    CookingMethod tempCook;
    bool isTrackingCooking = false;

    public Material fireMat;
    public Material openMat;
    bool openRender = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = openMat;
        openRender = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ovenDoor.isOpen && !openRender)
        {
            gameObject.GetComponent<MeshRenderer>().material = openMat;
            openRender = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "cooking" && !ovenDoor.isOpen)
        {
            //particle
            if (!isTrackingCooking)
            {
                CookingMethod tempCook = other.gameObject.GetComponent(typeof(CookingMethod)) as CookingMethod;
                tempCook.Baking();
                isTrackingCooking = true;

                gameObject.GetComponent<MeshRenderer>().material = fireMat;
                openRender = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cooking")
        {
            if (isTrackingCooking)
            {
                CookingMethod tempCook = other.gameObject.GetComponent(typeof(CookingMethod)) as CookingMethod;
                tempCook.Baking();
                isTrackingCooking = false;
            }
            isTrackingCooking = false;
        }
    }
}
