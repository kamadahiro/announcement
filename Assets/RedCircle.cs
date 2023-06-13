using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �GAI
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class RedCircle : MonoBehaviour
{
    [SerializeField] GameObject _player;//�v���C���[�̃I�u�W�F�N�g

    SpriteRenderer _spriteRenderer;//���̃I�u�W�F�N�g��Sprite Renderer

    private void Start()
    {
        this._player = GameObject.FindGameObjectWithTag("Player");//Player�̃^�O�̃A�^�b�`����Ă�I�u�W�F�N�g�̌���
    }

    void FixedUpdate()
    {
        //�v���C���[-�G�L�����̈ʒu�֌W����������擾���A���x����艻
        Vector2 targeting = (_player.transform.position - this.transform.position).normalized;
        //�v���C���[�����̃I�u�W�F�N�g�̉E�ɂ���ꍇ
        if (targeting.x > 0)
        {
            #region�@�R���|�[�l���g�̎擾������
            if (this.gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))//�R���|�[�l���g�̎擾������
            {
                this._spriteRenderer = spriteRenderer;
                this._spriteRenderer.flipX = true;
            }
            #endregion
        }
        else
        {
            #region�@�R���|�[�l���g�̎擾������
            if (this.gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))//�R���|�[�l���g�̎擾������
            {
                this._spriteRenderer = spriteRenderer;
                this._spriteRenderer.flipX = false;
            }
            #endregion
        }
        //x�����ɂ̂݃v���C���[��ǂ�
        this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 5), 0);
    }
}
