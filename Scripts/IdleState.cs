// using UnityEngine;

// public class IdleState : State
// {   
//   float gravityValue;
//   bool roll;
//   bool grounded;
//   //bool isTarget;
//   Vector3 currentVelocity;
//   bool dodge;
//   float playerSpeed;
//   Vector3 cVelocity;
//   bool drawWeapon;

//   public IdleState(StateMachine _character, BaseStateMachine _stateMachine): base(_character, _stateMachine)
//   {
//     character = _character;
//     stateMachine = _stateMachine;
//   }
//   public override void Enter()
//   {
//     base.Enter();
//     drawWeapon = false;
//     roll = false;
//     dodge = false;
//     input = Vector2.zero;
//     velocity = character.playerVelocity;
//     currentVelocity = Vector3.zero;
//     gravityVelocity.y = 0;


//     playerSpeed = character.playerSpeed;
//     gravityValue = character.gravityValue;
    
//   }
//     public override void HandleInput()
//     {
//         base.HandleInput();
//         if(rollAction.triggered && input == Vector2.zero){
//              dodge = true;
//         }

//         if(rollAction.triggered && input != Vector2.zero){
//             roll = true;
//         }
//         if(drawAction.triggered){
//             drawWeapon = true;
//         }

//         input = moveAction.ReadValue<Vector2>();
//         velocity = new Vector3(input.x, 0, input.y);
//         velocity = velocity.x * character.cameraTransform.right.normalized + velocity.z * character.cameraTransform.forward.normalized;
//         velocity.y = 0f;
//     }

//     public override void LogicUpdate()
//     {
//         base.LogicUpdate();

//         character.animator.SetFloat("Movement", input.magnitude, character.SpeedDampTime, Time.deltaTime);
//         if(dodge){
//              stateMachine.ChangeState(character.Dodging);
//         }
//         if(roll){
//             stateMachine.ChangeState(character.Rolling);
//         }
//         if(drawWeapon){
//             stateMachine.ChangeState(character.Combatting);
//             character.animator.SetTrigger("weaponDraw 0");
//         }
         
//     }
//     public override void PhysicsUpdate()
//     {
//         base.PhysicsUpdate();
        
//         gravityVelocity.y += gravityValue * Time.deltaTime;
//         grounded = character.controller.isGrounded;


//         if(grounded && gravityVelocity.y < 0)
//         {
//             gravityVelocity.y = 0f;
//         }
        
//         currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, character.velocityDampTIme);
//         character.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);

//         if (velocity.sqrMagnitude>0)
//         {
//           character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity),character.rotationDampTime);

//         }
//     }
//     public override void Exit()
//     {
//         base.Exit();
//         gravityVelocity.y = 0f;

//         character.playerVelocity = new Vector3(input.x, 0, input.y);
//         if(velocity.sqrMagnitude>0)
//         {
//           character.transform.rotation = Quaternion.LookRotation(velocity);
//         }
//     }
// }


