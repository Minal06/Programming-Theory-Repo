using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Move Keys")]
    [SerializeField] KeyCode ForwardKey;
    [SerializeField] KeyCode BackwardKey;
    [SerializeField] float zRange;
    [SerializeField] float speed;

    [Header("Position Reset Place")]
    [SerializeField] float baseX;
    [SerializeField] float baseY;
    [SerializeField] float baseZ;




    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        BackLineMax();        
    }
            
    void HandleMovement()
    {
        if (Input.GetKey(ForwardKey))
        {
            MoveUp();
        }
        if (Input.GetKey(BackwardKey))
        {
            MoveDown();
        }
    }
    void MoveUp()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void MoveDown()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
    //players cannot move below certain point
    void BackLineMax()
    {
        if (transform.position.z < zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    void ResetPosition()
    {
        transform.position = new Vector3(baseX, baseY, baseZ);
    }

    private void OnTriggerEnter(Collider other)
    {       
            Debug.Log("Score!");
        ResetPosition();
                   
    }
}
