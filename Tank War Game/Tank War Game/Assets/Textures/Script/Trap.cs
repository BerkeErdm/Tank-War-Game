using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{	
	int traplife = 4 ;
	
    void Start()
    {
    }

    void Update()
    {
		DeadTrap();
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Bullet")
		{
			traplife -= 1;  
			Destroy(collision.gameObject);	
			GetComponent<SpriteRenderer>().color = Color.red;
			Invoke("BackTrap", 0.1f);
		}
	}
	
	void DeadTrap()
	{
		if(traplife == 0)
		{
		Destroy(gameObject);	
		}
	}
	
	void BackTrap()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}