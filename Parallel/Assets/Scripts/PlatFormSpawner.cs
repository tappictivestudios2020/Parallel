using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormSpawner : MonoBehaviour
{
    public GameObject platForm;
    public Transform generatingPoint;
    public float platformDistance;

    private float platformWidth, distanceMin = 1, distanceMax = 3;
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platForm.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generatingPoint.position.x)
        {
            platformDistance = Random.Range(distanceMin, distanceMax);
            transform.position = new Vector3(transform.position.x + platformWidth + platformDistance,
                transform.position.y, transform.position.z);


            GameObject platform = ObjectPooler.Instance.GetFromPool();
            platform.transform.position = transform.position;
            platform.transform.rotation = transform.rotation;
            platform.SetActive(true);
        }
    }
}
