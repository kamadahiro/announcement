using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;  //�ϐ��̖��O�̓A���_�[�o�[�Ə���������n�܂�
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
        _inputX = Input.GetAxisRaw("Horizontal");//�v���C���[����

        
        if (Input.GetButtonDown("Jump") && !_isjamp )//�ǂ̃L�[�ő�������邩
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
        if(collision.gameObject.tag =="Block")//�u���b�N�ɐG�ꂽ�������x�W�����v�ł���
        {
            transform.position = _initPos;
        }
    }
}
