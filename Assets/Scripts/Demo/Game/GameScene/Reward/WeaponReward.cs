using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponReward : MonoBehaviour
{
    public GameObject effect;
    public GameObject[] weapons;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        int index = Random.Range(0, weapons.Length);
        other.gameObject.GetComponent<PlayerObj>().ChangeWeapon(weapons[index]);
        other.gameObject.GetComponent<PlayerObj>().weapon.fatherObj = other.gameObject.GetComponent<PlayerObj>();
        GameObject effectObj = Instantiate(effect, transform.position, transform.rotation);
        AudioSource audioSource = effectObj.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
        audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
        audioSource.Play();
        Destroy(gameObject);
    }
}
