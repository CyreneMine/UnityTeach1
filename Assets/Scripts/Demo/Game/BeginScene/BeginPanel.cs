using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginPanel : BasePanel<BeginPanel>
{
    public Button btnBegin;
    public Button btnSetting;
    public Button btnQuit;
    public Button btnRank;

    private void Start()
    {
        btnBegin.onClick.AddListener((() =>
        {
            SceneManager.LoadScene("GameScene");
        }));
        btnQuit.onClick.AddListener((() =>
        {
            Application.Quit();
        }));
        btnRank.onClick.AddListener((() =>
        {
            //TODO 后续打开排行榜界面
            
        }));
        btnSetting.onClick.AddListener((() =>
        {
            SettingPanel.Instance.ShowMe();
            HideMe();
        }));
    }

    private void Update()
    {
        
    }
}
