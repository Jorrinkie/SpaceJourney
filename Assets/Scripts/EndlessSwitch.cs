using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndlessSwitch : MonoBehaviour
{


    public Animator animator;


    IEnumerator LoadLevel(int levelIndex)
    {
        Debug.Log("SceneSwitch");
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClik()
    {
        StartCoroutine(LoadLevel(1));
    }
}
