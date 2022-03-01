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

public class StaplerWeapon : MonoBehaviour
{


	public GameObject staple;

	// make the staple gun face the cursor
	void faceMouse()
	{
		// grab the current mouse position reletive to the top left of the screen
		Vector3 mousePos = Input.mousePosition;
		Vector2 direction;

		// convert the mouse position to world space
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);

		// do some math to turn the mouse position into a rotation of the staple gun
		direction = new Vector2(
				mousePos.x - transform.position.x,
				mousePos.y - transform.position.y
		);

		// rotate the staple gun
		transform.up = direction;
	}

	// Update is called once per frame
	void Update()
	{
		faceMouse();

		if (Input.GetButtonDown("Fire1"))
		{
			// spawn a staple prefab
			Instantiate(staple, transform.position, transform.rotation);
		}
	}
}
