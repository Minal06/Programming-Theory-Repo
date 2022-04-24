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
        if(other.tag == "Finish")
        {
            Debug.Log("Player 1 Score!");            
        } else if (other.tag == "Finish2")
        {
            Debug.Log("Player 2 Score!");
        }
        else
        {
            other.gameObject.SetActive(false);
        }
        ResetPosition();
    }
}
