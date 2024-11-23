using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalTransform : MonoBehaviour
{
    //Player�̈ʒu�ƉE�[�̈ʒu�̒��ԁ@50�b��
    //�E�[�ɐi�ށ@50�b�Ԍ�

    public GameObject left;
    public GameObject right;
    float math; //�ʒu�v�Z����
    float pos;  //�S�[���̈ʒu
    Vector3 left_pos;
    Vector3 right_pos;
    public GameOverCount time;

    void Start()
    {
        //�X�v���N�g�擾
        time = gameObject.GetComponent<GameOverCount>();
    }

    void Update()
    {
        if(time.count <= 50)
        {
            FirstLocation();
            Condition();
            GoalPos();
        }
        else if(time.count > 50 && time.count <= 70)
        {
            SecondLocation();
        }
    }

    private void FirstLocation()
    {
        left_pos = left.transform.position;
        right_pos = right.transform.position;

        math = (Mathf.Abs(left_pos.x) - right_pos.x);
    }

    private void SecondLocation()
    {
        this.transform.DOMove(new Vector3(right_pos.x,0f,0f),20f);
    }

    private void GoalPos()
    {
        Vector3 position = transform.position;
        position.x = pos;
        transform.position = position;
    }

    private void Condition()//�S�[���̈ړ�����ʒu�@����
    {
        if (left_pos.x < 1)
        {
            if (math < -0.5 && math >= -6.5)
            {
                pos = Mathf.Abs(math);
            }
            else if (math > -0.5)
            {
                math = -0.5f;
                pos = Mathf.Abs(math);
            }
            else if (math <= -6.5)
            {
                math = -6.5f;
                pos = Mathf.Abs(math);
            }
        }
        else
        {
            math = -6.5f;
            pos = Mathf.Abs(math);
        }

    }


}
