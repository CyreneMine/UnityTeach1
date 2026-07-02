using System;
using UnityEngine;

public enum PropType
{
    Atk,
    Def,
    Hp,
    MaxHp
}
public class PropReward : MonoBehaviour
{
    public int changeValue;
    public PropType propType =  PropType.Atk;
    public GameObject effect;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        PlayerObj player = other.gameObject.GetComponent<PlayerObj>();
        switch (propType)
        {
            case PropType.Atk:
                player.atk += changeValue;
                break;
            case PropType.Def:
                player.def += changeValue;
                break;
            case PropType.Hp:
                player.nowHp += changeValue;
                if (player.nowHp > player.maxHp)
                {
                    player.nowHp = player.maxHp;
                }
                GamePanel.Instance.sldHp.value += changeValue;
                break;
            case PropType.MaxHp:
                player.maxHp += changeValue;
                GamePanel.Instance.sldHp.maxValue += changeValue;
                break;
        }
        GameObject effectObj = Instantiate(effect, transform.position, transform.rotation);
        AudioSource audioSource = effectObj.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
        audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
        audioSource.Play();
        Destroy(gameObject);
    }
}
