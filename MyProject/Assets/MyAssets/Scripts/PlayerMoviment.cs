using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public static PlayerMoviment instance;

    Rigidbody2D myRigidbody;
    Animator animator;
    float moveX = 0f;
    SpriteRenderer sprite;
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpSpeed = 10f;
    private bool startMoving = false;

    public bool StartMoving {get {return startMoving;} }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        myRigidbody.velocity = new Vector2(moveX * moveSpeed, myRigidbody.velocity.y);
        
        AnimationControler();

        if(Input.GetButtonDown("Jump")) {
            
         myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);
        
        }

        
    }
    private void Awake() {
        if (instance == null)
        instance = this;
    }    

    void AnimationControler() {
        if(moveX > 0f)
        {
            animator.SetBool("isWalking",true);
            sprite.flipX = false;
            startMoving = true;
        }
        else if ( moveX < 0f)
        {
            animator.SetBool("isWalking",true);
            sprite.flipX = true;
            startMoving = true;
        }
        else 
        {
            animator.SetBool("isWalking",false);
        }
    }
}
