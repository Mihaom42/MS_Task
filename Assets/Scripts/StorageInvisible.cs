using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageInvisible : MonoBehaviour
{
    CanvasGroup storage;
    // Start is called before the first frame update
    void Start()
    {
        storage = GetComponent<CanvasGroup>();
        storage.alpha = 0;
    }
}
