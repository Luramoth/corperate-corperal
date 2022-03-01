using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaplerWeapon : MonoBehaviour
{

	void faceMouse()
	{
		Vector3 mousePos = Input.mousePosition;
		Vector2 direction;

		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		direction = new Vector2(
				mousePos.x - transform.position.x,
				mousePos.y - transform.position.y
		);

		transform.up = direction;
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		faceMouse();

		if (Input.GetButtonDown("Fire1"))
		{
			print("test");
		}
	}
}
