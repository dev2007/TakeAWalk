using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("Timer", 4.0f);
    }

    void Timer()
    {
        SceneManager.LoadScene("1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
