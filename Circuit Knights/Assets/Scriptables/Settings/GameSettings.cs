﻿//Duckbike
//Tony Le
//26 Oct 2018

using System;
using System.Linq;
using CircuitKnights.Objects;
using CircuitKnights.Variables;
using UnityEngine;

namespace CircuitKnights
{
    [CreateAssetMenu(fileName = "New Game Settings", menuName = "Game Settings", order = 32)]
    public class GameSettings : MonoBehaviour
    {
        //[Multiline] [SerializeField] string description = "Holds the game settings";

        #region Singleton
        private static GameSettings _instance;
        public static GameSettings Instance
        {
            get {
                return _instance;
            }
        }

        public static void InitializeFromDefault(GameSettings settings)
        {
            if (_instance) DestroyImmediate(_instance);
            _instance = Instantiate(settings);
            _instance.hideFlags = HideFlags.HideAndDontSave;
        }
        #endregion

        #region Players
        public PlayerData PlayerOne;
        public PlayerData PlayerTwo;

        // public PlayerData[] Players { get; set; }
        #endregion

        #region Game Settings
        [Range(1, 10)] [SerializeField] int noOfRounds;
        public int Round { get; set; }
        public int NoOfRounds { get { return noOfRounds; } }
        public bool isMatchOver { get; private set; }

		[Header("Horse Arrival")]
		public float ArrivalDistance = 75f;
		public float ArrivalThreshold = 0.3f;
		public float ArrivalBrakingFineTuneFactor = 1.25f;

        [SerializeField] BoolVariable gamepadVibrationOn;
        public BoolVariable isVibrationOn { get { return gamepadVibrationOn; } }
		#endregion

		////DIRTY
		internal void SetMatchOver(bool isMatchOver)
		{
			this.isMatchOver = isMatchOver;
		}

		////DIRTY
		internal bool isDraw()
		{
			if (PlayerOne.isDead && PlayerTwo.isDead)
			{
				return true;
			}
			return false;
		}

		void Awake()
		{
            _instance = this;
            Reset();
		}

		public void Reset()
		{
            ////Reset everything back to zero
            //Game
			isMatchOver = false;
			Round = 0;

            //Players and Shields
            PlayerOne.ResetStats();
            PlayerTwo.ResetStats();
            PlayerOne.ShieldData.ResetHP();
            PlayerTwo.ShieldData.ResetHP();
		}

		public void BeginNewRound()
		{
			Round++;
		}
	}
}