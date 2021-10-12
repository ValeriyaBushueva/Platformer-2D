using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    [Header("Settings")]
    [SerializeField]
    private float _radius = 0.3f;
    
    [SerializeField]
    private float _groundLevel = 0;
    
    [SerializeField]
    private float _acceleration = -10;

    public float Radius => _radius;

    public float GroundLevel => _groundLevel;

    public float Acceleration => _acceleration;

    public void SetVisible(bool visible)
    {
        _spriteRenderer.enabled = visible;
    }
}
