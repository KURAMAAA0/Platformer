using UnityEngine;

public class PlayerMovement : MonoBehaviour //Centini le S
{
    public float moveSpeed;
    public float jumpForce;
    
    private bool isJumping;
    private bool isGrounded;

    public Transform GroundCheckOne;
    public Transform GroundCheckTwo;

    public Rigidbody2D rb;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapArea(GroundCheckOne.position, GroundCheckTwo.position); //Verification de sauts

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //Deplacement droite/gauche
        
        
        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            isJumping= true;
        }

        MovePlayer(horizontalMovement); //Saut
 
    }

    void MovePlayer(float horizontalMovement) 
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce)); //Saut
            isJumping = false;
        }
    }

}


