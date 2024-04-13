using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP : MonoBehaviour
{
    public int sceneID;


    private void OnTriggerEnter(Collider other)
    {
        Teleport();
    }

    void Teleport()
    {
        SceneManager.LoadScene(sceneID);
    }

}
