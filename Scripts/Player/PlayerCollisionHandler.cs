using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject invincibilityStatus;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;
    private float adjustDefaultSpeed = -2f; // Static variable used to reset move speed change after invincibility

    const string hitString = "Hit";
    float cooldownTimer = 0f;
    bool invincible = false;
    float invincibleTimer = 0f;
    float waitTime;
    float difficultyTimer = 0f;

    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void Update() 
    {
        cooldownTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        AdjustDifficulty();
        UpdateInvincibleStatus();
    }

    void OnCollisionEnter(Collision other) 
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }

    void AdjustDifficulty() // Adjusts move speed change per 10 second interval
    {
        if (difficultyTimer < 10) return;

        adjustChangeMoveSpeedAmount -= 0.25f;
        adjustDefaultSpeed -= 0.25f;
        difficultyTimer = 0f;
    }

    public void makeInvincible(float time) // Invincible Mechanic #1: Initiates invincibility timer + effects
    {
        if (waitTime > 0f) return;

        invincible = true;
        adjustChangeMoveSpeedAmount = 0f;
        waitTime = 0f;
        invincibleTimer = time;
    }

    void UpdateInvincibleStatus() // Invincibiliy #2: Updates timer, removes invincibility when valid
    {
        invincibilityStatus.SetActive(invincible);

        if (invincible == false) return;

        waitTime += Time.deltaTime;

        if (waitTime > invincibleTimer)
        {
            waitTime = 0f;
            adjustChangeMoveSpeedAmount = adjustDefaultSpeed; 
            invincible = false;
        }
    }
}
