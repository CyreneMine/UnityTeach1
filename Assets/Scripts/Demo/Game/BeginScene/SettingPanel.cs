using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : BasePanel<SettingPanel>
{
    public Button btnQuit;
    public Toggle tgMusic;
    public Toggle tgSound;
    public Slider sldMusic;
    public Slider sldSound;

    private void Start()
    {
        btnQuit.onClick.AddListener((() =>
        {
            HideMe();
            PlayerPrefsDataMgr.Instance.SaveData(GameDataMgr.Instance.musicData,"Music");
            if (SceneManager.GetActiveScene().name == "BeginScene")
            {
                BeginPanel.Instance.ShowMe();
            }
        }));
        tgMusic.onValueChanged.AddListener(arg0 => GameDataMgr.Instance.OpenOrCloseMusic(arg0));
        tgSound.onValueChanged.AddListener(arg0 => GameDataMgr.Instance.OpenOrCloseSound(arg0));
        sldMusic.onValueChanged.AddListener(arg0 => GameDataMgr.Instance.ChangeMusicVolume(arg0));
        sldSound.onValueChanged.AddListener(arg0 =>  GameDataMgr.Instance.ChangeSoundVolume(arg0));
        gameObject.SetActive(false);
    }

    public void UpdatePanel()
    {
        MusicData data = GameDataMgr.Instance.musicData;
        tgMusic.isOn = data.isMusic;
        tgSound.isOn = data.isSound;
        sldMusic.value = data.musicVolume;
        sldSound.value = data.soundVolume;
    }

    public override void ShowMe()
    {
        base.ShowMe();
        Time.timeScale = 0;
        UpdatePanel();
    }
    public override void HideMe()
    {
        base.HideMe();
        Time.timeScale = 1;
    }
}
