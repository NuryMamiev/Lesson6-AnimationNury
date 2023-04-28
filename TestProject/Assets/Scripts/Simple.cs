using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Simple : MonoBehaviour
{
    [HideInInspector, SerializeField] private CharacterController _ourcharacter;
    [SerializeField] private float mSpeed = 10;
    [SerializeField] private Animator _animator;
    private Vector3 _velocity = Vector3.zero;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private  int  IsDead = Animator.StringToHash("IsDead");
    private bool IsReallyDead = false;
    private RestartPrefab _restartManagerRestartPrefab;
    
    

    private void OnValidate()
    {
        _ourcharacter = GetComponent<CharacterController>();
        
        
    }

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
        var mouse = Input.GetAxis("Mouse X");
        RotateCharacter(mouse);
        Move(horizontal,vertical);
    }

    private void RotateCharacter(float mouse)
    {
        if (!IsReallyDead)
        {
            transform.Rotate(Vector3.up, mouse * 1.5f);
        }
    }

    private void Move(float horizontal,float vertical)
    {
        if (!IsReallyDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetTrigger(Attack);
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                _animator.SetBool(IsDead,true);
                IsReallyDead = true;
                _restartManagerRestartPrefab.ShowRestartButton();

            }
            _animator.SetBool(IsWalking, horizontal != 0 || vertical != 0);
            var dir = new Vector3(horizontal, 0, vertical);
            var moveVector = transform.TransformDirection(dir) * mSpeed;

            if (_ourcharacter.isGrounded && _velocity.y < 0)
            {
                _velocity.y = 0;
            }

            _velocity.y += -9.81f * Time.deltaTime;
            _ourcharacter.Move((moveVector + _velocity) * Time.deltaTime);
        }
    }

   
}
