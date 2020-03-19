using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPot : CookingMethod
{
	const float COOK_TIME_LIMIT = 5.0f;
    public float cookingTimer;
    public bool isCooking;

	
	public GameObject[] foodLooks = new GameObject[Enum.GetNames(typeof(Food.FoodType)).Length];
	public GameObject[] currentFoodRender = new GameObject[Enum.GetNames(typeof(Food.FoodType)).Length];
    // Start is called before the first frame update
    void Start()
    {
        cookingTimer = 0.0f;
		isCooking = false;
		
    }

    // Update is called once per frame
    void Update()
    {
		//Cooking here
        if(isCooking && cookingTimer < COOK_TIME_LIMIT && !(foodArray == null || foodArray.Length == 0)){
			cookingTimer += Time.deltaTime;
		}
		else if(!isCooking && cookingTimer > 0){
			cookingTimer -= Time.deltaTime;
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
            else if(foodArray == null || foodArray.Length == 0)
            {
                for (int i = 0; i < currentFoodRender.Length; i++)
                {
                    if (currentFoodRender[i] != null)
                    {
                        Destroy(currentFoodRender[i]);
                    }
                }
                haveCollided = false;
            }
			else {
				haveCollided = false;
			}
		}
		
		// Recipes here
		if(cookingTimer >= COOK_TIME_LIMIT) {
			//Rendering Clear Ingredients
			for(int i = 0; i < currentFoodRender.Length; i++) {
				if(currentFoodRender[i] != null) {
					Destroy(currentFoodRender[i]);
				}
			}
			
			if(foodArray[(int)Food.FoodType.Tomato] == 4 && foodArray[(int)Food.FoodType.Water] == 1) {
                //Clear and replace with finished recipe
				Array.Clear(foodArray, 0, foodArray.Length);
				
				foodArray[(int)Food.FoodType.TomatoSoup] = 1;
				
				//Spawn Food Render Output
				currentFoodRender[(int)Food.FoodType.TomatoSoup] = Instantiate(foodLooks[(int)Food.FoodType.TomatoSoup]);

				currentFoodRender[(int)Food.FoodType.TomatoSoup].transform.SetParent(gameObject.transform);
				currentFoodRender[(int)Food.FoodType.TomatoSoup].transform.localPosition = new Vector3(0.0f, 0.2f, 0.0f);
			}
			else if(foodArray[(int)Food.FoodType.RawMeat] == 1 && foodArray[(int)Food.FoodType.Water] == 4) {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);
				
				foodArray[(int)Food.FoodType.Broth] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Broth] = Instantiate(foodLooks[(int)Food.FoodType.Broth]);

				currentFoodRender[(int)Food.FoodType.Broth].transform.SetParent(gameObject.transform);
				currentFoodRender[(int)Food.FoodType.Broth].transform.localPosition = new Vector3(0.0f, 0.2f, 0.0f);
			}
            else if (foodArray[(int)Food.FoodType.Tomato] == 5)
            {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);

                foodArray[(int)Food.FoodType.Sauce] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Sauce] = Instantiate(foodLooks[(int)Food.FoodType.Sauce]);

                currentFoodRender[(int)Food.FoodType.Sauce].transform.SetParent(gameObject.transform);
                currentFoodRender[(int)Food.FoodType.Sauce].transform.localPosition = new Vector3(0.0f, 0.2f, 0.0f);
            }
            else {
				Array.Clear(foodArray, 0, foodArray.Length);
				foodArray[(int)Food.FoodType.Trash] = 1;
			}
			
			cookingTimer = 0.0f;
		}
    }
	
	public override void Cooking() {
		//empty
		isCooking = true;
	}

    public override void StopCook()
    {
        isCooking = false;
    }

    public override int GetResetFood()
    {
        int output = 0;
        for (int i = 0; i < foodArray.Length; i++)
        {
            if (foodArray[i] != 0)
            {
                output = i;
            }
        }

        for (int i = 0; i < currentFoodRender.Length; i++)
        {
            if (currentFoodRender[i] != null)
            {
                Destroy(currentFoodRender[i]);
            }
        }

        Array.Clear(foodArray, 0, foodArray.Length);
        haveCollided = true;
        return output;
    }
}
