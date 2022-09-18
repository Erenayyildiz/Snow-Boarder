using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] ParticleSystem finisheffect;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "snowboard")
        {
            FindObjectOfType<snowboard>().DisableControls();
            finisheffect.Play();
            Invoke("ReloadScene", delay);
            GetComponent<AudioSource>().Play();
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
}
