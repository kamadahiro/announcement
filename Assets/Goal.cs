using UnityEngine;
using TMPro;


// ゴールを制御するスクリプト
public class Goal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goalText;
    // ゴールしたかどうか
   [SerializeField]  private bool m_isGoal;
    private void Start()
    {
        _goalText.gameObject.SetActive(false);
    }

    // 他のオブジェクトと当たった時に呼び出される関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        // まだゴールしておらず
        if (!m_isGoal)
        {
            if (other.name.Contains("Player"))// 名前に「Player」が含まれるオブジェクトと当たったら
            { 
                // 何回もゴールしないように、ゴールしたことを記憶しておく
                m_isGoal = true;
                _goalText.gameObject.SetActive(true);
                Time.timeScale = 0f;

            }
        }
    }
}