using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D Rigidbody2D;
    private float horizontal;
    public float Speed;
    public float JumpForce;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
    }


   void FixedUpdate(){

        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
   } 

   private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
   }
}
