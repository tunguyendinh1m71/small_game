//  using UnityEngine;
//  using UnityEngine.InputSystem;

//  public class State
//  {
//     public StateMachine character;
//     public BaseStateMachine stateMachine;

//     protected Vector3 gravityVelocity;
//     protected Vector3 velocity;
//     protected Vector2 input;
//     protected Vector3 _cameraPlanarDirection;
//     protected Quaternion _cameraPlanarRotation;
//     public InputAction moveAction;
//     public InputAction targetAction;
//     public InputAction sprintAction;
//     public InputAction rollAction;
//     public InputAction drawAction;
//     public InputAction attackAction;

//     public State(StateMachine _character, BaseStateMachine _stateMachine)
//     {
//          character = _character;
//          stateMachine = _stateMachine;

//          moveAction = character.playerInput.actions["Move"];
//          sprintAction = character.playerInput.actions["Sprint"];
//          rollAction = character.playerInput.actions["Roll"];
//          drawAction = character.playerInput.actions["DrawWeapon"];
//          attackAction = character.playerInput.actions["Attack"];



//     }
//     public virtual void Enter()
//     {
//          //Debug.Log("enter state: "+this.ToString());
//     }
//     public virtual void HandleInput()
//     {
//     }
//     public virtual void LogicUpdate()
//     {
//     }
//     public virtual void PhysicsUpdate()
//     {
//     }
//     public virtual void Exit()
//     {
//     }
//  }
