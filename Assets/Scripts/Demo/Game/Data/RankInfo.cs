using System.Collections.Generic;

public class RankInfo
{
    public string name;
    public float time;
    public int score;
    public RankInfo(){}
    
    public RankInfo(string name, float time, int score)
    {
        this.name = name;
        this.time = time;
        this.score = score;
    }
}

public class RankInfoList
{
    public List<RankInfo> rankInfoList;
}
