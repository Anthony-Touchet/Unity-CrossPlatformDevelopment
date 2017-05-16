﻿using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "LootTable")]
public class LootTable : ScriptableObject {

    [Serializable]
    public class ItemChance
    {
        public Item item;
        [Range(0,100)]
        public uint minChance;
        [Range(0, 100)]
        public uint maxChance;
    }

    public List<ItemChance> itemChancesList;

    public Item DropLoot()
    {
        var chance = UnityEngine.Random.Range(0, 100);

        foreach (var i in itemChancesList)
        {
            if (chance < i.minChance || chance > i.maxChance) continue;
            Debug.Log(i.item._itemName);
            return i.item; //If Want only one item to drop, Uncomment
        }
        Debug.Log("No Loot");
        return null;
    }

#if UNITY_EDITOR

    [CustomEditor(typeof(LootTable))]
    public class LootTableInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var lt = (LootTable)target;
            if (GUILayout.Button("Drop Loot"))
                lt.DropLoot();

            foreach (var i in lt.itemChancesList)
            {
                if (i.minChance >= i.maxChance)
                    i.maxChance = i.minChance;
            }
        }
    }

#endif
}
