//  using System.Collections;
//  using System.Collections.Generic;
//  using UnityEngine;
//  using UnityEngine.InputSystem;
//  using UnityEditor;

//  public class StateMachine : MonoBehaviour
//  {   
//      //khai bao bien va du tru gia tri cua bien
//     [Header("Controls")]
//     public float playerSpeed = 5.0f;
//     public float SprintSpeed = 7.0f;
//     public float strafSpeed = 10.0f;
//     public float rollDistance = 0.8f;
//     public float gravityMultiplier = 2;
//     public float rotationSpeed = 5f;
//     public float rollColliderHeight = 0.8f;

//     [Header("Animation Smoothing")]
//     [Range(0,1)]
//     public float SpeedDampTime = 0.1f;
//     [Range(0,1)]
//     public float velocityDampTIme = 0.9f;
//     [Range(0,1)]
//     public float rotationDampTime = 0.2f;
//     [Range(0,1)]
//     public float airControl = 0.5f;

//     public BaseStateMachine MSM;
//     public DodgeState Dodging;
//     public IdleState Standing;
//     public RollState Rolling;
//     public CombatState Combatting;
//     //public LandState Landing;

//     [HideInInspector]
//     public float gravityValue = -9.81f;
//     [HideInInspector]
//     public float normalColliderHeight;
//     [HideInInspector]
//     public CharacterController controller;
//     [HideInInspector]
//     public PlayerInput playerInput;
//     [HideInInspector]
//     public Transform cameraTransform;
//     [HideInInspector]
//     public CameraFollow _cameraController;
//     [HideInInspector]
//     public Animator animator;
//     [HideInInspector]
//     public Vector3 playerVelocity;

//     private void Start() 
//     {    
//          //Gan cac bien voi tinh nang trong unity
//          controller = GetComponent<CharacterController>();
//          animator = GetComponent<Animator>();
//          playerInput = GetComponent<PlayerInput>();
//          cameraTransform = Camera.main.transform;
//         _cameraController = GetComponent<CameraFollow>();

//          MSM = new BaseStateMachine();
//          Standing = new IdleState(this, MSM);
//          Dodging = new DodgeState(this, MSM);
//          Rolling = new RollState(this, MSM);
//          Combatting = new CombatState(this, MSM);
//          //Landing = new LandState(this, MSM);


//          MSM.Initialize(Standing);

//          normalColliderHeight = controller.height;
//          gravityValue *= gravityMultiplier;
//     }
//     private void Update() {
//         MSM.currentState.HandleInput();
//         MSM.currentState.LogicUpdate();
        
//     }
//     private void FixedUpdate() {
//         MSM.currentState.PhysicsUpdate();
//     }
//  }
    
