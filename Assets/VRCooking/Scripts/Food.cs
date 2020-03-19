using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
	public enum FoodType {
		Nothing,
		Trash,
        //Ingredients
		Water,
		Tomato,
		RawMeat,
        Shrimp,
        Sauce,
        Butter,
        Dough,
        Cheese,
        //finished foods
		TomatoSoup,
		Broth,
		Bread,
        Croissant,
        Pizza,
        Tempura,
        Steak,
        Pancake
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
