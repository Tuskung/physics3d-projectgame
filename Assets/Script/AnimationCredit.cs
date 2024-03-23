using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationCredit : MonoBehaviour
{
 
    public void LoadSceneOnAnimationEnd()
    {
        SceneManager.LoadScene(0);
    }
}
