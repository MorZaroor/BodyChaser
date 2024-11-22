using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCount : MonoBehaviour
{
    [SerializeField] float Limit = 70; //GameOver�܂ł̎���
    float count;    //���ԃJ�E���g

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
        }
    }

    private void OverLimit()
    {
        //���ԃJ�E���g
        count += Time.deltaTime;

        if(count >= Limit)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

}
