using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : Food
{
    public bool isFull = false;
    public GameObject[] foodLooks = new GameObject[Enum.GetNames(typeof(Food.FoodType)).Length];

    public GameObject currentRender;
    // Start is called before the first frame update
    void Start()
    {
        foodName = (int)FoodType.Nothing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "cooking" && !isFull)
        {
            CookingMethod tempCook = other.gameObject.GetComponent(typeof(CookingMethod)) as CookingMethod;
            foodName = tempCook.GetResetFood();

            currentRender = Instantiate(foodLooks[foodName]);
            currentRender.transform.SetParent(gameObject.transform);
            if(foodName == 10 || foodName == 11 || foodName == 6)
            {
                currentRender.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                currentRender.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            currentRender.transform.localPosition = new Vector3(0.0f, 0.1f, 0.0f);
            //Destroy(other.gameObject);

            isFull = true; 
        }
        else if (other.gameObject.tag == "cooking" && isFull)
        {
            CookingMethod tempCook = other.gameObject.GetComponent(typeof(CookingMethod)) as CookingMethod;
            tempCook.GiveFood(foodName);
            foodName = (int)FoodType.Nothing;

            Destroy(currentRender);

            isFull = false;
        }
    }

}
