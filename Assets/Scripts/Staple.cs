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

	private float stapleSpeed = 1f;

	public GameObject stapler;

	// Update is called once per frame
	void Update()
	{
		// moves the staple at a constant speed
		transform.Translate(Vector3.up * Time.deltaTime * stapleSpeed);
	}

	// Runs code once object is off screen
	void OnBecameInvisible()
	{
		DestroyObject(gameObject);
	}
}
