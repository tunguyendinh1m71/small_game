// using UnityEngine;

// public class TargetLockState : State
// {   
//   float gravityValue;
//   bool grounded;
//   bool isTarget;
//   Vector3 currentVelocity;
//   float playerSpeed;
//   Vector3 cVelocity;

//   public TargetLockState(StateMachine _character, BaseStateMachine _stateMachine): base(_character, _stateMachine)
//   {
//     character = _character;
//     stateMachine = _stateMachine;

//   }
//   public override void Enter()
//   {
//     base.Enter();
//     isTarget = true;
    

//     _cameraPlanarDirection = character._cameraController.CameraPlanarDirection;
//     input = Vector2.zero;
//     velocity = character.playerVelocity;
//     currentVelocity = Vector3.zero;
//     gravityVelocity.y = 0;

//     playerSpeed = character.strafSpeed;
//     gravityValue = character.gravityValue;
    
//   }
//     public override void HandleInput()
//     {
//         base.HandleInput();
//         if(targetAction.triggered){
//             character._cameraController.ToggleLock(false);
//             isTarget = false;
//         }

//         input = moveAction.ReadValue<Vector2>();
//         velocity = new Vector3(input.x, 0, input.y).normalized;
//         velocity = (velocity.x * character.cameraTransform.right + velocity.z * character.cameraTransform.forward);
//         velocity.y = 0f;
//     }

//     public override void LogicUpdate()
//     {
//         base.LogicUpdate();

//         character.animator.SetBool("LockOn", true);

//           character.animator.SetFloat("Horizontal", input.x, character.SpeedDampTime, Time.deltaTime);
//           character.animator.SetFloat("Vertical", input.y, character.SpeedDampTime, Time.deltaTime);
//         if(isTarget == false){
//             stateMachine.ChangeState(character.Standing);
//             character.animator.SetBool("LockOn", false);
//         } 
         
//     }
//     public override void PhysicsUpdate()
//     {
//         base.PhysicsUpdate();
//         Vector3 position = character._cameraController.Target.position;
//         Vector3 _toTarget = position - character.transform.position;
//        Vector3 _planarToTarget = Vector3.ProjectOnPlane(_toTarget, Vector3.up);
        
//         gravityVelocity.y += gravityValue * Time.deltaTime;
//         grounded = character.controller.isGrounded;


//         if(grounded && gravityVelocity.y < 0)
//         {
//             gravityVelocity.y = -9.81f;
//         }
        
//         currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity, ref cVelocity, character.velocityDampTIme);
//         character.controller.Move(currentVelocity * Time.deltaTime * playerSpeed + gravityVelocity * Time.deltaTime);

//         if (velocity.sqrMagnitude>0)
//         {
//           character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(_planarToTarget),character.rotationDampTime);

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


