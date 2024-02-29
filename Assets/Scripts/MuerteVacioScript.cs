using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteVacioScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D collider)
    {
        JohnMovement john = collider.GetComponent<JohnMovement>();
        
        
        if (john != null)
        { //hemos impactado con john
            john.Hit(john.getVidaMaxima());
            
        
        }


    }
}
