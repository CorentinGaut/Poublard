using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashContainer : MonoBehaviour
{
    public SoundPlayer soundPlayerPrefab;
    public AudioClip playerPointSound;

    public int nbPlayer;
    public int score;
    public LevelManager levelManager;
    public Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = score.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "catchable")
        {
            score++;
            levelManager.TrashPickUp(nbPlayer);
            Destroy(other.gameObject);
            txtScore.text = score.ToString();
            this.GetComponent<Animator>().SetTrigger("trashInside");

            SoundPlayer spawnSoundPlayer = Instantiate(soundPlayerPrefab, gameObject.transform.position, Quaternion.identity);
            spawnSoundPlayer.timeBeforeDestroy = 1f;
            spawnSoundPlayer.loop = false;
            spawnSoundPlayer.volume = 0.6f;
            spawnSoundPlayer.audioClip = playerPointSound;
        }
    }
}
