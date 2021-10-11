using UnityEngine;

public class MainHeroWalker
{
    private const string Horizontal = nameof(Horizontal);

    private const string Vertical = nameof(Vertical);

    private CharacterView _characterView;

    private SpriteAnimator _spriteAnimator;

    private float _yvelocity;

    private Vector2 CharacterVelocity
    {
        get => _characterView.Velocity;
        set => _characterView.Velocity = value;
    }

    public Vector3 CharacterPosition
    {
        get => _characterView.Position;
        set => _characterView.Position = value;
    }

    public MainHeroWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;
    }

    public void Update()
    {
        var doJump = Input.GetAxis(Vertical) > 0;
        var xAxisInput = Input.GetAxis(Horizontal);

        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MovingThresh;

        if (isGoSideWay)
        {
            GoSideWay(xAxisInput);
        }

        if (_characterView.IsGrounded)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.walk : Track.idle, true,
                _characterView.AnimationSpeed);

            if (doJump && Mathf.Approximately(CharacterVelocity.y, 0))
            {
                CharacterVelocity = CharacterVelocity.SetY(_characterView.JumpStartSpeed);
            }
        }
        else
        {
            LandingCharacter();
        }

        void GoSideWay(float xAxisInput)
        {
            CharacterPosition +=
                Vector3.right * Time.deltaTime * _characterView.WalkSpeed * ((xAxisInput < 0) ? -1 : 1);
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;
        }
    }

    private void LandingCharacter()
    {
        _yvelocity += _characterView.Acceleration * Time.deltaTime;
        if (Mathf.Abs(_yvelocity) > _characterView.FlyThresh)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump, true,
                _characterView.AnimationSpeed);
        }

        //CharacterPosition += Vector3.up *(Time.deltaTime * _yvelocity);
    }
}