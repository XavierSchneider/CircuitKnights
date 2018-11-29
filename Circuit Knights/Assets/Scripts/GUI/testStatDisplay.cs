﻿using UnityEngine;
using UnityEngine.UI;
using CircuitKnights;
using CircuitKnights.Objects;
using System;

namespace CircuitKnights.Tests
{
    public class testStatDisplay : MonoBehaviour 
	{
        public PlayerData playerOne;
        public PlayerData playerTwo;

		[Header("Player 1")]
        public Text headOne;
        public Text torsoOne;
        public Text leftArmOne;
        public Text rightArmOne;
        public Text shieldOne;

        [Header("Player 2")]
        public Text headTwo;
        public Text torsoTwo;
        public Text leftArmTwo;
        public Text rightArmTwo;
		public Text shieldTwo;


		void Start()
		{
            playerOne = GameSettings.Instance.PlayerOne;
            playerTwo = GameSettings.Instance.PlayerTwo;
        }

        void Update()
		{
            headOne.text = "HeadHP: " + Convert.ToInt32(playerOne.HeadHP.ToString());
            torsoOne.text = "TorsoHP: " + Convert.ToInt32(playerOne.TorsoHP.ToString());
            leftArmOne.text = "LeftArmHP: " + Convert.ToInt32(playerOne.LeftArmHP.ToString());
            rightArmOne.text = "RightArmHP: " + Convert.ToInt32(playerOne.RightArmHP.ToString());
            shieldOne.text = "ShieldHP: " + Convert.ToInt32(playerOne.ShieldData.HP.ToString());

            headTwo.text = "HeadHP: " + Convert.ToInt32(playerTwo.HeadHP.ToString());
            torsoTwo.text = "TorsoHP: " + Convert.ToInt32(playerTwo.TorsoHP.ToString());
            leftArmTwo.text = "LeftArmHP: " + Convert.ToInt32(playerTwo.LeftArmHP.ToString());
            rightArmTwo.text = "RightArmHP: " + Convert.ToInt32(playerTwo.RightArmHP.ToString());
            shieldTwo.text = "ShieldHP: " + Convert.ToInt32(playerTwo.ShieldData.HP.ToString());
        }
    }

}