using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	public enum FoodType {
		Nothing,
		Trash,
		Water,
		Tomato,
		Meat,
		SoupTomato,
		SoupMeat,
		SoupStew
	}		
	public int foodName = (int)FoodType.Trash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
