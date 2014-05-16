using UnityEngine;
using System.Collections;

public class ToMainMenu : MonoBehaviour 
{
    private Color original;

    void Awake()
    {
        original = gameObject.guiTexture.color;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.guiTexture.color = Color.white;
            Application.LoadLevel("mainMenu"); //the name of another scene file or scene index.
        }

        else
        {
            gameObject.guiTexture.color = Color.green;
        }
    }

    void OnMouseExit()
    {
        gameObject.guiTexture.color = original;
    }
}
