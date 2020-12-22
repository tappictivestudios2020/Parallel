using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 lastPosition;
    private float distanceToMove;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //getting the distance of the distance between player n camera
        distanceToMove = player.transform.position.x - lastPosition.x;
        //moving the camera
        transform.position = new Vector3(transform.position.x + distanceToMove,transform.position.y,transform.position.z);
        //getting player previous position
        lastPosition = player.transform.position;
    }
}
