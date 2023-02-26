// using UnityEngine;

// public class LandState : State
// {
//    float timePassed;
//     float landingTime;
 
//     public LandState(StateMachine _character, BaseStateMachine _stateMachine) : base(_character, _stateMachine)
//     {
//         character = _character;
//         stateMachine = _stateMachine;
//     }
 
//     public override void Enter()
//     {
//         base.Enter();
//         timePassed = 0f;
//         character.animator.SetTrigger("Land");
//         landingTime = 0.5f;
//     }
 
//     public override void LogicUpdate()
//     {
        
//         base.LogicUpdate();
//         if (timePassed> landingTime)
//         {
//             character.animator.SetTrigger("Move");
//             stateMachine.ChangeState(character.Standing);
//         }
//         timePassed += Time.deltaTime;
//     }
// }
