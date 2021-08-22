using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
	public GameObject[] lifes;
	public Text lifescore;
	public Text score;
	public float speed , shootspeed;
	public int fuel , life;
	int maxlife = 3;
	public GameObject bullet;
	public AudioClip[] sounds;
	
    void Start()
    {
        life = maxlife;
    }

    void Update()
    { 
		//Shoot();
		TankMove();
		FuelScore();	
		LifeScore();
		Dead();
		LifeSystem();
    }
	
	void TankMove()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.localRotation = Quaternion.Euler(0, 0, 90);			
			transform.localScale = new Vector2(1,1);	
			transform.Translate(0f, speed * Time.deltaTime, 0f);
		
			if(Input.GetKeyDown(KeyCode.R))
			{
				GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
				new_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootspeed*Time.deltaTime,0);
				new_bullet.transform.localRotation = Quaternion.Euler(0, 0, 90);
				new_bullet.transform.localScale = new Vector2(1,1);
			}
		}
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(0f  , speed * Time.deltaTime, 0f);
			transform.localScale = new Vector2(1,1);
			transform.localRotation = Quaternion.Euler(0,0,0);
			
			if(Input.GetKeyDown(KeyCode.R))
			{
				GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
				new_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,shootspeed*Time.deltaTime);
			}
		}
		
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0f, -speed * Time.deltaTime, 0f);
			transform.localScale = new Vector2(-1,-1);
			transform.localRotation = Quaternion.Euler(0,0,0);
			
			if(Input.GetKeyDown(KeyCode.R))
			{
				GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
				new_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,-shootspeed*Time.deltaTime);
				new_bullet.transform.localScale = new Vector2(-1,-1);
			}
		}
		
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.localRotation = Quaternion.Euler(0, 0, -90);
			transform.localScale = new Vector2(1,1);
			transform.Translate(0f, speed * Time.deltaTime , 0f);
			
			if(Input.GetKeyDown(KeyCode.R))
			{
				GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
				new_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootspeed*Time.deltaTime,0);
				new_bullet.transform.localRotation = Quaternion.Euler(0, 0,-90);
				new_bullet.transform.localScale = new Vector2(1,1);
			}
		}	
	}
	
	/*void Shoot()
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
		GameObject new_bullet = Instantiate(bullet, transform.position, Quaternion.identity);
		new_bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0,shootspeed*Time.deltaTime);
		}
	}*/
	
	void LifeScore()
	{
		lifescore.text = "" + life;
	}
	
	void FuelScore()
	{
		score.text = "" + fuel;
		if(fuel == 5)
		{
			score.text = "WIN";
		}
		
	}
	
	void Dead()
	{
		if(life == 0)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	void LifeSystem()
	{
		for(int i=0 ; i<maxlife;i++)
		{
			lifes[i].SetActive(false);
		}
		
		for(int i=0 ; i<life;i++)
		{
			lifes[i].SetActive(true);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D objefuel)
	{
		if(objefuel.gameObject.tag == "Fuel")
		{
			fuel++;
			Destroy(objefuel.gameObject);
			GetComponent<AudioSource>().PlayOneShot(sounds[0]);
		}
		
		if(objefuel.gameObject.tag == "Fuel-2")
		{
			fuel++;
			Destroy(objefuel.gameObject);
			GetComponent<AudioSource>().PlayOneShot(sounds[0]);		
		}
		
		if(objefuel.gameObject.tag == "Fuel-3")
		{
			fuel++;
			Destroy(objefuel.gameObject);
			GetComponent<AudioSource>().PlayOneShot(sounds[0]);			
		}
		
		if(objefuel.gameObject.tag == "Fuel-4")
		{
			fuel++;
			Destroy(objefuel.gameObject);
			GetComponent<AudioSource>().PlayOneShot(sounds[0]);			
		}
		
		if(objefuel.gameObject.tag == "Fuel-5")
		{
			fuel++;
			Destroy(objefuel.gameObject);
			GetComponent<AudioSource>().PlayOneShot(sounds[0]);			
		}
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Stone")
		{
			life -=1;
		}
		
		if(collision.gameObject.tag == "Gun_2")
		{
			life -=1;
		}
	}
	
	
}