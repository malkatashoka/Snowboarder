using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float invokeDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && player:= FindObjectOfType<PlayerController>().canMove)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            crashEffect.Play();
            Invoke("ReloadScene", invokeDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }


}
