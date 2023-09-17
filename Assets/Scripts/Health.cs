using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Health : MonoBehaviour
{
    public static Health Instance;

    [SerializeField] private CinemachineVirtualCamera VCam;

    private CinemachineBasicMultiChannelPerlin ChannelPerlin;

    public float HP = 30;

    [Header("Shake Variables")]

    [SerializeField] private float Frequency;

    [SerializeField] private float Amplitude;

    [SerializeField] private float InvincibilityTime;

    [SerializeField] private float ResetShakeTimer;

    [Space]
    [Header("Death Variables")]

    public GameObject DeathUI;

    [SerializeField] private AudioClip DeathSFX;

    [SerializeField] private AudioClip DamageTakenSFX;

    [Space]
    [Header("Health Variables")]

    [SerializeField] private ParticleSystem ParticleSystem;

    [SerializeField] private Image HeartBar;

    [SerializeField] private Image FullHeartBar;

    [SerializeField] private AudioSource AudioSource;

    private Animator HealthAnimator;

    private bool CanTakeDamage = true;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Initialize();
    }
    private void Initialize()
    {
        HP = SaveManager.Instance.GetSaveData.GetHealth;
        FullHeartBar.fillAmount = HP / SaveManager.Instance.GetSaveData.GetMaxHealth;
        HeartBar.fillAmount = HP / SaveManager.Instance.GetSaveData.GetMaxHealth;

        HealthAnimator = HeartBar.GetComponent<Animator>();
        ChannelPerlin = VCam.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();
    }

    public IEnumerator TakeDamage(int Damage, float JumpMultiplier, bool ShouldGetInvincibility)
    {
        if (!CanTakeDamage) yield return null;

        if (ShouldGetInvincibility)
        {
            CanTakeDamage = false;
            StartCoroutine(Damageable());
        }
        HealthAnimator.Play("Damage");
        AudioSource.PlayOneShot(DamageTakenSFX);
        HP -= Damage;
        HeartBar.fillAmount = HP / SaveManager.Instance.GetSaveData.GetMaxHealth;
        ParticleSystem.Play();
        Shake(Amplitude, Frequency);
        if (HP == 0)
        {
            Die();
        }
        AddFeedbackOnDamage(JumpMultiplier);

        yield return null;

    }

    private static void AddFeedbackOnDamage(float JumpMultiplier)
    {
        MovementScript.Instance.rb.velocity = Vector2.zero;
        MovementScript.Instance.rb.angularVelocity = 0f;
        MovementScript.Instance.rb.AddForce(MovementScript.Instance.JumpHeight * JumpMultiplier * Vector2.up, ForceMode2D.Impulse);
    }

    private void Die()
    {
        DeathUI.SetActive(true);
        AudioSource.PlayOneShot(DeathSFX);
        MovementScript.Instance.canMove = false;
    }

    public IEnumerator ResetShake()
    {
        float ElapsedTime = 0f;

        while(ElapsedTime <= ResetShakeTimer)
        {
            ElapsedTime += Time.deltaTime;
            ChannelPerlin.m_AmplitudeGain = Mathf.Lerp(Amplitude, 0, ElapsedTime / ResetShakeTimer);
            ChannelPerlin.m_FrequencyGain = Mathf.Lerp(Frequency, 0, ElapsedTime / ResetShakeTimer);
            yield return null;
        }

        yield return null;
    }

    void Shake(float amplitude, float frequency)
    {
        ChannelPerlin.m_AmplitudeGain = amplitude;
        ChannelPerlin.m_FrequencyGain = frequency;
        StartCoroutine(ResetShake());
    }
    IEnumerator Damageable()
    {
        float ElapsedTime = 0;
        while(ElapsedTime < InvincibilityTime)
        {
            ElapsedTime += Time.deltaTime;
            yield return null;
        }
        CanTakeDamage = true;
        yield return null;
    }
}
