using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;
    public MusicData musicData;
    private GameDataMgr()
    {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"Music") as MusicData;
        if (!musicData.notFirst)
        {
            musicData.notFirst = true;
            musicData.isMusic = true;
            musicData.musicVolume = 1;
            musicData.isSound = true;
            musicData.soundVolume = 1;
        }
    }
    public void OpenOrCloseMusic(bool state)
    {
        musicData.isMusic = state;
    }
    public void OpenOrCloseSound(bool state)
    {
        musicData.isSound = state;
    }
    public void ChangeMusicVolume(float volume)
    {
        musicData.musicVolume = volume;
    }
    public void ChangeSoundVolume(float volume)
    {
        musicData.soundVolume = volume;
    }

    public void SaveData()
    {
        PlayerPrefsDataMgr.Instance.SaveData(musicData,"Music");
    }
}
