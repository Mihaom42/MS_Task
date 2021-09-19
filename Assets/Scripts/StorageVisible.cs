using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageVisible : MonoBehaviour
{
    CanvasGroup storage;
    public AudioSource dialogAudio;
    // Start is called before the first frame update
    void Start()
    {
        storage = GetComponent<CanvasGroup>();
    }

    IEnumerator VisibleCanvas()
    {
        yield return new WaitForEndOfFrame();
        storage.alpha = 1;
        dialogAudio.Play();
    }

    public void StartCanvasVisible()
    {
        StartCoroutine("VisibleCanvas");
    }
}
