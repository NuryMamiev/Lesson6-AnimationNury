using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    private Simple _simple;
    [SerializeField] private Animator _animator;
    private  int  IsDead = Animator.StringToHash("IsDead");

    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool(IsDead,true);
            
        }

        
    }
}
