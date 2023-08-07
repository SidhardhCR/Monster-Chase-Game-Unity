using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D mybody;
    private Animator anim;
    private SpriteRenderer sr;

    private string WALK_ANIMATION = "walk";
    private string GROUND_TAG = "Ground";
    private bool isGrounded=true;
    private string ENEMY_TAG = "Enemy";

     void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        PlayerAnimation();
        PlayerJump();
    }

    

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void PlayerAnimation()
    {   
        //move to right side
        if(movementX>0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }//move to left side
        else if(movementX<0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX=true;
        }//idle
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2 (0f, jumpForce),ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded=true;
        }
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(ENEMY_TAG))
        { Destroy(gameObject); }
    }
}
