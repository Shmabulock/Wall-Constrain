using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frame : MonoBehaviour {

   // const float OPT_SPEED_DIVISOR = 2170.0f;
    const float OPT_SPEED_DIVISOR = 8000.0f;
    const int WALL_UNSCALED_SIZE = 50;

   // const float X_RATIO = 0.9f;

    float x_ratio;
    float y_ratio;

    [SerializeField] GameObject m_frame;

    GameObject m_leftWall;
    Vector3 leftWallOldPos;
    Vector3 leftWallPos;

    GameObject m_rightWall;
    Vector3 rightWallOldPos;
    Vector3 rightWallPos;

    GameObject m_upWall;
    Vector3 upWallOldPos;
    Vector3 upWallPos;

    GameObject m_downWall;
    Vector3 downWallOldPos;
    Vector3 downWallPos;

    float speedX;
    float speedY;

    float multiplier = 1.0f;
    int counter = 1;
    float percent = 0.0f;

    bool isFullSpaceBonusCollected = false;
    public bool IsFullSpaceBonusCollected
    {
        set
        {
            isFullSpaceBonusCollected = value;
        }
    }

    bool isWallFreezeBonusCollected = false;
    public bool IsWallFreezeBonusCollected
    {
        set
        {
            isWallFreezeBonusCollected = value;
        }
    }

    float timer = 0;
    float randTime;

    [SerializeField] Transform gameOverTrigger;

    [SerializeField] wallFreezeBonusSpawner wallFreezeSpawner;
    [SerializeField] MusicForGameplay music;

    private void Awake()
    {
        GameObject newFrame = Instantiate(m_frame);
        newFrame.name = "frame";
        m_leftWall = newFrame.transform.GetChild(0).gameObject;
        m_rightWall = newFrame.transform.GetChild(1).gameObject;
        m_downWall = newFrame.transform.GetChild(2).gameObject;
        m_upWall = newFrame.transform.GetChild(3).gameObject;  
    }

    void Start()
    {
       

        speedY = 0.24f;
        speedX = speedY / Screen.height * Screen.width;

        // speedX = speedX * 0.9f / X_RATIO;
        // speedY = speedY * 1.6f / y_ratio;

        // speedY = speedY / 16 * Camera.main.orthographicSize

        //speedX = Screen.width / OPT_SPEED_DIVISOR;
        //  speedY = Screen.height / OPT_SPEED_DIVISOR;




        randTime = Random.Range(-1f, 1f);

       // Camera.main.orthographicSize = ((float)Screen.width / ((float)Screen.width / (float)Screen.height * 200.0f)) - 0.3f;

        x_ratio = Camera.main.orthographicSize/10.0f;
        y_ratio = x_ratio * Screen.height / Screen.width;


        //Setting walls positions
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.z = 0;
        m_leftWall.transform.position = cameraPos + Vector3.left * 2 * Camera.main.orthographicSize / Screen.height * Screen.width;
        m_rightWall.transform.position = cameraPos + Vector3.right * 2 * Camera.main.orthographicSize / Screen.height * Screen.width;
        m_upWall.transform.position = cameraPos + Vector3.up * 2 * Camera.main.orthographicSize;
        m_downWall.transform.position = cameraPos + Vector3.down * 2 * Camera.main.orthographicSize;



        //  Debug.Log(camera.orthographicSize);
        ////scaling
        //

        Vector2 tmp = new Vector2(Camera.main.orthographicSize / Screen.height * Screen.width * 4, Camera.main.orthographicSize * 4);
        m_leftWall.transform.localScale = tmp;
        m_rightWall.transform.localScale = tmp;
        m_upWall.transform.localScale = tmp;
        m_downWall.transform.localScale = tmp;


        // m_leftWall.transform.position = Vector3.one* Camera.main.orthographicSize;

       

        leftWallPos = m_leftWall.transform.position;
        rightWallPos = m_rightWall.transform.position;
        upWallPos = m_upWall.transform.position;
        downWallPos = m_downWall.transform.position;


        //m_leftWall.transform.position =  new Vector3(camera.transform.position
    }

    void FixedUpdate()
    {
        if (!isWallFreezeBonusCollected)
        {
            m_leftWall.transform.position += Vector3.right * speedX * multiplier * Time.fixedDeltaTime;
            m_rightWall.transform.position += Vector3.left * speedX * multiplier * Time.fixedDeltaTime;
            m_upWall.transform.position += Vector3.down * speedY * multiplier * Time.fixedDeltaTime;
            m_downWall.transform.position += Vector3.up * speedY * multiplier * Time.fixedDeltaTime;

            counter++;
            if (counter % 1000 == 0)
            {
                counter = 1;
                multiplier += 0.05f;
            }
        }
        else
        {//freeze BONUS

            if(timer  < 3f +randTime)
            {
                timer += Time.fixedDeltaTime;
            }
            else
            {
                wallFreezeSpawner.setBonusCollected(false);
                wallFreezeSpawner.PlayWallFreezeEnd();
                timer = 0;
                randTime = Random.Range(-1f, 1f);
            }
        }//freeze BONUS



        {// for full space bonus;
            if (!isFullSpaceBonusCollected)
            {
 
                leftWallOldPos = m_leftWall.transform.position;
                rightWallOldPos = m_rightWall.transform.position;
                upWallOldPos = m_upWall.transform.position;
                downWallOldPos = m_downWall.transform.position;

            }
            if (isFullSpaceBonusCollected)
            {
                if(music.source.isPlaying)
                {
                    music.source.Stop();
                }
                percent += 0.01f;
                m_rightWall.transform.position = Vector3.Lerp(rightWallOldPos, rightWallPos, percent);
                m_leftWall.transform.position = Vector3.Lerp(leftWallOldPos, leftWallPos, percent);
                m_upWall.transform.position = Vector3.Lerp(upWallOldPos, upWallPos, percent);
                m_downWall.transform.position = Vector3.Lerp(downWallOldPos, downWallPos, percent);
            }
            if (percent > 1.0f)
            {
                if (!music.source.isPlaying)
                {
                    music.source.Play();
                }
                percent = 0f;
                isFullSpaceBonusCollected = false;

            }
        } // for full space bonus;
        
    }

    public void ThrowWallsAway(float superModScaler = 1.0f)
    {
        float bonusPower = 10.0f;

        m_leftWall.transform.position += Vector3.left * bonusPower * superModScaler * x_ratio/50;
        m_rightWall.transform.position += Vector3.right * bonusPower * superModScaler * x_ratio/50;

        m_upWall.transform.position += Vector3.up * bonusPower * superModScaler * y_ratio/50;
        m_downWall.transform.position += Vector3.down * bonusPower * superModScaler * y_ratio/50;
    }

    public void EndGame()
    {
       /* m_leftWall.GetComponent<SpriteRenderer>().enabled = false;
        m_rightWall.GetComponent<SpriteRenderer>().enabled = false;
        m_upWall.GetComponent<SpriteRenderer>().enabled = false;
        m_downWall.GetComponent<SpriteRenderer>().enabled = false;*/

        m_leftWall.transform.position = gameOverTrigger.position;
        m_rightWall.transform.position = gameOverTrigger.position;
        m_upWall.transform.position = gameOverTrigger.position;
        m_downWall.transform.position = gameOverTrigger.position;

    }

}