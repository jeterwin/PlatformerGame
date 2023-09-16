using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Health : MonoBehaviour
{
    public static Health Instance;

    [SerializeField] CinemachineVirtualCamera VCam;

    CinemachineBasicMultiChannelPerlin ChannelPerlin;

    public float HP = 30;

    [Header("Shake Variables")]

    [SerializeField] float Frequency;

    [SerializeField] float Amplitude;

    [SerializeField] float InvincibilityTime;

    [SerializeField] float ResetShakeTimer;

    [Space]
    [Header("Death Variables")]

    public GameObject DeathUI;

    [SerializeField] AudioClip DeathSFX;

    [SerializeField] AudioClip DamageTakenSFX;

    [Space]
    [Header("Health Variables")]

    [SerializeField] ParticleSystem ParticleSystem;

    [SerializeField] Image HeartBar;

    [SerializeField] Image FullHeartBar;

    [SerializeField] AudioSource AudioSource;


    Animator HealthAnimator;

    SaveManager.SaveData SaveData;

    bool CanTakeDamage = true;

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
        SaveData = SaveManager.Instance.GetGameData();
        HP = SaveData.SetHealth;
        FullHeartBar.fillAmount = HP / SaveData.SetMaxHealth;
        HeartBar.fillAmount = HP / SaveData.SetMaxHealth;

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
        HeartBar.fillAmount = HP / SaveData.SetMaxHealth;
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
        MovementScript.Instance.rb.AddForce(Vector2.up * MovementScript.Instance.JumpHeight * JumpMultiplier, ForceMode2D.Impulse);
    }

    private void Die()
    {
        DeathUI.SetActive(true);
        AudioSource.PlayOneShot(DeathSFX);
        MovementScript.Instance.CanMove = false;
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
