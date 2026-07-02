using System;
using UnityEngine;


public class BulletObj : MonoBehaviour 
{
    public TankBaseObj fatherObj;
    public float bulletSpeed;
    public GameObject effect;
    private void Update()
    {
        transform.Translate(Vector3.forward * (bulletSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnbreakableWall")|| other.CompareTag("BreakableWall"))
        {
            if (effect != null)
            {
                GameObject effectObj = Instantiate(effect, transform.position, transform.rotation);
                AudioSource audioSource = effectObj.GetComponent<AudioSource>();
                audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
                audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
                audioSource.Play();
            }
            Destroy(gameObject);
        }
    }
}
