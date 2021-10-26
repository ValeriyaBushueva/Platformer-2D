using System;

public class Quest : IQuest
{
    public event Action<IQuest> Completed;
    public bool IsCompleted { get; private set; }
    private readonly QuestObjectView _view;
    private readonly IQuestModel _model;

    private bool _active;

    public Quest(QuestObjectView questObjectView, IQuestModel questModel)
    {
        _view = questObjectView;
        _model = questModel;
    }

    private void OnContact(CharacterView characterView)
    {
        var completed = _model.TryComplete(characterView.gameObject);
        if (completed)
        {
            Complete();
        }
    }

    private void Complete()
    {
        if (!_active)
        {
            return;
        }
        _active = false;
        IsCompleted = true;
        _view.OnLevelObjectEnter -= OnContact;
        _view.ProcessComplete();
        OnCompleted();
    }

    private void OnCompleted()
    {
        Completed?.Invoke(this);
    }

    public void Reset()
    {
        if (_active)
        {
            return;
        }
        
        _active = true;
        IsCompleted = false;
        _view.OnLevelObjectEnter += OnContact;
        _view.ProcessActivate();
    }

    public void Dispose()
    {
        _view.OnLevelObjectEnter -= OnContact;
    }
}
