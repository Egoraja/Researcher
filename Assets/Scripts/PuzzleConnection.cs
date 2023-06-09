using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleConnection : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip successAudio;



    public void SuccessConection()
    {
        audioSource.PlayOneShot(successAudio);
    }
}
