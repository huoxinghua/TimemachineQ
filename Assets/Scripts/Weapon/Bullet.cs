
using UnityEngine;

public class Bullet : PoolObject
{
    //[SerializeField] string hitEffectName = "BigExplosion";

    private void OnCollisionEnter2D(Collision2D other)
    {
       // Explosion effect = (Explosion)PoolManager.Instance.Spawn(hitEffectName);
        //effect.transform.position = transform.position;
        //effect.transform.rotation = transform.rotation;
        DeSpawn();

    }
}