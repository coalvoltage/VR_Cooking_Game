using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScore : MonoBehaviour
{
	public string gameO1;
	public string gameO2;
	public string gameO3;
	public string theText;
	public int score;
	public GameObject g1, g2, g3;
    // Start is called before the first frame update
    void Start()
    {
		g1 = GameObject.Find(gameO1);
		g2 = GameObject.Find(gameO2);
		g3 = GameObject.Find(gameO3);
		score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        score = g1.GetComponent<CFood>().completed + g2.GetComponent<CFood>().completed + g3.GetComponent<CFood>().completed;
		t.text = score.ToString();
    }
}
