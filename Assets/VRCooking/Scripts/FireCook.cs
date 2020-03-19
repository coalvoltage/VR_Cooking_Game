using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCook : MonoBehaviour
{
    private ParticleSystem fireParticle;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem fireParticle = gameObject.GetComponent<ParticleSystem>();
        fireParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cooking")
        {
            CookingMethod tempCook = other.gameObject.GetComponent(typeof(CookingMethod)) as CookingMethod;
			tempCook.Cooking();
            fireParticle = gameObject.GetComponent<ParticleSystem>();
            fireParticle.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "cooking")
        {
            //particle
			CookingMethod tempCook = other.gameObject.GetComponent(typeof(CookingMethod)) as CookingMethod;
			tempCook.StopCook();
            fireParticle.Stop();
        }
    }
}
