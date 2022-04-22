using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    
             
    [System.Serializable]
    public class poolClass
    {
        public string tagToCheck;
        public GameObject objectToPool;
        public int amountToPool;
    }

    public List<poolClass> m_Pools; 
    public Dictionary<string, Queue<GameObject>> pooledObjects;

    #region Singleton
    public static ObjectPoolManager SharedInstance { get; private set; }
    private void Awake()
    {
        SharedInstance = this;
    }
    #endregion

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
    }

    public GameObject SpawnFromPool(string tagToCheck, Vector3 position, Quaternion rotation)
    {
        if (!pooledObjects.ContainsKey(tagToCheck))
        {
            Debug.LogWarning("tag is not correct");
            return null;
        }

        GameObject objectToSpawn = pooledObjects[tagToCheck].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        pooledObjects[tagToCheck].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

   
}
