using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ExcelPlayerData : ScriptableObject
{
    public List<PlayerData> Player; // Replace 'EntityType' to an actual type that is serializable.
}
