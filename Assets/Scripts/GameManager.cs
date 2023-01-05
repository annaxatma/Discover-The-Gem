using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    private int gems;
    private int health;
    private int levelIndex = 1;

    public AudioSource SoundEffectSource;
    public AudioSource MusicSource;
    public AudioClip BGM;
    public AudioClip Jump;
    public Text gemsScore;
    public Text healthScore;

    // Start is called before the first frame update
    void Start()
    {
        MusicSource.PlayOneShot(BGM, 0.1f);
        health = 3;
        healthScore.text = health.ToString();
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += SceneManager_onSceneLoaded;
        SceneManager.LoadScene("Level" + levelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            health = 3;
            healthScore.text = health.ToString();
            SoundEffectSource.Stop();
            MusicSource.Stop();
            SceneManager.LoadScene("Lose");
            Destroy(gameObject);
        }
        if (playerController != null)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerController.Move(1);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                playerController.Move(-1);
            }
            else
            {
                playerController.Move(0);
            }
            if (Input.GetKeyDown(KeyCode.W) && playerController.grounded)
            {
                SoundEffectSource.PlayOneShot(Jump, 0.5f);
                playerController.Jump();
            }
        }
    }

    private void SceneManager_onSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("SceneName: " + scene.name);
        playerController = FindObjectOfType<PlayerController>();
        playerController.onCollisionEnter = PlayerController_onCollisionEnter;
    }
    private void PlayerController_onCollisionEnter(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gems++;
            gemsScore.text = gems.ToString();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            health--;
            healthScore.text = health.ToString();
        }
        else if (collision.gameObject.CompareTag("MovePoint"))
        {
            levelIndex++;
            SceneManager.LoadScene("Level" + levelIndex);
        }
        else if (collision.gameObject.CompareTag("Healthpack"))
        {
            Destroy(collision.gameObject);
            health++;
            healthScore.text = health.ToString();
        }
        else if (collision.gameObject.CompareTag("Endpoint"))
        {
            health = 3;
            healthScore.text = health.ToString();
            SceneManager.LoadScene("Win");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            playerController.grounded= true;
        }
    }
}