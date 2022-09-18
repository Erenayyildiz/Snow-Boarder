using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class head : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] ParticleSystem headeffect;
    [SerializeField] AudioClip sfx;
    bool sound = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ground" && !sound)
        {
            sound = true;
            FindObjectOfType<snowboard>().DisableControls();
            headeffect.Play();
            Invoke("reloadscene", delay);
            GetComponent<AudioSource>().PlayOneShot(sfx);
        }
    }

    void reloadscene()
    {
        SceneManager.LoadScene(0);
    }
}
