using System.Collections.Generic;
using Pathfinding;
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
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private AIConfig _config;
    
    // [Header("Protector AI")]
    // [SerializeField] 
    // private AIDestinationSetter _protectorAIDestinationSetter;
    //
    // //[SerializeField] private AIPatrolPath _protectorAIPatrolPath;
    //
    // [SerializeField] 
    // private LevelObjectTrigger _protectedZoneTrigger;
    //
    // [SerializeField] 
    // private Transform[] _protectorWaypoints;
    
    private SimplePatrolAI _simplePatrolAI;
    
    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroWalker _mainHeroWalker;
    private AimingMuzzle _aimingMuzzle;
    private BulletEmitter _bulletsEmitter;
    private CoinsManager _coinsManager;
    
    // private ProtectorAI _protectorAI;
    // private ProtectedZone _protectedZone;
    
    
    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroWalker = new MainHeroWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_cannonView.transform, _characterView.transform);
        _bulletsEmitter = new BulletEmitter(_bulletsView, _muzzleTransform.transform);
        _coinsManager = new CoinsManager(_coinViews, _spriteAnimator);
       // _simplePatrolAI = new SimplePatrolAI(new SimplePatrolAIModel(_config), _enemyView.Rigidbody);
       
      // _protectorAI = new ProtectorAI(_characterView, new PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter, _protectorAIPatrolPath);
      // _protectorAI.Init();
      
       // _protectedZone = new ProtectedZone(_protectedZoneTrigger, new List<IProtector>{ _protectorAI });
       // _protectedZone.Init();
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
       // _simplePatrolAI.FixedUpdate();
    }

    private void OnDestroy()
    {
        // _protectorAI.Deinit();
        // _protectedZone.Deinit();
        _coinsManager?.Dispose();
    }
}
