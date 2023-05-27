using UnityEngine;

public class FallingState : State
{
    bool grounded;

    float gravityValue;
    float playerSpeed;

    Vector3 airVelocity;

    public FallingState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        gravityValue = character.gravityValue;
        grounded = false;
        character.animator.SetTrigger("fall");
    }

    public override void LogicUpdate()
    {

        base.LogicUpdate();
        if (character.controller.isGrounded)
        {
            character.animator.SetTrigger("land");
            stateMachine.ChangeState(character.landing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (!grounded)
        {

            velocity = character.playerVelocity;
            airVelocity = new Vector3(input.x, 0, input.y);

            velocity = velocity.x * character.cameraTransform.right.normalized + velocity.z * character.cameraTransform.forward.normalized;
            velocity.y = 0f;
            airVelocity = airVelocity.x * character.cameraTransform.right.normalized + airVelocity.z * character.cameraTransform.forward.normalized;
            airVelocity.y = 0f;
            character.controller.Move(new Vector3(0f, -9.81f, 0f) * 0.25f * Time.deltaTime);
        }
        grounded = character.controller.isGrounded;
    }

}