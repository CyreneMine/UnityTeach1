using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;
    public MusicData musicData;
    public RankInfoList rankData;
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
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankInfoList),"Rank") as RankInfoList;
    }
    public void OpenOrCloseMusic(bool state)
    {
        musicData.isMusic = state;
        BKMusic.Instance.ChangeOpen(!state);
    }
    public void OpenOrCloseSound(bool state)
    {
        musicData.isSound = state;
    }
    public void ChangeMusicVolume(float volume)
    {
        musicData.musicVolume = volume;
        BKMusic.Instance.ChangeVolume(volume);
    }
    public void ChangeSoundVolume(float volume)
    {
        musicData.soundVolume = volume;
    }

    public void AddRankInfo(string name,int score,float time)
    {
        bool isExist = false;
        for (int i = 0; i < rankData.rankInfoList.Count; i++)
        {
            if (rankData.rankInfoList[i].name == name)
            {
                isExist = true;
                if (rankData.rankInfoList[i].score < score)
                {
                    rankData.rankInfoList[i].score = score;
                    rankData.rankInfoList[i].time = time;
                }else if (rankData.rankInfoList[i].score == score)
                {
                    rankData.rankInfoList[i].time = rankData.rankInfoList[i].time > time ? time : rankData.rankInfoList[i].time;
                }
                break;
            }
        }

        if (!isExist)
        {
            rankData.rankInfoList.Add(new RankInfo(name, time, score));
        }
        rankData.rankInfoList.Sort((a, b) =>
        {
            if (a.score > b.score)
            {
                return -1;
            }
            else if(a.score < b.score)
            {
                return 1;
            }

            if (a.time < b.time)
            {
                return -1;
            }
            else if(a.time > b.time)
            {
                return 1;
            }
            return 0;
        });
        for (int i = rankData.rankInfoList.Count-1; i > 8 ; i--)
        {
            rankData.rankInfoList.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.SaveData(rankData,"Rank");
    }
}
