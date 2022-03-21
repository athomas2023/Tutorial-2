using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public float timeInvincible = 2.0f;
    public int health { get { return currentHealth; } }
    public int numOfHearths;
    int currentHealth;
    bool isInvincible;
    float invincibleTimer;


    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite brokenHeart;

    public Animator animator;
    public string sceneName;

    public AudioClip Hitsound;
    public AudioClip ZeroHealth;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        


        for (int i = 0; i < hearts.Length; i++)
        {
            if(i<health)
            {
                hearts[i].sprite = FullHeart;
            }

            else
            {
                hearts[i].sprite = brokenHeart;
            }

            if(i < numOfHearths)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }


            
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            PlaySound(Hitsound);
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);


        if (health <= 0)
        {
            StartCoroutine(LoadScene());   
        }
    }

    IEnumerator LoadScene()
    {
        animator.SetTrigger("FadeEnd");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);

    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDector")
        {
            StartCoroutine(LoadScene());
        }
    }   

}

