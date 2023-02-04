using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;
    [SerializeField]
    float jumpForce;

    public bool isGrounded;
    public bool isStuck;

    private SpriteRenderer spriteRend;

    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Transform [] parent;

    Rigidbody2D rb;

    Vector2 forDir = new Vector2(1.0f, 0.0f);
    Vector2 upDir = new Vector2(0.0f, 1.0f);

    private void Awake()
    {
        spriteRend= GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        isStuck = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();

        if(Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(forDir * movementSpeed);
            if (spriteRend != null)
            {
                spriteRend.flipX = false;
            }
            /*OutOfBeingStuck();*/
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-forDir * movementSpeed);
            if (spriteRend != null)
            {
                spriteRend.flipX = true;
            }
            OutOfBeingStuck();
        }

        if(Input.GetKey(KeyCode.D))
        {
            OutOfBeingStuck();
        }
    }

    private void jJump()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true && isStuck == true)
        {
            Debug.Log("YOOOOOOOOOOOOOOO");
            OutOfBeingStuck();
            rb.AddForce(jumpForce * upDir, ForceMode2D.Impulse);
            DeActivateSG();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Root"))
        {
            Debug.Log("x,cmvnx,cmvnx,cmvn");
            //rb.constraints = RigidbodyConstraints2D.FreezeAll;
            isGrounded = true;
            isStuck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Root"))
        {
            Debug.Log("ON THE RUN !!!");
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
            isStuck = true;
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            gameObject.transform.position = spawnPoint.transform.position + new Vector3(0.0f, 6.0f);
            gameObject.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = false;
            isStuck = false;
        }
    }

    /*this.gameObject.transform.SetParent(parent);*/

    private void OutOfBeingStuck()
    {
        rb.constraints = RigidbodyConstraints2D.None;
    }

    private void DeActivateSG()
    {
        isGrounded = false;
        isStuck = false;
    }
}
