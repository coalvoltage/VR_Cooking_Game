using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
	public bool newItem;
	public Vector3 position;
	public Quaternion rotation;
	
    // Start is called before the first frame update
    void Start()
    {
        newItem = true;
		position = gameObject.transform.position;
		rotation = gameObject.transform.rotation;
    }
	
	void OnCollisionExit(Collision collision)
	{
		if (newItem && (collision.gameObject.name == "kitchen_stand (1)"))
		{
			Instantiate(gameObject, position, rotation);
			newItem = false;
		}
	}
}
