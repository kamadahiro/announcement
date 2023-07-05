using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;  //変数の名前はアンダーバーと小文字から始まる
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jamp = 1000f;
    private float _inputX;
    bool _isjamp = false;
    Vector3 _initPos;
    // Update is called once per frame
    private void Start()
    {
        _initPos = transform.position;
    }
    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal");//プレイヤー操作

        
        if (Input.GetButtonDown("Jump") && !_isjamp )//どのキーで操作をするか
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jamp);
            _isjamp = true;
        }
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(_inputX * _playerSpeed, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isjamp = false;
        if(collision.gameObject.tag =="Block")//ブロックに触れたらもう一度ジャンプできる
        {
            transform.position = _initPos;
        }
    }
}
