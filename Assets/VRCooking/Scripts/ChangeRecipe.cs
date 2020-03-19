using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRecipe : MonoBehaviour
{
	private int i = 0;
	public Material[] materials;
	private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = materials[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
			if(i < 2){
				i++;
			}else{
				i = 0;
			}
            meshRenderer.material = materials[i];
        }
    }
}
