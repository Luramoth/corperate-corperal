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
TO/DO: add crouching function so player can hide behind cover
*/

public class PlayerMovement : MonoBehaviour
{

	// vars
	private Vector3 inputVec;

	public int health = 4;
	public int runSpeed = 10;

	private float maxVelocity = 1.5f;

	public bool isCrouching = false;

	//objects
	private Rigidbody2D body;
	private SpriteRenderer spriteRenderer;

	public Sprite standSp;
	public Sprite crouchSp;

	// starts before the first frame
	private void Start ()
	{
		// set body to the current RigidBody
		body = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// starts on every frame
	private void Update ()
	{
		//this takes the current movement vectors and puts them in a Vector3, mainly because Unity doesent have a Vector2.Normalise
		inputVec = new Vector3(
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical"),
				0
		);
		// this takes the input and normalises it so the player doesent go faster when moving diagonally
		inputVec = Vector3.Normalize(inputVec);

		// change the player's crouching state depending on weatehr or not they are pressing the ctrl button
		// in the crouching state the player will have different collisions and it will mainly affect bullets. making thim able to hit obsticals
		if (Input.GetButton("crouch"))
		{
			spriteRenderer.sprite = crouchSp;

			gameObject.layer = 8;

			isCrouching = true;
		}
		else
		{
			spriteRenderer.sprite = standSp;

			gameObject.layer = 0;

			isCrouching = false;
		}
	}

	// a framerate independent MonoBehavior method
	private void FixedUpdate()
	{
		//this does not work under Update() and i should have figured that out considering this is a physics based function, but regardless, this gets the player moving
		body.AddForce(inputVec * runSpeed);

		body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
	}
}
