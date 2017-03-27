using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject btnObj = GameObject.Find("Btn_Start");//"Button"为你的Button的名称  
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate()
        {
            Debug.Log("switch to 1");
            SceneManager.LoadScene("1");
        });  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
