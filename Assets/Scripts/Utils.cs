using UnityEngine;

public  static class Utils 
{
   public static Vector3 Change(this Vector3 org, float? x = null, float? y = null, float? z = null)
   {
      return new Vector3(x ?? org.x, y ?? org.y, z ?? org.z);
   }

   public static Vector2 Change(this Vector2 org, object x = null, object y = null)
   {
      return new Vector2(x == null ? org.x : (float) x, y == null ? org.y : (float) y);
   }
}
  