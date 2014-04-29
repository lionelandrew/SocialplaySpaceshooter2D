using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadSceneContainers : MonoBehaviour 
{
    public List<ContainerItemLoader> containerLoaders = new List<ContainerItemLoader>();

	// Use this for initialization
	void Start () 
    {
        Debug.Log("startload");
        foreach (ContainerItemLoader container in containerLoaders) 
        {
            container.LoadItems();
        }
	}
}
