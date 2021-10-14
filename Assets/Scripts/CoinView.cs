using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinView : MonoBehaviour
{
    [SerializeField] 
    private SpriteRenderer _spriteRenderer;
    

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    
    public Action<CoinView> OnLevelObjectContact { get; set; }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var levelObject = collider.gameObject.GetComponent<CharacterView>();
        
        if (levelObject != null)
            OnLevelObjectContact?.Invoke(this);
    }
   
}
