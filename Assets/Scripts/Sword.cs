using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
        private void OnTriggerEnter(Collider other)
    {
        

            if (other.GetComponent<Monster>() != null)
        {
            other.GetComponent<Monster>().hitted();
        }
;    }

   
}
