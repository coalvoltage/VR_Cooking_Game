using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
	public GameObject primeHand;
	public GameObject secondHand;
	public GameObject g;
	public int score;
	public bool failed;
    // Start is called before the first frame update
    void Start()
    {
        failed = false;
		gameObject.SetActive(false);
		score = 0;
    }

    // Update is called once per frame
    void Update()
    {
		score = g.GetComponent<ChangeScore>().score;
		if(g.GetComponent<ChangeScore>().failcount >= 4)
		{
			failed = true;
			g.SetActive(false);
		}
		if(failed == true )
			gameObject.SetActive(true);
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
		t.text = "Game Over \n Final score:" + score.ToString() + "\n\n Restart?";
    }
	private void OnTriggerStay(Collider other)
    {
        if(((OVRInput.Get(OVRInput.RawButton.LIndexTrigger) ||
           OVRInput.Get(OVRInput.RawButton.LHandTrigger) && other.gameObject == secondHand) ||
           (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) ||
           OVRInput.Get(OVRInput.RawButton.RHandTrigger)) && other.gameObject == primeHand) && failed == true)
        {
			 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

	
	
	
}
