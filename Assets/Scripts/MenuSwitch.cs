using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitch : MonoBehaviour
{

    public Animator animator;


    // Start is called before the first frame update
    public void onClick()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(0));
        
        
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log("SceneSwitch");
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);
    }
}
