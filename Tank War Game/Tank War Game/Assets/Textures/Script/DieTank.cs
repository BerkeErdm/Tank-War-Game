using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieTank : MonoBehaviour
{
    void Update()
    {
        DestroyDie();
    }
	
	private void DestroyDie()
	{
		Invoke("Back", 0.3f);
	}
	
	void Back()
	{
		Destroy(gameObject);
	}
}
