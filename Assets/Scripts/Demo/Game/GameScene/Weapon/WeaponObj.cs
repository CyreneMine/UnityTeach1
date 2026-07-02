using UnityEngine;

public class WeaponObj :MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform[] bulletSpawn;
    public TankBaseObj fatherObj;
    public void Fire()
    {
        if (bulletSpawn == null) return;
        for (int i = 0; i < bulletSpawn.Length; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn[i].position, bulletSpawn[i].rotation);
            bullet.GetComponent<BulletObj>().fatherObj = fatherObj;
            AudioSource audioSource = bullet.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
            audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
            audioSource.Play();
        }
    }
}
