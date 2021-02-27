using UnityEngine;

public class TL_MovingPlatform : MonoBehaviour
{
    public GameObject Player;
    public int WaypointIndex;
    public float PlatformSpeed;
    public Vector3[] Waypoints;
    public Vector3 PlatformDirection;
    private Rigidbody PlayerRigidbody;
    private Rigidbody PlatformRigidbody;


    void Start()
    {
        PlatformRigidbody = GetComponent<Rigidbody>();
    }

    //Make the platform follow a waypoint
    void FollowWaypoint()
    {
        //Calculate the direction of the next waypoint
        PlatformDirection = Waypoints[WaypointIndex] - transform.position;

        //If the platform is close enough to its' destination
        if (Vector3.Distance(transform.position, Waypoints[WaypointIndex]) < 1f)
        {
            //Increase the index
            WaypointIndex++;  
            
            //If the index of the waypoint is more than the maximum length of the array
            if (WaypointIndex > Waypoints.Length - 1)
            {
                //Reset the index
                WaypointIndex = 0;
            }
        }        
    }

    //Move and rotate the platform
    void MovePlatform()
    {
        PlatformRigidbody.MoveRotation(Quaternion.LookRotation(PlatformDirection));
        PlatformRigidbody.MovePosition(transform.position + (transform.forward * PlatformSpeed * Time.fixedDeltaTime));
    }

    void Update()
    {
        FollowWaypoint();
    }

    void FixedUpdate()
    {
        MovePlatform();
    }

    void OnCollisionStay(Collision collision)
    {
        //If the collided gameobject is a player
        if (collision.transform.CompareTag("Player"))
        {
            //Obtain the rigidbody from the player
            PlayerRigidbody = collision.transform.GetComponent<Rigidbody>();

            //Set the player's velocity to match the platform
            PlayerRigidbody.velocity = new Vector3(PlatformRigidbody.velocity.x, PlayerRigidbody.velocity.y, PlatformRigidbody.velocity.z);
        }
    }

}