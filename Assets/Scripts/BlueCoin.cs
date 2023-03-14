using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCoin : MonoBehaviour
{
    [SerializeField] GameObject _parent;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hero"))
        {
            other.GetComponent<CharactorMove>().AddCoin();
            Destroy(_parent);
        }
    }
}
