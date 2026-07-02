using System;
using UnityEngine;
using UnityEngine.UI;

public class QuitPanel : BasePanel<QuitPanel>
{
    public Button btnQuit;
    public Button btnBack;
    public Button btnSure;

    private void Start()
    {
        btnQuit.onClick.AddListener(HideMe);
        btnBack.onClick.AddListener(HideMe);
        btnSure.onClick.AddListener(Application.Quit);
        HideMe();
    }

    public override void ShowMe()
    {
        base.ShowMe();
        Time.timeScale = 0;
    }

    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
