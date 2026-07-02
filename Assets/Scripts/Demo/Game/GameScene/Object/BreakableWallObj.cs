using UnityEngine;
using Random = UnityEngine.Random;

public class BreakableWallObj : MonoBehaviour
{
    public GameObject effect;
    public GameObject[] rewards;

    private void OnTriggerEnter(Collider other)
    {
        int random = Random.Range(0, 100);
        if (random < 50)
        {
            int index = Random.Range(0, rewards.Length);
            GameObject reward = Instantiate(rewards[index], transform.position, transform.rotation);
        }
        GameObject effectObj = Instantiate(effect, transform.position, transform.rotation);
        AudioSource audioSource = effectObj.GetComponent<AudioSource>();
        audioSource.volume = GameDataMgr.Instance.musicData.soundVolume;
        audioSource.mute = !GameDataMgr.Instance.musicData.isSound;
        audioSource.Play();
        Destroy(gameObject);
    }
}
