using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeadState : PlayerState
{
    private float deadTime;
    private float alphaSprite;
    private float alphaDelta;
    int enterState = 0;
    public PlayerDeadState(Player entity, FiniteStateMachine stateMachine, string animBoolName, PlayerStateData playerData) : base(entity, stateMachine, animBoolName, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("dead");
        enterState++;
        if(enterState == 1){
            player.OnPlaySFX?.Invoke(playerStateData.deadSFX);
        }
        //
        GameObject weaponsBase = GameObject.Find("Weapons");
        weaponsBase?.SetActive(false);
        alphaSprite = 1f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        core.Movement.SetVelocityZero();
        /*
        if (core.Stats.getAlreadyDead())
        {            
            if (Time.time > deadTime + playerStateData.deadFadeOutTime)
            {
                //entity.gameObject.SetActive(false);
                ToGameoverScene();
            }
            else
            {
                alphaSprite = alphaDelta * (Time.time - deadTime) + 1;
                //Debug.Log(alphaSprite);
                player.SpriteRenderer.color = new Color(1, 1, 1, alphaSprite);
            }
        }
        */
        
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        core.Stats.setAlreadyDead();
        deadTime = Time.time;
        alphaDelta = (0 - alphaSprite)/((deadTime + playerStateData.deadFadeOutTime) - deadTime);
        player.gameObject.layer = 13; //Layer : PlayerDead 
        player.StartCoroutine(FadeAfterDead());
        player.StartCoroutine(FadeToGameOverScene());
    }

    IEnumerator FadeAfterDead(){
        float fadeWaitTime = playerStateData.deadFadeOutTime/playerStateData.fadeRate;
        for(int i = 0 ; i < playerStateData.fadeRate; ++i){
            alphaSprite = alphaDelta * (Time.time - deadTime) + 1;
            player.SpriteRenderer.color = new Color(1, 1, 1, alphaSprite);
            yield return new WaitForSecondsRealtime(fadeWaitTime);
        }
    }

    IEnumerator FadeToGameOverScene(){
        UIFade.Instance.FadeOut();
        yield return new WaitForSecondsRealtime(UIFade.Instance.FadeTime);
        SceneManager.LoadScene(playerStateData.gameOverScene);
    }
}
