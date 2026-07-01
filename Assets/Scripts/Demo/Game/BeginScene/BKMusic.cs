using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance => instance;
    private AudioSource audioSource;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
        ChangeOpen(!GameDataMgr.Instance.musicData.isMusic);
        ChangeVolume(GameDataMgr.Instance.musicData.musicVolume);
    }
    
    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void ChangeOpen(bool isMute)
    {
        audioSource.mute = isMute;
    }
}
