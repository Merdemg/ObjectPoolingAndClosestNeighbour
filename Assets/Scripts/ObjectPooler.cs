using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] GameObject prefab = null;
    [SerializeField] int defaultPoolSize = 10;

    Queue<GameObject> availableObjects = new Queue<GameObject>();


    void Start()
    {
        for (int i = 0; i < defaultPoolSize; i++)
        {
            AddObjectToPool();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public GameObject GetObjectFromPool(Vector3 Position, Quaternion Rotation){
        if (availableObjects.Count == 0)
        {
            AddObjectToPool();
        }

        GameObject Obj = availableObjects.Dequeue();
        Obj.transform.position = Position;
        Obj.transform.rotation = Rotation;
        Obj.SetActive(true);
        return Obj;
    }

    void AddObjectToPool(){
        GameObject NewObj = Instantiate(prefab, transform.position, Quaternion.identity);
        AddObjectToPool(NewObj);
    }

    public void AddObjectToPool(GameObject Object){
        Object.transform.parent = transform;
        Object.SetActive(false);
        availableObjects.Enqueue(Object);
    }
}
