using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocialPlay.ItemSystems;
using System;

public class ItemDrop : MonoBehaviour
{
    public Transform dropParentObject;
    public IGameObjectAction postDropObjectAction;

    public void DropItemIntoWorld(ItemData item, Vector3 dropPosition, GameObject dropModelDefault)
    {
        if (item != null)
        {
            item.AssetBundle(
                (UnityEngine.Object bundleObj) =>
                {
                    GameObject dropObject;

                    if (bundleObj != null)
                        dropObject = GameObjectInitilizer.initilizer.InitilizeGameObject(bundleObj);
                    else
                        dropObject = GameObjectInitilizer.initilizer.InitilizeGameObject(dropModelDefault);

                    ItemData itemData = dropObject.AddComponent<ItemData>();

                    itemData.SetItemData(item);


                    ItemComponentInitalizer.InitializeItemWithComponents(dropObject.GetComponent<ItemData>(), AddComponetTo.prefab);

                    dropObject.transform.position = dropPosition;
                    dropObject.transform.parent = dropParentObject.transform;

                    if (postDropObjectAction != null)
                        postDropObjectAction.DoGameObjectAction(dropObject);
                }
            );
        }
    }
}
