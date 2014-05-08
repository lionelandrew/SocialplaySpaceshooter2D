using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public Vector2 startPoint;
    private float currentHealth;
    private float maxHealth;
    private float normalisedHealth;
    public Texture2D bgImage;
    public Texture2D fgImage;

    private GUIStyle style;
    private Done_PlayerController script;
    void Start()
    {
        script = GetComponent<Done_PlayerController>();
        style = new GUIStyle();
    }

	void OnGUI()
	{
        currentHealth = script.playerHealth;
        maxHealth = script.playerHealthMax;

        Rect rectBackGround = new Rect(startPoint.x, startPoint.y, 128, 32);
        normalisedHealth = ((float)currentHealth / maxHealth) * 128;
        Rect rectForeGround = new Rect(0, 0, normalisedHealth, 32);
       
        //Draw background
        GUI.BeginGroup(rectBackGround, bgImage);
        //Draw healthbar background
        GUI.BeginGroup(rectForeGround, fgImage);

        // End both Groups
        GUI.EndGroup();
        GUI.EndGroup();
	}
}