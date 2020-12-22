using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject gamePrefab;

    private Queue<GameObject> availableEnemies = new Queue<GameObject>();   //setting a new queue for game objects. (Like a normal queue irl)

    //this is a basic singleton, which allows other scripts to access this script
    public static ObjectPooler Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        GrowPool();
    }

    public GameObject GetFromPool()
    {
        if (availableEnemies.Count == 0) //if pool is empty, then add more objects to the pool;
        {
            GrowPool();
        }
        var instance = availableEnemies.Dequeue();  //making new object by getting objects from the queue. Deque get the queue and return the object
        instance.SetActive(true);   //set active to true
        return instance;    //return instance 
    }

    private void GrowPool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instanceToAdd = Instantiate(gamePrefab);    //create the prefab
            //instanceToAdd.transform.SetParent(transform);   //set the parent to be the pool to keep track of the children. 
            AddToPool(instanceToAdd);       //add object to pool
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableEnemies.Enqueue(instance); //adding instance to the queue.
    }
}
