using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float moveDuration = 20f;  // 20�b�Ԃňړ�����
    private Vector3 startPosition;  // �����ʒu
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
            GoalPos();
        }
    }

    private void FirstLocation()
    {
        left_pos = left.transform.position;
        right_pos = right.transform.position;

        math = (Mathf.Abs(left_pos.x) - right_pos.x);
        Debug.Log(math);
    }

    private void SecondLocation()
    {
        startPosition = transform.position;
        float timeElapsed = time.count-50;                                                                                                                                                                                                                                                          
        if(timeElapsed <= moveDuration)
        {
            float t = timeElapsed / moveDuration; // 0����1�̊ԂŐi�s����v�Z
            // ��ʍ��W���烏�[���h���W�ɕϊ�
            Vector3 worldEndPosition = Camera.main.ScreenToWorldPoint(right_pos);
            worldEndPosition.z = transform.position.z; // Z���͂��̂܂܂ɂ���
            transform.position = Vector3.Lerp(startPosition, worldEndPosition, t);
        }
        else
        {
            // �I�����ԂɒB������A�E�[�ɌŒ�
            transform.position = Camera.main.ScreenToWorldPoint(right_pos);
            transform.position = new Vector3
                (transform.position.x, startPosition.y, transform.position.z);
        }
    }

    private void GoalPos()
    {
        Vector3 position = transform.position;
        position.x = pos;
        transform.position = position;
    }

    private void Condition()
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

    }//�S�[���̈ړ�����ʒu�@����


}
