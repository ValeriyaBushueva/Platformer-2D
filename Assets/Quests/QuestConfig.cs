using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =" QuestConfig", menuName = "Config/ QuestConfig", order = 1)]
public class QuestConfig : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private QuestType _questType;
    
    public int ID => _id;
    
    public QuestType QuestType => _questType;
    
}
public enum QuestType
{
    Switch
}
