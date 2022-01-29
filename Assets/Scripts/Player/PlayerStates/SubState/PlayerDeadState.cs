using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    private float deadTime;
    private float alphaSprite;
    private float alphaDelta;
    public PlayerDeadState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        alphaSprite = 1f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (core.Stats.getAlreadyDead())
        {            
            if (Time.time > deadTime + playerStateData.deadFadeOutTime)
            {
                entity.gameObject.SetActive(false);
            }
            else
            {
                alphaSprite = alphaDelta * (Time.time - deadTime) + 1;
                //Debug.Log(alphaSprite);
                player.SpriteRenderer.color = new Color(1, 1, 1, alphaSprite);
            }
        }
        
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        core.Stats.setAlreadyDead();
        deadTime = Time.time;
        alphaDelta = (0 - alphaSprite)/((deadTime + playerStateData.deadFadeOutTime) - deadTime);
        //player.StartCoroutine(FadeAfterDead());
    }

    private IEnumerator FadeAfterDead()
    {
        for (float i = deadTime; i < deadTime + playerStateData.deadFadeOutTime; i += Time.deltaTime)
        {
            alphaSprite -= (alphaSprite * playerStateData.alphaMultiple);
            yield return new WaitForSeconds(0.05f);
            player.SpriteRenderer.color = new Color(1, 1, 1, alphaSprite);
        }
    }
}
