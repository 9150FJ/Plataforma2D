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

    private bool Grounded;



    private Animator Animator;
    public GameObject prefabBullet;

    private float LastShoot;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();

        Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        Animator.SetBool("running",horizontal !=0.0f);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > LastShoot + 0.25f){
            Shoot();  
            LastShoot = Time.time;

        }


              if(horizontal < 0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if (horizontal > 0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);

    }
    private void Shoot(){
    // Pintamos el Prefab en scena, en la posición indicada y la rotación=0
        Vector3 direction;
        if ( transform.localScale.x == 1.0f ) direction = Vector3.right;
        else direction = Vector3.left;


        GameObject bullet = Instantiate(prefabBullet,transform.position + direction *0.1f, Quaternion.identity);

        bullet.GetComponent<BulletScript>().SetDirection(direction);

    }


    void FixedUpdate()
    {

        Rigidbody2D.velocity = new Vector2(horizontal, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
}
