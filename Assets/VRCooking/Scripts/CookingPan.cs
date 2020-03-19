using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingPan : CookingMethod
{
    const float COOK_TIME_LIMIT = 5.0f;
    const float BAKE_TIME_LIMIT = 5.0f;
    public float cookingTimer;
    public float bakingTimer;
    public bool isCooking;
    public bool isBaking;

    public GameObject[] foodLooks = new GameObject[Enum.GetNames(typeof(Food.FoodType)).Length];
    public GameObject[] currentFoodRender = new GameObject[Enum.GetNames(typeof(Food.FoodType)).Length];
    // Start is called before the first frame update
    void Start()
    {
        cookingTimer = 0.0f;
        bakingTimer = 0.0f;
        isCooking = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Cooking here
        if (isCooking && cookingTimer < COOK_TIME_LIMIT && !(foodArray == null || foodArray.Length == 0))
        {
            cookingTimer += Time.deltaTime;
        }
        else if (!isCooking && cookingTimer > 0)
        {
            cookingTimer -= Time.deltaTime;
        }

        // Render Ingredients
        if (haveCollided)
        {
               haveCollided = false;
        }

        // Cooking Recipes here
        if (cookingTimer >= COOK_TIME_LIMIT)
        {
            //Rendering Clear Ingredients
            for (int i = 0; i < currentFoodRender.Length; i++)
            {
                if (currentFoodRender[i] != null)
                {
                    Destroy(currentFoodRender[i]);
                }
            }

            if (foodArray[(int)Food.FoodType.RawMeat] == 1 && foodArray[(int)Food.FoodType.Butter] == 1)
            {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);

                foodArray[(int)Food.FoodType.Steak] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Steak] = Instantiate(foodLooks[(int)Food.FoodType.Steak]);

                currentFoodRender[(int)Food.FoodType.Steak].transform.SetParent(gameObject.transform);
                currentFoodRender[(int)Food.FoodType.Steak].transform.localPosition = new Vector3(0.0f, 1.0f, 4.0f);
            }
            else if (foodArray[(int)Food.FoodType.Dough] == 3 && foodArray[(int)Food.FoodType.Butter] == 1)
            {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);

                foodArray[(int)Food.FoodType.Pancake] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Pancake] = Instantiate(foodLooks[(int)Food.FoodType.Pancake]);

                currentFoodRender[(int)Food.FoodType.Pancake].transform.SetParent(gameObject.transform);
                currentFoodRender[(int)Food.FoodType.Pancake].transform.localPosition = new Vector3(0.0f, 1.0f, 4.0f);
            }
            else if (foodArray[(int)Food.FoodType.Dough] == 1 && foodArray[(int)Food.FoodType.Butter] == 1 && foodArray[(int)Food.FoodType.Shrimp] == 1)
            {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);

                foodArray[(int)Food.FoodType.Tempura] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Tempura] = Instantiate(foodLooks[(int)Food.FoodType.Tempura]);

                currentFoodRender[(int)Food.FoodType.Tempura].transform.SetParent(gameObject.transform);
                currentFoodRender[(int)Food.FoodType.Tempura].transform.localPosition = new Vector3(0.0f, 3.0f, 4.0f);
            }
            else
            {
                Array.Clear(foodArray, 0, foodArray.Length);
                foodArray[(int)Food.FoodType.Trash] = 1;
            }

            cookingTimer = 0.0f;
            bakingTimer = 0.0f;
        }

        //----------------------------------------------------------------------------------------------------
        //Baking
        if (isBaking && bakingTimer < BAKE_TIME_LIMIT && !(foodArray == null || foodArray.Length == 0))
        {
            bakingTimer += Time.deltaTime;
        }
        else if (!isCooking && cookingTimer > 0)
        {
            bakingTimer -= Time.deltaTime;
        }

        if (bakingTimer >= BAKE_TIME_LIMIT)
        {
            //Rendering Clear Ingredients
            for (int i = 0; i < currentFoodRender.Length; i++)
            {
                if (currentFoodRender[i] != null)
                {
                    Destroy(currentFoodRender[i]);
                }
            }

            if (foodArray[(int)Food.FoodType.Dough] == 2 && foodArray[(int)Food.FoodType.Butter] == 1)
            {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);

                foodArray[(int)Food.FoodType.Croissant] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Croissant] = Instantiate(foodLooks[(int)Food.FoodType.Croissant]);

                currentFoodRender[(int)Food.FoodType.Croissant].transform.SetParent(gameObject.transform);
                currentFoodRender[(int)Food.FoodType.Croissant].transform.localPosition = new Vector3(0.0f, 1.0f, 4.0f);
            }
            else if (foodArray[(int)Food.FoodType.Dough] == 5)
            {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);

                foodArray[(int)Food.FoodType.Bread] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Bread] = Instantiate(foodLooks[(int)Food.FoodType.Bread]);

                currentFoodRender[(int)Food.FoodType.Bread].transform.SetParent(gameObject.transform);
                currentFoodRender[(int)Food.FoodType.Bread].transform.localPosition = new Vector3(0.0f, 1.0f, 4.0f);
            }
            else if (foodArray[(int)Food.FoodType.Dough] == 2 && foodArray[(int)Food.FoodType.RawMeat] == 1
                && foodArray[(int)Food.FoodType.Cheese] == 1 && foodArray[(int)Food.FoodType.Sauce] == 1)
            {
                //Clear and replace with finished recipe
                Array.Clear(foodArray, 0, foodArray.Length);

                foodArray[(int)Food.FoodType.Pizza] = 1;

                //Spawn Food Render Output
                currentFoodRender[(int)Food.FoodType.Pizza] = Instantiate(foodLooks[(int)Food.FoodType.Pizza]);

                currentFoodRender[(int)Food.FoodType.Pizza].transform.SetParent(gameObject.transform);
                currentFoodRender[(int)Food.FoodType.Pizza].transform.localPosition = new Vector3(0.0f, 1.0f, 4.0f);
            }
            else
            {
                Array.Clear(foodArray, 0, foodArray.Length);
                foodArray[(int)Food.FoodType.Trash] = 1;
            }

            cookingTimer = 0.0f;
            bakingTimer = 0.0f;
        }
    }

    public override void Cooking()
    {
        isCooking = true;
    }

    public override void Baking()
    {
        isBaking = true;
    }

    public override void StopCook()
    {
        isBaking = false;
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
