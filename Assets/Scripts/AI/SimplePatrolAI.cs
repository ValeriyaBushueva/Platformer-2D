using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimplePatrolAI
{
    private SimplePatrolAIModel _simplePatrol;
    private Rigidbody2D _rigidbodyEnemy;
    
   public SimplePatrolAI(SimplePatrolAIModel simplePatrol, Rigidbody2D rigidbodyEnemy )
   {
       _simplePatrol = simplePatrol;
       _rigidbodyEnemy = rigidbodyEnemy;
   }

  public void FixedUpdate()
  {
      var newVelocity = _simplePatrol.CalculateVelocity(_rigidbodyEnemy.position) * Time.fixedDeltaTime;
      _rigidbodyEnemy.velocity = newVelocity;
  }
}
