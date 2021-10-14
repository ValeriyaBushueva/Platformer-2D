using System;
using System.Collections.Generic;
using Object = UnityEngine.Object;

public class CoinsManager : IDisposable
{
    private SpriteAnimator _spriteAnimator;
    private List<CoinView> _coinViews;

    public CoinsManager(List<CoinView> coinViews, SpriteAnimator spriteAnimator)
    {
        _spriteAnimator = spriteAnimator;
        _coinViews = coinViews;

        foreach (var coinView in coinViews)
            coinView.OnLevelObjectContact += OnLevelObjectContact;
    }

    private void OnLevelObjectContact(CoinView coinsView)
    {
        if (_coinViews.Contains(coinsView))
        {
            _spriteAnimator.StopAnimation(coinsView.SpriteRenderer);
            Object.Destroy(coinsView.gameObject);
        }
    }

    public void Dispose()
    {
        foreach (var coinView in _coinViews)
            coinView.OnLevelObjectContact -= OnLevelObjectContact;
    }
}