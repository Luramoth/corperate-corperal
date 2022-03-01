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

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D body;

	Vector3 inputVec;

	private int runSpeed = 1;

	// starts before the first frame
	void Start ()
	{
		// set body to the current RigidBody
		body = GetComponent<Rigidbody2D>();
	}

	// starts on every frame
	void Update ()
	{
		//this takes the current movement vectors and puts them in a Vector3, mainly because Unity doesent have a Vector2.Normalise
		inputVec = new Vector3(
				Input.GetAxisRaw("Horizontal"),
				Input.GetAxisRaw("Vertical"),
				0
		);
		// this takes the input and normalises it so the player doesent go faster when moving diagonally
		inputVec = Vector3.Normalize(inputVec);
	}

	// a framerate independent MonoBehavior method
	private void FixedUpdate()
	{
		//this does not work under Update() and i should have figured that out considering this is a physics based function, but regardless, this gets the player moving
		body.velocity = inputVec * runSpeed;
	}
}
