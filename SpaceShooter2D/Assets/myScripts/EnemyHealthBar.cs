using UnityEngine;
using System.Collections;

public class EnemyHealthBar : MonoBehaviour
{
    private float currentHealth;
    private float maxHealth;

    private float normalisedHealth;

    public Texture2D bgImage;

    private GUIStyle style;
    private Characters script;
    private Transform target;

    void Start()
    {
        target = this.gameObject.transform;
        script = GetComponent<Characters>();
        style = new GUIStyle();
    }

    void OnGUI()
    {
        currentHealth = script.currentHealth;
        maxHealth = script.maxHealth;
        Rect rectBackGround = new Rect(-(Camera.main.WorldToScreenPoint(-target.position).x - 975), (Camera.main.WorldToScreenPoint(-target.position).y + 340), 100, 16);
        normalisedHealth = ((float)currentHealth / maxHealth) * 100;
        Rect rectForeGround = new Rect(2, 3, normalisedHealth, 6);

        //Draw background
        GUI.BeginGroup(rectBackGround, bgImage);
            //Draw healthbar background
            GUI.BeginGroup(rectForeGround);
            //Draw healthbar
                DrawQuad(rectForeGround, Color.red);

            // End both Groups
            GUI.EndGroup();
        GUI.EndGroup();
    }

    void DrawQuad(Rect position, Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(position, GUIContent.none);
    }
}