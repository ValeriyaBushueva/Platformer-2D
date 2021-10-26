using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class QuestStory : IQuestStory
{
    private readonly List<IQuest> _questCollection;
    
    public bool IsDone => _questCollection.All(value => value.IsCompleted);

    public QuestStory(List<IQuest> questCollection)
    {
        _questCollection = questCollection;
        Subscribe();
        ResetQuest(0);
    }

    private void Subscribe()
    {
        foreach (var quest in _questCollection)
        {
            quest.Completed += OnQuestCompleted;
        }
    }
    
    private void Unsubscribe()
    {
        foreach (var quest in _questCollection)
        {
            quest.Completed -= OnQuestCompleted;
        }
    }

    private void OnQuestCompleted(IQuest quest)
    {
        var index = _questCollection.IndexOf(quest);

        if (IsDone)
        {
            Debug.Log("Story done!");
        }
        else
        {
            ResetQuest(++index);
        }
    }

    private void ResetQuest( int index)
    {
        if (index < 0 || index >= _questCollection.Count) 
            return;
        
        var nextQuest = _questCollection[index];

        if (nextQuest.IsCompleted)
        {
            OnQuestCompleted(nextQuest);
        }
        else
        {
            _questCollection[index].Reset();
        }
    }
    
    public void Dispose()
    {
        Unsubscribe();
    }
}
