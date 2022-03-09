using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    [SerializeField] float swingRadius;

    float startTime;
    float baseY;
    // Start is called before the first frame update
    void Start()
    {
        baseY = transform.position.y;
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTimePass = Time.time - startTime;
        float newY = swingRadius * Mathf.Sin(currentTimePass);

        transform.position = new Vector3(transform.position.x, baseY + newY, transform.position.z);
    }
}
