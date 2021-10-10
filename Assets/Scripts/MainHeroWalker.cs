using UnityEngine;

public class MainHeroWalker
{
   private const string Horizontal = nameof(Horizontal);
   private const string Vertical = nameof(Vertical);

   private CharacterView _characterView;
   private SpriteAnimator _spriteAnimator;

   private float _yvelocity;

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

      if (IsGrounded())
      {
         _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.walk : Track.idle, true, _characterView.AnimationSpeed);

         if (doJump && Mathf.Approximately(_yvelocity, 0))
         {
            _yvelocity = _characterView.JumpStartSpeed;
         }
         else if(_yvelocity < 0)
         {
            _yvelocity = 0;
            MovementCharacter();
         }
      }
      else
      {
         LandingCharacter();
      }

      void GoSideWay( float xAxisInput)
      {
         _characterView.transform.position += Vector3.right * Time.deltaTime * _characterView.WalkSpeed * ((xAxisInput < 0) ? -1 : 1);
         _characterView.SpriteRenderer.flipX = xAxisInput < 0;
      }

      bool IsGrounded()
      {
         return _characterView.transform.position.y <= _characterView.GroundLevel && _yvelocity <= 0;
      }
   }

   private void LandingCharacter()
   {
      _yvelocity += _characterView.Acceleration * Time.deltaTime;
      if (Mathf.Abs(_yvelocity) > _characterView.FlyThresh)
      {
         _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump,  true, _characterView.AnimationSpeed);
      }
      _characterView.transform.position += Vector3.up *(Time.deltaTime * _yvelocity);
   }

   private void MovementCharacter()
   {
      _characterView.transform.position.Change(y: _characterView.GroundLevel);
   }
}
