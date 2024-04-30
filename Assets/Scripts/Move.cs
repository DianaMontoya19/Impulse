using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Move : MonoBehaviour
{
    [SerializeField] private string _Horizontal;
    [SerializeField] private string _Vertical;
    [SerializeField] private float _Speed;
    [SerializeField] private Animator _animator;
    //[SerializeField] private string _key;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Hor = Input.GetAxisRaw(_Horizontal);
        float ver = Input.GetAxisRaw(_Vertical);

        _rb.velocity = new Vector2(Hor, ver)*_Speed;
        _animator.SetFloat("Velx", Hor);

        if(Hor < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }


        if (Input.GetKey(KeyCode.Return))
            {
                float velocity = 3f;
                Vector2 move = _rb.velocity* velocity;
                _rb.AddForce(move, ForceMode2D.Impulse);
            }

        


    }
}
