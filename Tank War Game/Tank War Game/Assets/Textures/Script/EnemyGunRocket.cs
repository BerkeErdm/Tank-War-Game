using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunRocket : MonoBehaviour
{
	Transform largetank;
	Vector2 target;
	public float speed = 3;

    void Start()
    {
        largetank = GameObject.FindGameObjectWithTag("LargeTank").GetComponent<Transform>();
		target = new Vector2(largetank.position.x , largetank.position.y + -0.2f);
		Destroy(gameObject,5f);
    }
	
		private void OnTriggerEnter2D(Collider2D collision)
	{
			Destroy(gameObject);
	}

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,speed * Time.deltaTime);
    }
}
