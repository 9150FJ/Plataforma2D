using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour

{
    public float Speed;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;

    public AudioClip sonido;


    public void SetDirection(Vector2 direction)
    {
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
        Camera.main.GetComponent<AudioSource>().PlayOneShot(sonido);
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
    private void OnTriggerEnter2D(Collider2D collider)
    {
        JohnMovement john = collider.GetComponent<JohnMovement>();
        EnemyScript enemyScript = collider.GetComponent<EnemyScript>();
        if (john != null)
        { //hemos impactado con john
            john.Hit(1);
            DestroyBullet();
        }
        if (enemyScript != null)
        {//hemos impactado con grunt
            enemyScript.Hit();

            DestroyBullet();

        }

    }

}
