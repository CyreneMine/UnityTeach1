using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankPanel : BasePanel<RankPanel>
{
    public Button btnClose;
    private List<TMP_Text> labPMs =  new List<TMP_Text>();
    private List<TMP_Text> labNames =  new List<TMP_Text>();
    private List<TMP_Text> labScores =  new List<TMP_Text>();
    private List<TMP_Text> labTimes =  new List<TMP_Text>();
    
    private void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            labPMs.Add(transform.Find($"RankData/PM/labPM{i}").GetComponent<TMP_Text>());
            labNames.Add(transform.Find($"RankData/Name/labName{i}").GetComponent<TMP_Text>());
            labScores.Add(transform.Find($"RankData/Score/labScore{i}").GetComponent<TMP_Text>());
            labTimes.Add(transform.Find($"RankData/Time/labTime{i}").GetComponent<TMP_Text>());
        }
        btnClose.onClick.AddListener(HideMe);
        HideMe();
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdatePanelInfo();
    }
    private void UpdatePanelInfo()
    {
        List<RankInfo> rankInfoList = GameDataMgr.Instance.rankData.rankInfoList;
        for (int i = 0; i < rankInfoList.Count; i++)
        {
            labNames[i].text = rankInfoList[i].name;
            labScores[i].text = rankInfoList[i].score.ToString();
            labTimes[i].text = "";
            string hour, min, sec;
            hour = ((int)rankInfoList[i].time / 3600).ToString();
            min = (((int)rankInfoList[i].time % 3600)/60).ToString();
            sec = ((int)rankInfoList[i].time % 60).ToString();
            labTimes[i].text = hour + ":" + min + ":" + sec;
        }
    }
}
