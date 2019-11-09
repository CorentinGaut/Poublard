using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashContainer : MonoBehaviour
{
    public int nbPlayer;
    public int score;
    public LevelManager levelManager;
    public Text txtScore;
    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trash")
        {
            score++;
            levelManager.TrashPickUp(nbPlayer);
            Destroy(other.gameObject);
            txtScore.text = score.ToString();
        }
    }
}
