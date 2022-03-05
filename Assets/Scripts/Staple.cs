using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Corperate Corperal, A top down 2D shooter game
    Copyright (C) 2022  Luramoth

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.*/

public class Staple : MonoBehaviour
{
	// vars
	int maxVelocity = 10;

	// objects
	public GameObject stapler;
	Rigidbody2D body;

	public GameObject hitParticle;

	private void Start()
	{
		//this grabs the staple's rigidbody
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		// this makes the staple constantly move forward
		body.AddForce(transform.up,ForceMode2D.Force);

		// this will limit its speed
		body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
	}

	// Runs code once object is off screen in order to destroy it as to not cause lag
	private void OnBecameInvisible()
	{
		Object.Destroy(gameObject);
	}

	//Detect collisions between the GameObjects with Colliders attached, for some reason its different from OnCollisionEnter() that is named in a way that implies its universal or normal and is also not mentioned
	// "hey btw this is for 3d collisions, for 2D go to ..." all engines are retards
	private void OnCollisionEnter2D(Collision2D collision)
	{
		print("colision");
		//Check for a match with the specific tag on any GameObject that collides with your GameObject
		if (collision.gameObject.tag == "Object")
		{
			//If the GameObject has the same tag as specified, output this message in the console
			print("object hit");
		}
	}
}
