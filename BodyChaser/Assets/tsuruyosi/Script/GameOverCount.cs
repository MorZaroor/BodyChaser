using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCount : MonoBehaviour
{
    public float Limit = 100; //GameOver�܂ł̎���
    public float count;    //���ԃJ�E���g
    public bool iscount;    //UI�C�x���g�Ǘ�

    public GameClear goal;

    void Start()
    {
        //�X�v���N�g�擾
        goal = gameObject.GetComponent<GameClear>();
    }

    void Update()
    {
        //�S�[�����Ă��Ȃ���Ԃ̎��̂�
        if(goal.Clear == false)
        {
            OverLimit();
            EventIS();
        }
    }

    private void OverLimit()
    {
        //���ԃJ�E���g
        count += Time.deltaTime;

        if(count >= Limit)
        {
            SceneManager.LoadScene("GameOver");
            count = 0;
        }
    }

    public void EventIS()
    {
        if(count >= 50 && count <= 53)
        {
            iscount = true;
        }else
        {
            iscount = false;
        }
    }

}
