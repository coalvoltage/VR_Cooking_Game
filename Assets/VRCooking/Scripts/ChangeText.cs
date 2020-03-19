using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeText : MonoBehaviour
{
	public string gameO;
	public string theText;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        t.text = theText;
    }
}
