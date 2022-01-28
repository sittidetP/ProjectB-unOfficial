using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    private float deadTime;
    private float alphaSprite;
    private float alphaDe;
    public PlayerDeadState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        alphaSprite = 1f;

        alphaDe = alphaSprite/playerStateData.deadFadeOutTime;
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
                alphaSprite -= (alphaDe * Time.deltaTime * 100);
                Debug.Log(alphaSprite);
                player.SpriteRenderer.color = new Color(1, 1, 1, alphaSprite);
            }
        }
        
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        core.Stats.setAlreadyDead();
        deadTime = Time.time;
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
