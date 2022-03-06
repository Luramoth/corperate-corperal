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

/*
TO/DO spawn particles on collision
TO/DO make sound on collision
*/

public class Staple : MonoBehaviour
{
	// vars
	int maxVelocity = 10;

	// objects
	public GameObject stapler;
	private Rigidbody2D body;

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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Instantiate(hitParticle, transform.position, transform.rotation);
	}
}
