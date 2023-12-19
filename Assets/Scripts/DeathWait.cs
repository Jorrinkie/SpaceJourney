using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWait : MonoBehaviour
{
    public bool deadwait;
    public float TimeE;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (deadwait)
        {
            TimeE += Time.deltaTime;
            if (TimeE > 2)
            {
                Time.timeScale = 1;
                StartCoroutine(LoadLevel(3));
            }
        }
    }


    IEnumerator LoadLevel(int levelIndex)
    {
      
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
        SceneManager.LoadScene(levelIndex);
    }

}

