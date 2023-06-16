using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;  //�ϐ��̖��O�̓A���_�[�o�[�Ə���������n�܂�
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _jamp = 1000f;
    private float _inputX;
    bool _isjamp = false;
    // Update is called once per frame
    void Update()
    {
        _inputX = Input.GetAxisRaw("Horizontal2");//�v���C���[����


        if (Input.GetButtonDown("Jump2") && !_isjamp)
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
    }
}