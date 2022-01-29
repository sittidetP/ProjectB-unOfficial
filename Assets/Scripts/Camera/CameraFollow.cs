using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private BoxCollider2D camBox;
    private GameObject[] boundaries;
    private Bounds[] allBounds;
    private Bounds targetBound;

    public float speed;
    private float waitForSeconds = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        camBox = GetComponent<BoxCollider2D>();
        FindLimits();
    }

    private void LateUpdate()
    {
        if(waitForSeconds > 0)
        {
            waitForSeconds -= Time.deltaTime;
        }
        else
        {
            SetOneLimit();
            FollowPlayer();
        }
    }

    void FindLimits() // find all limits of stage environment. //find all boundaries.
    {
        boundaries = GameObject.FindGameObjectsWithTag("Boundary");
        allBounds = new Bounds[boundaries.Length];

        for(int i = 0; i < allBounds.Length; i++)
        {
            allBounds[i] = boundaries[i].gameObject.GetComponent<BoxCollider2D>().bounds;
        }
    }

    void SetOneLimit() //Set limits on camera based on which boundary the player is located in.
    {
        for (int i = 0; i < allBounds.Length; i++)
        {
            if (player.position.x > allBounds[i].min.x && player.position.x < allBounds[i].max.x
               && player.position.y > allBounds[i].min.y && player.position.y < allBounds[i].max.y)
            {
                targetBound = allBounds[i];
                return;
            }
        }
    }

    void FollowPlayer()
    {
        float xTarget = camBox.size.x < targetBound.size.x ? Mathf.Clamp(player.position.x, targetBound.min.x + camBox.size.x / 2, targetBound.max.x - camBox.size.x / 2) : (targetBound.min.x + targetBound.max.x)/2;
        float yTarget = camBox.size.y < targetBound.size.y ? Mathf.Clamp(player.position.y, targetBound.min.y + camBox.size.y / 2, targetBound.max.y - camBox.size.y / 2) : (targetBound.min.y + targetBound.max.y)/2;
        Vector3 target = new Vector3(xTarget, yTarget, transform.position.z);
        transform.position = target; // normal
        //transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime); // smooth
        
    }
}
