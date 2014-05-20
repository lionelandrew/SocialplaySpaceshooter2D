using UnityEngine;
using System.Collections;

public class NGUIToMainMenu : MonoBehaviour
{
    void OnClick()
    {
        Application.LoadLevel("mainMenu");
    }
}
