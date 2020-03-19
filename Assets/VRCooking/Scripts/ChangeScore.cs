using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScore : MonoBehaviour
{
	public int score, failcount, s2, s3, f2, f3;
	public GameObject g1, g2, g3;
	public bool g2on, g3on;
    // Start is called before the first frame update
    void Start()
    {
		g2.gameObject.SetActive(false);
		g3.gameObject.SetActive(false);
		score = 0;
		failcount = 0;
		f2 = 0;
		f3 = 0;
		s2 = 0;
		s3 = 0;
		g2on = false;
		g3on = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(score >= 2){
			g2on = true;
			g2.gameObject.SetActive(g2on);
		}
		if(score >= 4){
			g3on = true;
			g3.gameObject.SetActive(g3on);
		}
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
		if(g2on){
			s2 = g2.GetComponent<CFood>().completed;
			f2 = g2.GetComponent<CFood>().failed;
		}
		if(g3on){
			s3 = g3.GetComponent<CFood>().completed;
			f3 = g3.GetComponent<CFood>().failed;
		}
        score = g1.GetComponent<CFood>().completed + s2 + s3;
		failcount = g1.GetComponent<CFood>().failed + f2 + f3;
		t.text = score.ToString();
    }
}
