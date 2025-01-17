using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHat : MonoBehaviour
{
    public GameOverCount gameovercount;
    public GameObject hat;
    //�X�q�������ԁ@�Ǘ�
    public float count;
    public bool isHat;
    //Player��Y���W������ϐ�
    public float play_y;

    void Start()
    {
        //Goal��obj���擾
        GameObject obj = GameObject.Find("Goal");
        //�X�v���N�g�擾
        gameovercount = obj.GetComponent<GameOverCount>();
    }

    // Update is called once per frame
    void Update()
    {
        HatTime();
        if(gameovercount.count >= 50 && gameovercount.count <= 90)
        {
            if(isHat == true)
            {
                Hatmanage();
            }
        }
    }

    public void HatTime()
    {
        count += Time.deltaTime;
        if (count >= 5)
        {
            isHat = true;
            count = 0;
        }
        else
        {
            isHat = false;
        }
    }

    public void Hatmanage()
    {
        //Player��Y���W�ɍ��킹�Đ���
        Vector3 play = GameObject.Find("Player").transform.position;
        play_y = play.y;
        Instantiate(hat, new Vector3(8.0f, play_y, 0.0f), Quaternion.identity);
    }
}
