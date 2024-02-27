using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour

{
    public float Speed;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;


    public void SetDirection(Vector2 direction){
		Direction = direction;
    }

    // Start is called before the first frame update
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Rigidbody2D.velocity = Vector2.right * Speed;
        Rigidbody2D.velocity = Direction * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D.velocity = Vector2.right * Speed;
    }
}
