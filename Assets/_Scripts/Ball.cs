using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   
    public Rigidbody rb;
    public float JumpForce;
    public GameObject splashprefab;
    public GameManager gm;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        GameObject splash = Instantiate(splashprefab, transform.position + new Vector3(0f,-0.2f,0f), transform.rotation);;
        splash.transform.SetParent(collision.gameObject.transform);
        
        string MaterialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        variables.DestroyPoint = 0;
        if (MaterialName == "unsafezone (Instance)")
        {
            gm.RestartGame();
            
        }
        

        if (variables.DestroyPoint >= 3)
        {
            if (collision.gameObject.transform.parent!=null)
            {
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
            variables.DestroyPoint = 0;
            variables.hasCollided = false;
        }
        else
        {
            variables.hasCollided = true;

        }
    }
    public void Jump()
    {
       

        if (variables.hasCollided == true)
        {
            rb.AddForce(Vector3.up * JumpForce);
            variables.hasCollided = false;
        }

    }

    
   
}
