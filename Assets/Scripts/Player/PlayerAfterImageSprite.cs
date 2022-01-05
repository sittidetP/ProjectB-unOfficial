using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
    [SerializeField] float activeTime = 0.1f;
    [SerializeField] float alphaSet = 0.8f;
    [SerializeField] float alphaDecay = 10f;

    float timeActived;
    float alpha;

    Transform player;

    SpriteRenderer SR;
    SpriteRenderer playerSR;

    Color color;
    // Start is called before the first frame update
    void OnEnable()
    {
        SR = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerSR = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        SR.sprite = playerSR.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActived = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        alpha -= alphaDecay * Time.deltaTime;
        color = new Color(SR.color.r, SR.color.g, SR.color.b, alpha);
        SR.color = color;

        if(Time.time >= timeActived + activeTime)
        {
            PlayerAfterImagePool.Instance.AddToPool(gameObject);
        }
    }
}
