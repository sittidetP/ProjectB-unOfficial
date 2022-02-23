using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingItem : MonoBehaviour
{
    [SerializeField] float swingRadius;

    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTimePass = Time.time - startTime;
        float newY = swingRadius * Mathf.Sin(currentTimePass);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
