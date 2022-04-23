using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    public float spawnBoundry;

    void Update()
    {
        SpawnCheck();
    }

    public virtual void SpawnCheck()
    {
        if (transform.position.x < spawnBoundry)
        {
            MoveRight();
        }       
        else if (transform.position.x > spawnBoundry)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void MoveRight()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    public virtual void MoveLeft()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
