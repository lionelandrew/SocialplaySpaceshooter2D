using UnityEngine;
using System.Collections;

public class FollowEnemy : MonoBehaviour 
{
    public Transform target;
 
    void Update ()
    {
         var wantedPos = Camera.main.WorldToScreenPoint (target.position);
         transform.position = wantedPos;
    }
}
