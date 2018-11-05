using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public Material[] material;
    private Renderer rend;
    private Color color;
    private float translatez = 5f;
    private float translatex = 1.0f;
    public Text scoreText;
    private int score = 0;
    private int speedScore = 0;
    public bool stop = false;
    public GameObject GameOver;
    public GameObject[] objs;
    public GameObject PauseScreen;
    private bool pause = false;
    private AudioSource[] sounds;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        sounds = GetComponents<AudioSource>();
        sounds[3].Play();
        sounds[3].Pause();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            PauseScreen.SetActive(pause);
            objs[0].SetActive(!pause);
        }
        if (!stop && !pause)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 5* translatex, 0.0f, translatez * Time.deltaTime);
            transform.Translate(Input.acceleration.x * Time.deltaTime * translatex * 2.0f, 0.0f, translatez * Time.deltaTime);
        }
        else if(stop)
        {
            GameOver.SetActive(true);
            Destroy(sounds[4]);
            sounds[3].UnPause();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueLight"))
        {
            if (rend.sharedMaterial.color != material[0].color)
            {
                rend.sharedMaterial = material[0];
                sounds[0].Play();
            }
        }
        if (other.gameObject.CompareTag("RedLight"))
        {
            if (rend.sharedMaterial.color != material[1].color)
            {
                rend.sharedMaterial = material[1];
                sounds[0].Play();
            }
        }
        if (other.gameObject.CompareTag("YellowLight"))
        {
            if (rend.sharedMaterial.color != material[2].color)
            {
                rend.sharedMaterial = material[2];
                sounds[0].Play();
            }
        }

        if (other.gameObject.CompareTag("Blue"))
        {
            Color collColor = other.gameObject.GetComponent<Renderer>().material.color;
            color = rend.material.color;
            if (color == collColor)
            {
                score += 10;
                sounds[1].Play();
                speedScore += 10;
                if (speedScore % 50 == 0)
                {
                    translatez *= 2;
                    translatex += 0.4f;
                }
            }
            else
            {
                score = (int)(score / 2);
                sounds[2].Play();
                stop = score == 0;
            }
            scoreText.text = "Score: " + score + "";
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Red"))
        {
            Color collColor = other.gameObject.GetComponent<Renderer>().material.color;
            color = rend.material.color;
            if (color == collColor)
            {
                score += 10;
                sounds[1].Play();
                speedScore += 10;
                if (speedScore % 50 == 0)
                {
                    translatez *= 2;
                }
            }
            else
            {
                score = (int)(score / 2);
                sounds[2].Play();
                stop = score == 0;
            }
            scoreText.text = "Score: " + score + "";
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Yellow"))
        {
            Color collColor = other.gameObject.GetComponent<Renderer>().material.color;
            color = rend.material.color;
            if (color == collColor)
            {
                score += 10;
                sounds[1].Play();
                speedScore += 10;
                if (speedScore % 50 == 0)
                {
                    translatez *= 2;
                }
            }
            else
            {
                score = (int)(score / 2);
                sounds[2].Play();
                stop = score == 0;
            }
            scoreText.text = "Score: " + score + "";
            Destroy(other.gameObject);
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Blue"))
    //    {
    //        Color collColor = collision.gameObject.GetComponent<Renderer>().material.color;
    //        color = rend.material.color;
    //        if(color == collColor)
    //        {
    //            score += 10;
    //            sounds[1].Play();
    //            speedScore += 10;
    //            if (speedScore % 50 == 0)
    //            {
    //                translatez *= 2;
    //                translatex += 0.4f;
    //            }
    //        }
    //        else
    //        {
    //            score = (int)(score / 2);
    //            sounds[2].Play();
    //            stop = score == 0;
    //        }
    //        scoreText.text = "Score: " + score + "";
    //        Destroy(collision.gameObject);
    //    }
    //    if (collision.gameObject.CompareTag("Red"))
    //    {
    //        Color collColor = collision.gameObject.GetComponent<Renderer>().material.color;
    //        color = rend.material.color;
    //        if (color == collColor)
    //        {
    //            score += 10;
    //            sounds[1].Play();
    //            speedScore += 10;
    //            if (speedScore % 50 == 0)
    //            {
    //                translatez *= 2;
    //            }
    //        }
    //        else
    //        {
    //            score = (int)(score / 2);
    //            sounds[2].Play();
    //            stop = score == 0;
    //        }
    //        scoreText.text = "Score: " + score + "";
    //        Destroy(collision.gameObject);
    //    }
    //    if (collision.gameObject.CompareTag("Yellow"))
    //    {
    //        Color collColor = collision.gameObject.GetComponent<Renderer>().material.color;
    //        color = rend.material.color;
    //        if (color == collColor)
    //        {
    //            score += 10;
    //            sounds[1].Play();
    //            speedScore += 10;
    //            if (speedScore % 50 == 0)
    //            {
    //                translatez *= 2;
    //            }
    //        }
    //        else
    //        {
    //            score = (int)(score / 2);
    //            sounds[2].Play();
    //            stop = score == 0;
    //        }
    //        scoreText.text = "Score: " + score + "";
    //        Destroy(collision.gameObject);
    //    }
    //}

    public void Pause()
    {
        pause = true;
        sounds[4].Pause();
        sounds[3].UnPause();
    }

    public void Resume()
    {
        pause = false;
        sounds[3].Pause();
        sounds[4].UnPause();
    }
}
