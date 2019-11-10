using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {
    private float count = 0;
	void Update () {
        count += Time.deltaTime;
        if (count >= 2f)
        {
            Destroy(gameObject);
        }
    }
}
