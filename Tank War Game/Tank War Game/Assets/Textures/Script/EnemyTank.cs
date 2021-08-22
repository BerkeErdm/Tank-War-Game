using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
	int life , maxlife = 3;
	public GameObject[] lifes;
	public GameObject die;
	public Transform target;
	Rigidbody2D weight;
	public float speed , time=3;
	public GameObject enemybullet;
	public AudioClip[] sounds;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("LargeTank").GetComponent<Transform>();
        weight = GetComponent<Rigidbody2D>();
		life = maxlife;
    }

    void Update()
    {
        EnemyMove();
		LifeSystem();
		Dead();
		Shoot();
    }
	
	void EnemyMove()
	{
		transform.position = Vector2.MoveTowards(transform.position, target.position,2*Time.deltaTime);
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
	
	void Dead()
	{
		if(life == 0)
		{
			Die();
			Destroy(gameObject);
		}
	}

	
	private void OnTriggerEnter2D(Collider2D collison)
	{
		if(collison.gameObject.tag == "Bullet")
		{
			life -= 1;
			Destroy(collison.gameObject);
			GetComponent<SpriteRenderer>().color = Color.red;
			Invoke("BackEnemy", 0.3f);
			GetComponent<AudioSource>().PlayOneShot(sounds[0]);
			
		}
	}
	
	void BackEnemy()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	void Die()
	{
		GameObject new_die = Instantiate(die, transform.position, Quaternion.identity);
	}
	
	void Shoot()
	{
		Vector2 direction = target.position - transform.position;
		float angle = Mathf.Atan2(direction.y , direction.x)*Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation,rotation,speed*Time.deltaTime);
		
		if(time>= 3)
		{
			Instantiate(enemybullet, transform.position, Quaternion.identity);
			time = 0;
		}
		else 
		{
			time += Time.deltaTime;
		}
	}
}