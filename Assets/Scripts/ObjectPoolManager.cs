using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager SharedInstance { get; private set; }
    //public List<GameObject> pooledObjects;
         
    [System.Serializable]
    public class poolClass
    {
        public string tagToCheck;
        public GameObject objectToPool;
        public int amountToPool;
    }

    public List<poolClass> m_Pools; 
    public Dictionary<string, Queue<GameObject>> pooledObjects;


    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new Dictionary<string, Queue<GameObject>>();

        foreach (poolClass pool in m_Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool.amountToPool; i++)
            {
                GameObject obj = Instantiate(pool.objectToPool);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                obj.transform.SetParent(this.transform);
            }
            pooledObjects.Add(pool.tagToCheck, objectPool);
        }
       /* for (int i=0; i<amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }*/
    }

   
}
