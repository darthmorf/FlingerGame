using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDamage : MonoBehaviour
{
    public float maxHealth = 20f;
    public float health = 20f;
    public bool dog = false;

    private SpriteRenderer sr;
    private AudioSource rs;
    private Sprite mainSprite;
    [SerializeField] private Sprite brokenSprite;
    [SerializeField] private Sprite woofSprite;
    [SerializeField] private AudioClip[] woofs;

    private float woofTimer = 0f;
    private float woofLength = 0f;
    private bool woofing = false;

    void Start()
    {
        if (dog)
        {
            sr = GetComponent<SpriteRenderer>();
            rs = GetComponent<AudioSource>();
            mainSprite = sr.sprite;
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        float strength = collision.relativeVelocity.magnitude;

        flingerBehaviour fb = collision.gameObject.GetComponent<flingerBehaviour>();
        if (fb != null)
        {
            fb.OnHit();
        }

        if (strength > 4)
        {
            health -= strength;
            if (dog)
                PlayRandomWoof();
        }

        if (health <= maxHealth / 2 && brokenSprite != null)
        {
            sr.sprite = brokenSprite;
        }

        if (health <= 0 && !woofing)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
                child.parent = null;
            }
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (woofing)
        {
            woofTimer += Time.deltaTime;

            if (woofTimer >= woofLength)
            {
                woofTimer = 0f;
                woofing = false;
                sr.sprite = mainSprite;
            }
        }
    }

    public void PlayRandomWoof()
    {
        if (woofing || !dog)
            return;

        woofing = true;
        sr.sprite = woofSprite;

        rs.clip = woofs[Random.Range(0, woofs.Length)];
        woofLength = rs.clip.length;
        rs.Play();
    }
}
