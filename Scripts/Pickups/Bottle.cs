using UnityEngine;

public class Bottle : Pickup
{
    [SerializeField] float timer = 1f;

    PlayerCollisionHandler collisionHandler;

    public void Init(PlayerCollisionHandler collisionHandler) 
    // Collision handler consistent across all instances of bottle
    {
        this.collisionHandler = collisionHandler;
        Debug.Log(collisionHandler);
    }

    protected override void OnPickup()
    {
        collisionHandler.makeInvincible(timer); // Method called within collision handler
    }
}
