using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵AI
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class RedCircle : MonoBehaviour
{
    [SerializeField] GameObject _player;//プレイヤーのオブジェクト

    SpriteRenderer _spriteRenderer;//このオブジェクトのSprite Renderer

    private void Start()
    {
        this._player = GameObject.FindGameObjectWithTag("Player");//Playerのタグのアタッチされてるオブジェクトの検索
    }

    void FixedUpdate()
    {
        //プレイヤー-敵キャラの位置関係から方向を取得し、速度を一定化
        Vector2 targeting = (_player.transform.position - this.transform.position).normalized;
        //プレイヤーがこのオブジェクトの右にある場合
        if (targeting.x > 0)
        {
            #region　コンポーネントの取得を試す
            if (this.gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))//コンポーネントの取得を試す
            {
                this._spriteRenderer = spriteRenderer;
                this._spriteRenderer.flipX = true;
            }
            #endregion
        }
        else
        {
            #region　コンポーネントの取得を試す
            if (this.gameObject.TryGetComponent<SpriteRenderer>(out SpriteRenderer spriteRenderer))//コンポーネントの取得を試す
            {
                this._spriteRenderer = spriteRenderer;
                this._spriteRenderer.flipX = false;
            }
            #endregion
        }
        //x方向にのみプレイヤーを追う
        this.GetComponent<Rigidbody2D>().velocity = new Vector2((targeting.x * 5), 0);
    }
}
