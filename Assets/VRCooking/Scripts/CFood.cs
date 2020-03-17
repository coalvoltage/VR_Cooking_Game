using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFood : MonoBehaviour
{
	public int completed;
    private float waitTime;
    private float timer;
	private Food.FoodType foodT;
	private bool correct;
	public string gameO;
	public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
		correct = false;
		completed = 0;
		waitTime = 40.0f;
		timer = 0.0f;
		foodT = (Food.FoodType)Random.Range(0,8);
		g = GameObject.Find(gameO);
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
        if(timer >= waitTime){
			reset_Food();
			if(completed > 0)
				completed--;
		}
		if(g != null)
			g.GetComponent<ChangeText>().theText = timer.ToString("#.0") +"\n\n" + foodT.ToString();
    }
	void reset_Food()
	{
		foodT = (Food.FoodType)Random.Range(0,8);
		if(waitTime > 10.0f)
			waitTime = waitTime - 2.5f;
		timer = 0;
	}
	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "food")
        {
			if(col.gameObject.GetComponent<Food>().foodName == (int)foodT){
				GameObject.Find(gameO).GetComponent<ChangeText>().theText = timer.ToString("#.00") +"\n\n" + foodT.ToString();
				Destroy(col.gameObject);
				reset_Food();
				completed++;
			}
        }
    }
}
