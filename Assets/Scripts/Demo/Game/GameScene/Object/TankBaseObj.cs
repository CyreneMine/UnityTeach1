using UnityEngine;

public abstract class TankBaseObj :MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHp = 100;
    public int nowHp;
    public float moveSpeed = 10;
    public float roundSpeed = 100;
    public float headRoundSpeed = 100;
    public GameObject deadEffect;
    public Transform head;
    public WeaponObj weapon;
    public abstract void Fire();

    public virtual void Wound(TankBaseObj other)
    {
        int dmg = other.atk - def;
        if (dmg < 0)
            return;
        nowHp -= dmg;
        if (nowHp <= 0)
        {
            nowHp = 0;
            Dead();
        }
    }
    public virtual void Dead()
    {
        if (deadEffect != null)
        {
            GameObject effObj = Instantiate(deadEffect, transform.position,transform.rotation);
            AudioSource audioSource = effObj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
            audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
            audioSource.Play();
        }
        Destroy(gameObject);
    }
}
