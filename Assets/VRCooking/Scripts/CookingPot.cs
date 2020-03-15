using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPot : CookingMethod
{
	const int COOK_TIME_LIMIT = 180;
	public int cookingTimer;
	public bool isCooking;
	
	public GameObject[] foodLooks = new GameObject[Enum.GetNames(typeof(Food.FoodType)).Length];
	public GameObject[] currentFoodRender = new GameObject[Enum.GetNames(typeof(Food.FoodType)).Length];
    // Start is called before the first frame update
    void Start()
    {
        cookingTimer = 0;
		isCooking = false;
		
    }

    // Update is called once per frame
    void Update()
    {
		//Cooking here
        if(isCooking && cookingTimer < COOK_TIME_LIMIT && !(foodArray == null || foodArray.Length == 0)){
			cookingTimer++;
		}
		else if(!isCooking && cookingTimer > 0){
			cookingTimer--;
		}
		
		// Render Ingredients
		if(haveCollided) {
			if(foodArray[(int)Food.FoodType.Water] > 0) {
				if(currentFoodRender[(int)Food.FoodType.Water] != null) {
					Destroy(currentFoodRender[(int)Food.FoodType.Water]);
				}
				
				currentFoodRender[(int)Food.FoodType.Water] = Instantiate(foodLooks[(int)Food.FoodType.Water]);

				currentFoodRender[(int)Food.FoodType.Water].transform.SetParent(gameObject.transform);
				currentFoodRender[(int)Food.FoodType.Water].transform.localPosition = new Vector3(0.0f, 0.05f*foodArray[(int)Food.FoodType.Water], 0.0f);
				haveCollided = false;
			}
			else {
				haveCollided = false;
			}
		}
		
		// Recipes here
		if(cookingTimer == COOK_TIME_LIMIT) {
			//Rendering Clear Ingredients
			for(int i = 0; i < currentFoodRender.Length; i++) {
				if(currentFoodRender[i] != null) {
					Destroy(currentFoodRender[i]);
				}
			}
			
			if(foodArray[(int)Food.FoodType.Tomato] == 4 && foodArray[(int)Food.FoodType.Water] == 1) {
                //Clear and replace with finished recipe
				Array.Clear(foodArray, 0, foodArray.Length);
				
				foodArray[(int)Food.FoodType.SoupTomato] = 1;
				
				//Spawn Food Render Output
				currentFoodRender[(int)Food.FoodType.SoupTomato] = Instantiate(foodLooks[(int)Food.FoodType.SoupTomato]);

				currentFoodRender[(int)Food.FoodType.SoupTomato].transform.SetParent(gameObject.transform);
				currentFoodRender[(int)Food.FoodType.SoupTomato].transform.localPosition = new Vector3(0.0f, 0.2f, 0.0f);
			}
			else if(foodArray[(int)Food.FoodType.Meat] == 1 && foodArray[(int)Food.FoodType.Water] == 4) {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);
				
				foodArray[(int)Food.FoodType.SoupMeat] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.SoupMeat] = Instantiate(foodLooks[(int)Food.FoodType.SoupMeat]);

				currentFoodRender[(int)Food.FoodType.SoupMeat].transform.SetParent(gameObject.transform);
				currentFoodRender[(int)Food.FoodType.SoupMeat].transform.localPosition = new Vector3(0.0f, 0.2f, 0.0f);
			}
			else {
				Array.Clear(foodArray, 0, foodArray.Length);
				foodArray[(int)Food.FoodType.Trash] = 1;
			}
			
			cookingTimer = 0;
		}
    }
	
	public override void Cooking() {
		//empty
		isCooking = !isCooking;
	}
}
