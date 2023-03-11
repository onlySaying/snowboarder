using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
     [SerializeField] float waitTime = 1f;
     [SerializeField] ParticleSystem crashEffect;
     bool firstEffect = true;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            if(firstEffect == true)
            {   
                crashEffect.Play(); 
                GetComponent<AudioSource>().Play();
                Invoke("ReloadScene",waitTime);
                firstEffect = false;
            }
        }

          
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0); 
    }
}
