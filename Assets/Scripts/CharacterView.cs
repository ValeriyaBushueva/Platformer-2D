using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [Header("Settings")] 
    [SerializeField] private float _walkSpeed = 1f;
    [SerializeField] private float _animationSpeed = 3f;
    [SerializeField] private float _jumpStartSpeed = 1.5f;
    [SerializeField] private float _movingThresh = 0.1f;
    [SerializeField] private float _flyThresh = 0.4f;
    [SerializeField] private  float _grounLevel = 0.2f;
    [SerializeField] private float _acceleration = -9.8f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private GroundChecker _groundChecker;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public float WalkSpeed => _walkSpeed;

    public float AnimationSpeed => _animationSpeed;

    public float JumpStartSpeed => _jumpStartSpeed;

    public float MovingThresh => _movingThresh;

    public float FlyThresh => _flyThresh;

    public float GroundLevel => _grounLevel;

    public float Acceleration => _acceleration;

    public Vector3 Position
    {
        get => _rigidbody2D.position;
        set => _rigidbody2D.MovePosition(value);
    }

    public bool IsGrounded => _groundChecker.IsOverGround;

    public Vector2 Velocity
    {
        get => _rigidbody2D.velocity;
        set => _rigidbody2D.velocity = value;
    }
}
