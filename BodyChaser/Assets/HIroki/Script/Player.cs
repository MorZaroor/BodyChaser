using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace Kawano
{
    public class Player : MonoBehaviour
    {
        public Transform target;
        public float someMultiplier = -6f;
        [SerializeField, Header("縦の移動速度")]
        private float _Tate_speed;
        [SerializeField, Header("横の移動速度")]
        private float _Yoko_speed;

        // Start is called before the first frame update
        void Start()
        {
            // 120fpsを目標に設定
            Application.targetFrameRate = 120;
        }

        // Update is called once per frame
        void Update()
        {
            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * _Yoko_speed;
            float moveY = Input.GetAxis("Vertical") * Time.deltaTime * _Tate_speed;

            transform.position = new Vector2(
                transform.position.x,
                Mathf.Clamp(transform.position.y + moveY, -8.5f, 8.5f)
            );
            transform.position += Vector3.right * _Yoko_speed * Time.deltaTime;
            float angle = _Yoko_speed * someMultiplier + 110f;
            target.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

}
