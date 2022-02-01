using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int startPoint;
    [SerializeField] float stopMoveDuration;
    [SerializeField] Transform[] points;

    private int index;
    private float stopTime;
    private bool isMoving;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startPoint].transform.position;
        index = startPoint++;
        isMoving = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (Vector2.Distance(transform.position, points[index].transform.position) < 0.01f)
            {
                index++;
                if (index == points.Length)
                {
                    index = 0;
                }
                stopTime = Time.time;
                isMoving = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, points[index].transform.position, speed * Time.deltaTime);
            }
        }
        else
        {
            if (Time.time > stopMoveDuration + stopTime)
            {
                isMoving = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.y < other.transform.position.y - 1f)
            {
                player = other.gameObject.GetComponent<Player>();
                player.Core.Movement.RB.interpolation = RigidbodyInterpolation2D.None;
                other.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (player != null)
            {
                player.Core.Movement.RB.interpolation = RigidbodyInterpolation2D.Interpolate;
                other.transform.SetParent(null);
                player = null;
            }
        }
    }
}
