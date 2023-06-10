using UnityEngine;
public class JumpAttackState : State
{
    bool grounded;

    float gravityValue;
    float jumpHeight;
    float playerSpeed;
    float timePassed;
    float jumpTime;

    Vector3 airVelocity;

    public JumpAttackState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

        timePassed = 0f;
        grounded = false;
        character.isSpecialAttack = true;
        gravityValue = character.gravityValue;
        jumpHeight = character.jumpHeight;
        playerSpeed = character.playerSpeed;
        gravityVelocity.y = 0;
        jumpTime = 0.5f;

        character.animator.SetFloat("speed", 0);
        character.animator.SetTrigger("jumpAttack");
        Jump();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        input = moveAction.ReadValue<Vector2>();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (timePassed > jumpTime)
        {
            character.animator.SetTrigger("jumpAttackFall");
            stateMachine.ChangeState(character.jumpAttackFalling);
        }
        timePassed += Time.deltaTime;
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
            character.controller.Move(gravityVelocity * Time.deltaTime + (airVelocity * character.airControl + velocity * (1 - character.airControl)) * playerSpeed * Time.deltaTime);
        }

        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = character.controller.isGrounded;
    }

    void Jump()
    {
        gravityVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }
}