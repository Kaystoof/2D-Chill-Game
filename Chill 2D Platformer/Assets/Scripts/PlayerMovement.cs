using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    float valX = 0;
    public float speed = 1f;
    
    #region Jump
    int maxJumps = 2;
    int Jumps;
    float jumpForce = 10f;
    #endregion

    int dashes;
    public float dashMultiplier;

    bool grounded = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Jumps = maxJumps;
    }
	
	void Update()
    {
        Move();
        
	}

    private void Move()
    {
        valX = Input.GetAxis("Horizontal") * speed;
       
        rb2D.AddForce(new Vector2(valX, 0));

        if (Input.GetKeyDown(KeyCode.Space)&&Jumps>0)
        {
            rb2D.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
            Jumps -= 1;
        }
        //transform.position += new Vector3(valX, 0, 0);

        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene("level1");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb2D.AddForce(new Vector2(Mathf.Sign(rb2D.velocity.x) * dashMultiplier, 0),ForceMode2D.Impulse);
            
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && grounded == false)
        {
            rb2D.AddForce(new Vector2(0f, -10f), ForceMode2D.Impulse);
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "colObj")
        {
            Jumps = maxJumps;
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if(other.tag == "Exit")
        {
          
            SceneManager.LoadScene("level1");
        }
    }
}
