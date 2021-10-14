using System.Collections.Generic;
using UnityEngine;

public class Lessons : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _background;
    [SerializeField] private CharacterView _characterView;
    [SerializeField] private SpriteAnimationConfig _spriteAnimationConfig;
    
    [SerializeField] private CannonView _cannonView;

    [SerializeField] private Transform _muzzleTransform;
    
    [SerializeField] private List<BulletView> _bulletsView;
    [SerializeField] private List<CoinView> _coinViews;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroWalker _mainHeroWalker;
    private AimingMuzzle _aimingMuzzle;
    private BulletEmitter _bulletsEmitter;
    private CoinsManager _coinsManager;
    
    
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletsEmitter = new BulletEmitter(_bulletsView, _muzzleTransform.transform);
        _coinsManager = new CoinsManager(_coinViews, _spriteAnimator);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _mainHeroWalker.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        _coinsManager?.Dispose();
    }
}
