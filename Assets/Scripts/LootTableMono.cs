﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LootTableMono : MonoBehaviour
{
    public LootTable lootTable;
    public GameObject itemPrefab;

	// Use this for initialization
	void Start ()
	{
	    if (lootTable == null)
	    {
	        Debug.LogError("LootTable not assigned");
            return;
	    }
	    lootTable = Instantiate(lootTable);
	}

    [ContextMenu("Drop Loot")]
    public void DropLoot()
    {
        var item = lootTable.DropLoot();
        if (item == null)
            return;

        var itemObject = Instantiate(itemPrefab, transform.position, transform.rotation);
        var itemBehavior = itemObject.GetComponent<ItemBehaviour>();
        itemBehavior.item_config = item;
    }
}