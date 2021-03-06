﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class flingerBehaviour : MonoBehaviour
{
    private LineRenderer lr;
    private Camera cam;
    private GameObject line;
    private Rigidbody2D rb;
    private Sprite mainSprite;
    private SpriteRenderer sr;
    private AudioSource rs;
    [SerializeField] private Sprite meowSprite;
    [SerializeField] private AudioClip[] meows;

    private Vector2 launchVelocity = new Vector2(6f, 12f);
    public bool space = true;
    private float meowTimer = 0f;
    private float meowLength = 0f;
    private bool meowing = false;

    void Start()
    {
        line = new GameObject();        
        lr = line.AddComponent<LineRenderer>();
        rs = GetComponent<AudioSource>();
        lr.material = new Material(Shader.Find("Sprites/Default"));
        sr = GetComponent<SpriteRenderer>();
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 0.5f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0.5f, 0.0f), new GradientAlphaKey(0.25f, 0.5f), new GradientAlphaKey(0f, 1f) }
        );
        lr.colorGradient = gradient;
        lr.startWidth = 0.1f;
        lr.endWidth = 0.01f;

        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();

        mainSprite = sr.sprite;
    }

    void Update()
    {
        line.transform.position = gameObject.transform.position;
        //Debug.Log(gameObject.GetComponent<Rigidbody2D>().velocity.magnitude);
        if (Input.GetMouseButton(0) && gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 3f)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            launchVelocity = ((Vector2) transform.position - mousePos) * 4;

            drawArc();
        }
        else if (!Input.GetMouseButton(0))
        {
            lr.enabled = false;
        }

        if (Input.GetMouseButtonUp(0) && rb.velocity.sqrMagnitude < 1f)
        {
            Launch();
            PlayRandomMeow();
        }

        if (meowing)
        {
            meowTimer += Time.deltaTime;

            if (meowTimer >= meowLength)
            {
                meowTimer = 0f;
                meowing = false;
                sr.sprite = mainSprite;
            }
        }
    }

    void Launch()
    {
        rb.velocity = launchVelocity;    
    }    

    Vector2 calculatePosition(float elapsedTime)
    {
        Vector2 pos = gameObject.transform.position;
        return Physics2D.gravity * elapsedTime * elapsedTime * 0.5f + launchVelocity * elapsedTime + pos;
    }

    void drawArc()
    {
        lr.enabled = true;
        int pointCount = 25;
        lr.SetPosition(0, gameObject.transform.position);
        lr.positionCount = pointCount;
        for (int i = 1; i < pointCount; i++)
        {
            lr.SetPosition(i, calculatePosition(0.05f * i));
        }        
    }

    public void OnHit()
    {
        PlayRandomMeow();
    }

    public void PlayRandomMeow()
    {
        if (meowing)
            return;
        
        meowing = true;
        sr.sprite = meowSprite;

        PlayRandomMeow();

        rs.clip = meows[Random.Range(0, meows.Length)];
        meowLength = rs.clip.length;
        rs.Play();
    }
}
