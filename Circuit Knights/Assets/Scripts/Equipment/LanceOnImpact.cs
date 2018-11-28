﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircuitKnights.Variables;
using CircuitKnights;
using CircuitKnights.Objects;
using XInputDotNetPure;

//Brent D'Auria
namespace CircuitKnights { 
    public class LanceOnImpact : MonoBehaviour {

        [SerializeField] BoolVariable isVibration;
        private float LeftMotor = .5f;
        private float RightMotor = .5f;
        public GameObject player;
        private float timer = 0.0f;

        private bool timing = false;
        public float VibrateOnCollisionFor = 5.0f;
        public bool VibrateMovementOn;
        public bool VibrateCollisionOn;
       
        public AudioSource _as;
	    public AudioClip[] audioClipArray;

        public CameraShake CameraShake;
        public float ScreenShakeTime = .15f;
        public float ScreenShakeMagnitude = .1f;

        void Awake () {
		_as = GetComponent<AudioSource> ();
	    }

        private void Update()
        {
            
            collisionVibrationOff();
            VibrationOnMovment();

        }


        public void OnTriggerEnter(Collider other)
        {
            if (VibrateCollisionOn == true)
            {
                //checks if the lance is hiting the player 
                if (other.gameObject == player)
                {
                    timing = true;
                    //resets the vibration on enter
                    LeftMotor = 1.0f;
                    RightMotor = 1.0f;
                    //selects what controlers to vibrate
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    Debug.Log("vibrating Collision ON");
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                }
            }
        }
        private void OnTriggerStay(Collider collision)
        {
            if (collision.gameObject == player)
            {

                _as.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
                _as.PlayOneShot(_as.clip);


                    StartCoroutine(CameraShake.Shake(ScreenShakeTime, ScreenShakeMagnitude));
            }
        }

        private void collisionVibrationOff()
        {
            //checks if there was a collision
            if (timing == true)
            {
                timer += Time.deltaTime; //creates a timer that starts counting on the colision
                if (timer > VibrateOnCollisionFor)//turns off the vibration when the timer is greater than the amount you set the VibrateOnCollisionfor
                {
                    // changes the values of the vibratio so it stops vibrating
                    LeftMotor = .0f;
                    RightMotor = .0f;
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    Debug.Log("Vibrating Collision OFF");
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                    timer = 0.0f;
                    timing = false;
                }

            }
        }

   
      
        // this currently vibrates all the time as tony is creating a way to get the players velocit than the vibration will change depending on there velocity
       private void VibrationOnMovment()
       {
           //needs an if statment to check if the player is moving
            if (VibrateMovementOn == true)
            {
                if (timing == false)
                {
                    LeftMotor = .1f;
                    RightMotor = .1f;
                    Debug.Log("Vibrating on Movement");
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.One);
                    VibrateOnCollision(XInputDotNetPure.PlayerIndex.Two);
                    
                }
            }
       }


        //this is to check if the vibrating setting is ticked for any of the code to work
        void VibrateOnCollision(XInputDotNetPure.PlayerIndex playerIndex)
        {
            if (isVibration.Value == true)
            {

                XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
            }
            else
            {
                LeftMotor = 0.0f;
                RightMotor = 0.0f;
                XInputDotNetPure.GamePad.SetVibration(playerIndex, LeftMotor, RightMotor);
            }
        }
    }
  }
