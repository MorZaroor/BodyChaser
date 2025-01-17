using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent : MonoBehaviour
{
    public GameOverCount gameovercount;
    public GameObject objectToShow;

    // �_�ł�����Ώ�
    [SerializeField] private Renderer _target;
    //�_�Ŏ���[s]
    [SerializeField] private float _cycle = 1;
    // ���ł̃f���[�e�B��(1�Ŋ��S��ON�A0�Ŋ��S��OFF)
    [SerializeField, Range(0, 1)] private float _dutyRate = 0.5f;
    private double _time;

    void Start()
    {
        //Goal��obj���擾
        GameObject obj = GameObject.Find("Goal");
        //�X�v���N�g�擾
        gameovercount = obj.GetComponent<GameOverCount>();
        //objct��\��
        objectToShow.SetActive(false);
    }

    void Update()
    {
        UIDisplay();
    }

    private void UIDisplay()
    {
        if (gameovercount.iscount == true)
        {
            //objct�\��
            objectToShow.SetActive(true);
            UIFlashing();
        }
        else if (gameovercount.iscount == false)
        {
            //objct��\��
            objectToShow.SetActive(false);
        }
    }
    private void UIFlashing()
    {
        // �����������o�߂�����
        _time += Time.deltaTime;

        // ����cycle�ŌJ��Ԃ��l�̎擾
        // 0�`cycle�͈̔͂̒l��������
        var repeatValue = Mathf.Repeat((float)_time, _cycle);

        // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
        // �f���[�e�B���ON/OFF�̊�����ύX���Ă���
        _target.enabled = repeatValue >= _cycle * (0.8 - _dutyRate);
    }
}
