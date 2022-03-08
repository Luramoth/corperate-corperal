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

public class StapleBundle : MonoBehaviour
{
	//vars
	public int ammoAmount = 16;

	//objects
	public GameObject stapler;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		// check if the player is collecting the pack of staples or not
		if (collider.tag == "Player")
		{
			// run the fuinction in order to actually collect the staples on the players end and see if there are any extras
			int extraSt = stapler.GetComponent<StaplerWeapon>().collectStaples(ammoAmount);

			// if there are extras then keep the staple pack but lower the amount it has, else if there are no extras, then delete the ammo pack
			if (extraSt > 0 )
			{
				ammoAmount = extraSt;
			}
			else
			{
				Object.Destroy(gameObject);
			}
		}
	}
}
