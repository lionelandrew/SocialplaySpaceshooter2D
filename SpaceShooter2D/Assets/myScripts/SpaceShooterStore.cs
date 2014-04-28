using UnityEngine;
using System.Collections;

public class SpaceShooterStore : MonoBehaviour
{
    public GameObject leaveButton;
    public GameObject StorePanel;

    void Start()
    {
        UIEventListener.Get(leaveButton).onClick += OnLeaveButtonClicked;
    }

    void OnLeaveButtonClicked(GameObject leaveButton)
    {
        LeaveSpaceShooterStore();
    }

    public void EnterSpaceShooterStore()
    {
        StorePanel.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void LeaveSpaceShooterStore()
    {
        StorePanel.transform.localPosition = new Vector3(1500, 0, 0);
    }
}
