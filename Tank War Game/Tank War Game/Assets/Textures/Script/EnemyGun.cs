using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
	public float speed , time=3;
	public GameObject enemybullet;	
	int life , maxlife = 3 ;
	public GameObject die;
	public Transform target;
	Rigidbody2D weight;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("LargeTank").GetComponent<Transform>();
		weight = GetComponent<Rigidbody2D>();
		life = maxlife;
    }

    void Update()
    {		
		Shoot();
		Dead();
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
}
