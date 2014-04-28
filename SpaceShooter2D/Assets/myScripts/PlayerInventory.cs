using UnityEngine;
using System.Collections;
using SocialPlay.ItemSystems;

public class PlayerInventory : MonoBehaviour {

    public GameObject inventoryPanel;
    public GameObject equipmentPanel;
    public GameObject characterStatsPanel;
    public ItemContainer container;
    public ItemContainer equipmentContainer;
    bool isPanelShown = false;

    void Start () {
        container = inventoryPanel.GetComponent<ItemContainer>();
        equipmentContainer = equipmentPanel.GetComponent<ItemContainer>();
    }

    public void OpenInventory()
    {
        inventoryPanel.transform.localPosition = new Vector3(0, 0, 0);
        equipmentPanel.transform.localPosition = new Vector3(315, 50, 0);
        characterStatsPanel.transform.localPosition = new Vector3(-315, 46, 0);
        isPanelShown = true;
    }

    public void CloseInventory()
    {
        inventoryPanel.transform.localPosition = new Vector3(1000, 0, 0);
        equipmentPanel.transform.localPosition = new Vector3(1000, 0, 0);
        characterStatsPanel.transform.localPosition = new Vector3(1000, 0, 0);
        isPanelShown = false;
    }
}
