﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class PlayerMovement : MonoBehaviour
    {
        public Material[] Materials;
        public Transform Target;
        public Animator CharacterAnimator;
        public float Speed;
        PlayerMouseController _controller;
        void Start()
        {
            _controller = GetComponent<PlayerMouseController>();
        }

        void Update()
        {

            if (_controller.enabled)
            {
                return;
            }

            foreach (var item in Materials)
            {
                item.SetVector("_CharacterPosition", transform.position);
            }

            var distance = Vector3.Distance(transform.position, Target.position);
            if (distance > 0.1f)
            {
                transform.LookAt(Target.position);
                transform.Translate(Vector3.forward * Speed);
                CharacterAnimator.SetBool("IsWalking", true);
            }
            else
            {
                CharacterAnimator.SetBool("IsWalking", false);
            }
        }
    }
