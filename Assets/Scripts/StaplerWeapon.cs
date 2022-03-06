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
*/

public class StaplerWeapon : MonoBehaviour
{
	//Vars
	public int health = 5;

	public int staples = 16;
	public int maxStaples = 16;

	public int holdingStaples = 50;
	public int maxHoldingStaples = 50;

	//Objects
	public GameObject staple;

	private SpriteRenderer SRender;
	private AudioSource audioSource;

	//external objects
	public GameObject UiHandler;

	public AudioClip shootSound;
	public AudioClip reloadSound;
	public AudioClip failSound;

	// reload the stapler
	public void reload()
	{
		int requiredSt;

		// find out how many staples is needed to fully reload
		requiredSt = maxStaples - staples;

		// actual reload sequence
		if (holdingStaples >= requiredSt)
		{
			// given you have enough staples to fill the stapler, fill it up my how much is needed
			staples = maxStaples;

			holdingStaples = holdingStaples - requiredSt;

			audioSource.PlayOneShot(reloadSound);
		}
		else if (holdingStaples == 0)
		{
			// in this instance, you are out of staples and need to gather more
			audioSource.PlayOneShot(failSound);
		}
		else
		{
			// if you dont have enough staples to fill up the whole clip then fill it up with what you got
			staples = staples + holdingStaples;
			holdingStaples = 0;

			audioSource.PlayOneShot(reloadSound);
		}
	}

	// make the staple gun face the cursor
	private void faceMouse()
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

	//starts before the first frame
	public void Start()
	{
		SRender =  GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	public void Update()
	{
		faceMouse();

		//make it so the stapler is always right side up
		if (transform.rotation.z < 0)
		{
			SRender.flipX = true;
		}
		else
		{
			SRender.flipX = false;
		}

		// fire staples
		if (Input.GetButtonDown("Fire1"))
		{
			if (staples > 0)
			{
				// spawn a staple prefab
				Instantiate(staple, transform.position, transform.rotation);
				staples--;
				//shootNoise.Play();
				audioSource.PlayOneShot(shootSound);

				// this tells the UI "hey the player fired the stapler, update the ammo count"
				UiHandler.GetComponent<UserInterface>().UpdateStapleUi();
			}
			else
			{
				audioSource.PlayOneShot(failSound);
			}
		}

		// reload staples
		if (Input.GetButtonDown("Reload"))
		{
			reload();

			// tell the UI "hey idiot, the player reloaded, update the ammo count"
			UiHandler.GetComponent<UserInterface>().UpdateStapleUi();

			// like this
		}
	}
}
