using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Button returnButton;  // 在Unity编辑器中关联场景里的返回按钮UI元素
    private void Start()
    {
        returnButton.gameObject.SetActive(false);  // 开始时隐藏返回按钮
                                                   // 为返回按钮添加点击事件监听，点击时加载主场景
        returnButton.onClick.AddListener(LoadMainScene);
    }
    // 由动画事件调用，用于在结算动画结束后显示返回按钮
    public void ShowReturnButton()
    {
        returnButton.gameObject.SetActive(true);
    }
    // 加载主场景的函数
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");  // 这里假设主场景名字是"MainScene"，根据实际修改
    }
}
