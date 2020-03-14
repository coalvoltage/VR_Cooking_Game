using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMethod : MonoBehaviour
{
	int MAX_RECIPE_SIZE = 5;
	int recipeCounter = 0;
	public bool haveCollided = false;
	
	public int[] foodArray = new int[Enum.GetNames(typeof(Food.FoodType)).Length];
	
    // Start is called before the first frame update
    void Start()
    {
        Array.Clear(foodArray, 0, foodArray.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "food" && recipeCounter < MAX_RECIPE_SIZE) {
			foodArray[other.gameObject.GetComponent<Food>().foodName] += 1;
			recipeCounter += 1;
			Destroy(other.gameObject);
			haveCollided = true;
		}
    }
	
	virtual public void Cooking() {
		//Nothing save for other methods
	}
}
