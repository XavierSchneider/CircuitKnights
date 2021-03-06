﻿//Duckbike
//Tony Le
//26 Oct 2018

using UnityEngine;
using XboxCtrlrInput;

namespace CircuitKnights.Objects
{

    [CreateAssetMenu(fileName = "New Horse Data", menuName = "Horse", order = 52)]
    public class HorseData : ObjectData
    {
        //[TextArea] [SerializeField] string description =
        //    "The player's horse";

		#region Physics
		public float Mass = 500f;  //Lazy property
        public float StartingForce = 5000f;
        public float ForceIncreasePerPass = 500f;
		#endregion

		// #region Controls
		// [Header("Controls")]
        // [SerializeField] XboxAxis accelAxis;
        // [SerializeField] XboxButton decelButton;

        // public XboxAxis AccelAxis { get { return accelAxis; } }
        // public XboxButton DecelButton { get { return decelButton; } }
        // #endregion
        // #region Movement
        // [Header("Movement")]
        // [Range(1f, 100f)] public float speed;
        // [Range(0f, 10f)] public float lerpSmoothness = 1.02f;

        // public float Speed { get { return speed; } }
        // public float tValue { get { return lerpSmoothness; } }
        // #endregion
    }

}