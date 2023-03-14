using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] Monster _monBase;
    
  public void DieEnd()
    {
        _monBase.DieEnd();
    }
}
