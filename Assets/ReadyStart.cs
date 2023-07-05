using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyStart: MonoBehaviour
{
    [SerializeField] Text _startText;
    [SerializeField] Player _player;
    [SerializeField] Player2 _player2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartCount");
        _player.enabled = false;
        _player2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCount()
    {
        _startText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        _startText.gameObject.SetActive(false);
        _player.enabled = true;
        _player2.enabled = true;
    }

}
