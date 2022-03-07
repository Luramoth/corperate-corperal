using UnityEngine;
using UnityEngine.UI;

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
TO/DO: optomise the script so it doesent need to reference  the Ammo count all the time slowing the game down - mabey not because it was the prints causing performance issues
TO/DO: probably pick a better font
TODO: Add a health system - done? yet to be tested
TODO: fix bug where staple count isent updated
*/

public class UserInterface : MonoBehaviour
{
	// objects
	public GameObject stapler;
	public GameObject player;


	// Ui elements
	public Text stapleCountT;
	public Image healthMeter;

	// health level graphics
	public Sprite health4;
	public Sprite health3;
	public Sprite health2;
	public Sprite health1;
	public Sprite health0;


	// Start is called before the first frame update
	private void Start()
	{
		// this is the most retarded thing ive ever programmed but it works so im not gonna change it, if i could reference it with a variable i would
		// basicly what it does is take the current staple count and how much the player currently has and updates the UI text to make sure the player knows this information
		stapleCountT.text = "Staples: " + stapler.GetComponent<StaplerWeapon>().staples + "/" + stapler.GetComponent<StaplerWeapon>().holdingStaples;
	}

	// called once ammo is used and the UI needs to change
	public void UpdateStapleUi()
	{
		stapleCountT.text = "Staples: " + stapler.GetComponent<StaplerWeapon>().staples + "/" + stapler.GetComponent<StaplerWeapon>().holdingStaples;

		// change health meter depending on how much health the player has
		switch (player.GetComponent<PlayerMovement>().health)
		{
			case 4:
				healthMeter.GetComponent<Image>().sprite = health4;
				break;
			case 3:
				healthMeter.GetComponent<Image>().sprite = health3;
				break;
			case 2:
				healthMeter.GetComponent<Image>().sprite = health2;
				break;
			case 1:
				healthMeter.GetComponent<Image>().sprite = health1;
				break;
			case 0:
				healthMeter.GetComponent<Image>().sprite = health0;
				break;
		}
	}
}
