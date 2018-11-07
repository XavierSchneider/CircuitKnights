﻿//DuckBike
//Tony Le
//8 Nov 2018

using UnityEngine;
using CircuitKnights.Objects;

namespace CircuitKnights
{
    public class SetGameSettings : MonoBehaviour
    {
		[SerializeField] Player playerOne;
		[SerializeField] Player playerTwo;

		void Awake()
		{
			GameSettings.Instance.PlayerOne = playerOne;
			GameSettings.Instance.PlayerTwo = playerTwo;
		}
    }
}