using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Drone
{ 
    
    [RequireComponent(typeof(Rigidbody))]
    public class BaseRigidBody : MonoBehaviour
    {
        #region Variables
        [Header("Rigidbody Properties")]
        [SerializeField] private float weightInKg = 1f;

        protected Rigidbody rb;
        protected float startDrag;
        protected float startAngularDrag;
        #endregion

        #region Main methods
        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            if(rb)
            {
                rb.mass = weightInKg;
                startDrag = rb.drag;
                startAngularDrag = rb.angularDrag;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if(!rb)
            {
                return;
            }

            HandlePhysics();
        
        }


        #endregion

        #region Custom Methods
        protected virtual void HandlePhysics(){}
        #endregion
    }
}