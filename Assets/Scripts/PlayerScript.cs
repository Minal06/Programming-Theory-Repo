using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Game Manager settings")]
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        HandleMovement();
        BackLineMax();        
    }
            
    void HandleMovement()
    {
        if (Input.GetKey(ForwardKey) && gameManager.canPlay == true)
        {
            MoveUp();
        }
        if (Input.GetKey(BackwardKey) && gameManager.canPlay == true)
        {
            MoveDown();
        }

        if (Input.GetKeyDown(KeyCode.Space) && gameManager.canPlay == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            gameManager.ScorePointPlayerOne(1);
            Debug.Log("Player 1 Score!");            
        } else if (other.tag == "Finish2")
        {
            gameManager.ScorePointPlayerTwo(1);
            Debug.Log("Player 2 Score!");
        }
        else
        {
            other.gameObject.SetActive(false);
        }
        ResetPosition();
    }
}
