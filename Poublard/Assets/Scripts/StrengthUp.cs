using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthUp : MonoBehaviour
{
    public GameObject effectPrefab;

    public SoundPlayer soundPlayerPrefab;
    public AudioClip effectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.GetComponent<PoublardRagdoll>().ChangePunchMultiplicator();
            Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

            SoundPlayer spawnSoundPlayer = Instantiate(soundPlayerPrefab, gameObject.transform.position, Quaternion.identity);
            spawnSoundPlayer.timeBeforeDestroy = 2f;
            spawnSoundPlayer.loop = false;
            spawnSoundPlayer.volume = 0.4f;
            spawnSoundPlayer.audioClip = effectSound;
        }
    }
}
