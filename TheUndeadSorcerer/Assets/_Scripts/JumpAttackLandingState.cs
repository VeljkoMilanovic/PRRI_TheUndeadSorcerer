using UnityEngine;

public class JumpAttackLandingState : State
{
    float timePassed;
    float landingTime;

    public JumpAttackLandingState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        timePassed = 0f;
        character.animator.SetTrigger("jumpAttackLand");
        landingTime = 0.5f;
    }

    public override void LogicUpdate()
    {

        base.LogicUpdate();
        if (timePassed > landingTime)
        {
            character.isSpecialAttack = false;
            character.animator.SetTrigger("move");
            stateMachine.ChangeState(character.combatting);
        }
        timePassed += Time.deltaTime;
    }
}