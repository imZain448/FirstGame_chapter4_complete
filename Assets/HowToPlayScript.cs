using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
