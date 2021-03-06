﻿//Duckbike
//Tony Le
//4 Oct 2018

using UnityEngine;
using XboxCtrlrInput;
using CircuitKnights.Variables;
using CircuitKnights.Cameras;
using CircuitKnights.Controllers;

namespace CircuitKnights.Objects
{

	[CreateAssetMenu(fileName = "New Player Data", menuName = "Player", order = 51)]
	public class PlayerData : ObjectData
	{
		//[TextArea]
		//[SerializeField]
		//string description =
		//	"Inject into Player.cs. Holds almost all data to do with a player.";

		#region Cache
		//[These could also be arrays ie. be able to change lances and shields]
		public Transform Root { get; set; }
		public PlayerCamera Camera { get; set; }
		public HorseData HorseData { get; set; }
		public LanceData LanceData { get; set; }
		public ShieldData ShieldData { get; set; }

		#endregion
		#region Colliders
		public Collider HeadCollider { get; set; }
		public Collider TorsoCollider { get; set; }
		public Collider RightArmCollider { get; set; }
		public Collider LeftArmCollider { get; set; }
		public Collider ShieldCollider { get; set; }
		public Collider LanceCollider { get; set; }
		//WORK IN PROGRESS!!
		#endregion
		#region Controllers
		public Horse Horse { get; set; }
		public Animator Animator { get; set; }
		public ShieldController ShieldController { get; set; }
		public PlayerIKHoldLance IKLanceHolder { get; set; }
		public PlayerIKHoldShield IKShieldHold { get; set; }
		public PlayerIKLook IKLook { get; set; }
		public ImpactHandler ImpactHandler { get; set; }
		#endregion

		#region Player Numbers
		// [SerializeField] int playerNumber;
		// public int PlayerNumber { get { return playerNumber; }}
		public enum PlayerNumber
		{
			// None, 	//0
			One = 0,    //1
			Two     //2
		}
		[SerializeField] PlayerNumber playerNo;
		public PlayerNumber No { get { return playerNo; } }     //(Number)
		#endregion

		#region Controls
		[Header("Controls")]
		[Tooltip("Lerp")] public float LeanInertia = 0.8f;
		[SerializeField] XboxController controller;
		[SerializeField] XboxAxis lanceAxisX, lanceAxisY;
		[SerializeField] XboxAxis leanLeft, leanRight;
		[SerializeField] XboxAxis shieldAxisX, shieldAxisY;
		[SerializeField] XboxButton thrustLanceButton;

		public XboxController Controller { get { return controller; } }
		public XboxAxis LanceAxisX { get { return lanceAxisX; } }
		public XboxAxis LanceAxisY { get { return lanceAxisY; } }
		public XboxAxis LeanLeft { get { return leanLeft; } }
		public XboxAxis LeanRight { get { return leanRight; } }
		public XboxAxis ShieldAxisX { get { return shieldAxisX; } }
		public XboxAxis ShieldAxisY { get { return shieldAxisY; } }
		// public XboxButton ThrustLanceButton { get { return thrustLanceButton; } }
		#endregion

		#region Stats
		[Header("Health")]
		[SerializeField] float maxHeadHP;
		[SerializeField] float maxTorsoHP;
		[SerializeField] float maxLeftArmHP;
		[SerializeField] float maxRightArmHP;

		//The stats that externals will actually reference from
		//These are reset upon enable
		public float HeadHP { get; set; }
		public float TorsoHP { get; set; }
		public float LeftArmHP { get; set; }
		public float RightArmHP { get; set; }
		public bool isHeadless { get { return HeadHP <= 0; } }
		public bool isDead { get { return TorsoHP <= 0; } }
		public bool isLeftArmDestroyed { get { return LeftArmHP <= 0; } }
		public bool isRightArmDestroyed { get { return RightArmHP <= 0; } }
		#endregion

		#region Methods
		void OnEnable()
		{
			ResetStats();
		}

		public void ResetStats()
		{
			//Use this say at the end of a match or round?
			HeadHP = maxHeadHP;
			TorsoHP = maxTorsoHP;
			LeftArmHP = maxLeftArmHP;
			RightArmHP = maxRightArmHP;
			//ShieldData.ResetHP();
		}

		internal PlayerData GetOpponent()
		{
			switch (playerNo)
			{
				case PlayerNumber.One:
					return GameSettings.Instance.PlayerTwo;
				case PlayerNumber.Two:
					return GameSettings.Instance.PlayerOne;
				default:
					Debug.LogError("Invalid player number");
					return null;
			}
		}
		#endregion
	}
}