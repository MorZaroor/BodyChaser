using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] float GameOverTime;
    float Counttime;
    // Start is called before the first frame update
    void Start()
    {
        Counttime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Counttime += Time.deltaTime;
        if( Counttime >= GameOverTime)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
