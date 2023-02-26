// using UnityEngine;

// public class RollState : State
// {
//     float timePassed;
//     float rollTime;
//     bool grounded;
//     float gravityValue;

    
 
//     public RollState(StateMachine _character, BaseStateMachine _stateMachine) : base(_character, _stateMachine)
//     {
//         character = _character;
//         stateMachine = _stateMachine;
//     }
//     public override void Enter()
//     {
//         base.Enter();
//         character.animator.applyRootMotion = true;
//         timePassed = 0f;
//         grounded = character.controller.isGrounded;
 
//         rollTime = 1f;
//         gravityVelocity.y = 0f;
//     }
//     public override void HandleInput()
//     {
//         base.HandleInput();
//     }
//      public override void LogicUpdate()
//     {
        
//         base.LogicUpdate();
//         character.animator.SetBool("Roll", true);
        
        
//         if (timePassed> rollTime && grounded)
//         {
//             stateMachine.ChangeState(character.Standing);
//             character.animator.SetBool("Roll", false);
//         }
//         timePassed += Time.deltaTime;
//     }
//     public override void PhysicsUpdate()
//     {
//         base.PhysicsUpdate();
//         gravityVelocity.y += gravityValue * Time.deltaTime;
//         grounded = character.controller.isGrounded;

//         if(grounded && gravityVelocity.y < 0)
//         {
//             gravityVelocity.y = -9.81f;
//             Debug.Log("ground");
//         }

//         if (velocity.sqrMagnitude>0)
//         {
//           character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity),character.rotationDampTime);

//         }
        
//     }
//     public override void Exit()
//     {
//         base.Exit();
//         character.animator.applyRootMotion = false;
//         if(velocity.sqrMagnitude>0)
//         {
//           character.transform.rotation = Quaternion.LookRotation(velocity);
//         }
        
//     }
// }
