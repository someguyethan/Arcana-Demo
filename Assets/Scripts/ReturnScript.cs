using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    public void DoReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
