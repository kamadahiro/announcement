using UnityEngine;
using TMPro;


// �S�[���𐧌䂷��X�N���v�g
public class Goal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _goalText;
    // �S�[���������ǂ���
   [SerializeField]  private bool m_isGoal;
    private void Start()
    {
        _goalText.gameObject.SetActive(false);
    }

    // ���̃I�u�W�F�N�g�Ɠ����������ɌĂяo�����֐�
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �܂��S�[�����Ă��炸
        if (!m_isGoal)
        {
            if (other.name.Contains("Player"))// ���O�ɁuPlayer�v���܂܂��I�u�W�F�N�g�Ɠ���������
            { 
                // ������S�[�����Ȃ��悤�ɁA�S�[���������Ƃ��L�����Ă���
                m_isGoal = true;
                _goalText.gameObject.SetActive(true);
                Time.timeScale = 0f;

            }
        }
    }
}