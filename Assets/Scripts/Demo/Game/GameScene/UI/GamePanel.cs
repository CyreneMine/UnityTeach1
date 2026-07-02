using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel<GamePanel>
{
    public TMP_Text labScore;
    public TMP_Text labTime;
    public Button btnSetting;
    public Button btnQuit;
    public Slider sldHp;
    public RawImage miniMap;
    [HideInInspector] private int nowScore;
    [HideInInspector] private float nowTime;
    private void Start()
    {
        btnQuit.onClick.AddListener(() =>
        {
            QuitPanel.Instance.ShowMe();
        });
        btnSetting.onClick.AddListener(() =>
        {
            SettingPanel.Instance.ShowMe();
        });
    }

    private void Update()
    {
        nowTime += Time.deltaTime;
        UpdateTime();
    }

    public void AddScore(int score)
    {
        nowScore += score;
        labScore.text = score.ToString();
    }
    public void UpdateHp(int hp)
    {
        sldHp.value += hp;
        if (sldHp.value <=0)
        {
            Application.Quit();
        }
    }

    private void UpdateTime()
    {
        string hour, min, sec;
        hour = ((int)nowTime / 3600).ToString();
        min = (((int)nowTime % 3600)/60).ToString();
        sec = ((int)nowTime % 60).ToString();
        labTime.text = hour + ":" + min + ":" + sec;
    }
}
