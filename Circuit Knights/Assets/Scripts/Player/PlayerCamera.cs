﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircuitKnights
{
    public class PlayerCamera : MonoBehaviour
    {
        [Header("Camera Sway")]
        public float swaySpeed;
        public float swayAmount;

        [Header("Movement")]
        public float moveSpeed;
        public GameObject moveObject;
        public GameObject moveFollowObject;

        [Header("Rotation")]
        public float rotationSpeed;
        public GameObject rotateObject;
        public GameObject rotateFollowObject;

        private void Start()
        {
            moveObject = moveFollowObject;
            rotateObject = rotateFollowObject;
        }
        
        private void Update()
        {
            Vector3 position = transform.position;
            position.x = Mathf.Lerp(transform.position.x, moveObject.transform.position.x, moveSpeed * Time.deltaTime);
            position.y = Mathf.Lerp(transform.position.y, moveObject.transform.position.y, moveSpeed * Time.deltaTime);
            position.z = Mathf.Lerp(transform.position.z, moveObject.transform.position.z, moveSpeed * Time.deltaTime);
            transform.position = position;

            float swayX = (Mathf.PerlinNoise(0, Time.time * swaySpeed) - 0.5f) * swayAmount;
            float swayY = (Mathf.PerlinNoise(0, Time.time * swaySpeed) - 0.5f) * swayAmount;

            Vector3 newLookAt = rotateObject.transform.position;
            newLookAt.x += swayX;
            newLookAt.x += swayY;
            Quaternion desiredRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(newLookAt - transform.position), rotationSpeed * Time.deltaTime);
            transform.rotation = desiredRotation;
        }


    }
}