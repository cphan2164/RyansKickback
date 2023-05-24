using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    static int comboScore;

    public float jumpHeight = 300f;

    public Rigidbody player;
    public Rigidbody baddie;
    public bool canJump;
    public bool canBaddieJump;
    void Start()
    {
        Instance = this;
        comboScore = 0;
    }

    private void Update()
    {
        scoreText.text = comboScore.ToString();
    }

    private void tryJump()
    {
        if (canJump)
        {
            player.AddForce(Vector3.up * jumpHeight);
        }
    }

    private void tryBaddieJump()
    {
        if (canJump)
        {
            baddie.AddForce(Vector3.up * jumpHeight);
        }
    }

    public static void Hit()
    {
        comboScore += 100;
        Instance.hitSFX.Play();
        Instance.tryJump();
    }

    public static void Miss()
    {
        comboScore -= 100;
        Instance.missSFX.Play();
        Instance.tryBaddieJump();
    }
}
