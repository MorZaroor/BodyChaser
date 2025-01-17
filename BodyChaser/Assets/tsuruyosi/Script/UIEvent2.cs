using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvent2 : MonoBehaviour
{
    public GameOverCount gameovercount;
    public GameObject objectToShow;

    void Start()
    {
        //Goal��obj���擾
        GameObject obj = GameObject.Find("Goal");
        //�X�v���N�g�擾
        gameovercount = obj.GetComponent<GameOverCount>();
        //objct��\��
        objectToShow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UIDisplay2();
    }

    public void UIDisplay2()
    {
        if (gameovercount.count >= 53)
        {
            objectToShow.SetActive(true);
        }else if(gameovercount.count >= 90)
        {
            objectToShow.SetActive(false);
        }
    }
}
