using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject aboutPanel;
    public void OpenPanel()
    {
        aboutPanel.SetActive(true);
    }
    public void QuitePanel()
    {
        aboutPanel.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
