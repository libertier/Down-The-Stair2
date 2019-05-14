using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Groundmanager : MonoBehaviour
{
    
    readonly float initPosotionY = 0;
    readonly int Max_Ground_Count = 20;//最大地板數量readonly為常數(?)
    readonly int Min_Ground_Count_Under_Player = 8;//玩家下方最小地板數量
    static int groundNumber = -1;
    readonly float leftBorder = -3;//左邊界
    readonly float rightBorder = 3;//右邊界
    [Range(1, 6)] public float spacingY;
    [Range(1, 20)] public float singleFloorHeight;
    public List<Transform> grounds;
    public Transform player;
    public int a=0;
    public Text displayCountFloor;
    public Text displayCounthp;
    public double b = 0;
    void Start()
    {

        grounds = new List<Transform>();
        for (int i = 0; i < Max_Ground_Count; i++)
        {

            switch (a)
            {
                case 1:
                    SpawnGround1();
                    break;
                case 2:
                    SpawnGround2();
                    break;
                case 3:
                    SpawnGround3();
                    break;
                case 4:
                    SpawnGround4();
                    break;
                case 5:
                    SpawnGround5();
                    break;
                case 6:
                    SpawnGround6();
                    break;
                default:
                    SpawnGround2();
                    break;
            }
            a = Random.Range(1, 9);
        }
    }
    public void ControlSpawnGround()//控制產生地板
    {
        int groundCountUnderPlayer = 0;
        foreach (Transform ground in grounds)
        {
            if (ground.position.y < player.position.y)
            {
                groundCountUnderPlayer++;
            }
        }

        if (groundCountUnderPlayer < Min_Ground_Count_Under_Player)
        {
            a = Random.Range(1, 9);
            switch (a)
            {
                case 1:
                    SpawnGround1();
                    break;
                case 2:
                    SpawnGround2();
                    break;
                case 3:
                    SpawnGround3();
                    break;
                case 4:
                    SpawnGround4();
                    break;
                case 5:
                    SpawnGround5();
                    break;
                case 6:
                    SpawnGround6();
                    break;
                default:
                    SpawnGround2();
                    break;
            }
            b = b + 0.2;
            ControlGroundsCount();
        }

    }

    float newGroundPosotionX()
        {
            if (grounds.Count == 0)
            {
                return 0;
            }
            return Random.Range(leftBorder, rightBorder);
        }
        //計算新地板Y座標
        float newGroundPosotionY()
        {
            if (grounds.Count == 0)
            {
                return initPosotionY;
            }
            int lowerIndex = grounds.Count - 1;
            return grounds[lowerIndex].transform.position.y - spacingY;
        }
        //產生單一地板

        void SpawnGround1()
        {
            
            GameObject newGround = Instantiate(Resources.Load<GameObject>("nails"));
            newGround.transform.position = new Vector2(newGroundPosotionX(), newGroundPosotionY());
            grounds.Add(newGround.transform);
        }
        void SpawnGround2()
        {
           
            GameObject newGround2 = Instantiate(Resources.Load<GameObject>("normal"));
            newGround2.transform.position = new Vector2(newGroundPosotionX(), newGroundPosotionY());
            grounds.Add(newGround2.transform);
        }
        void SpawnGround3()
        {
            
            GameObject newGround3 = Instantiate(Resources.Load<GameObject>("trampoline"));
            newGround3.transform.position = new Vector2(newGroundPosotionX(), newGroundPosotionY());
            grounds.Add(newGround3.transform);

        }
        void SpawnGround4()
        {
            
            GameObject newGround4 = Instantiate(Resources.Load<GameObject>("conveyor_left"));
            newGround4.transform.position = new Vector2(newGroundPosotionX(), newGroundPosotionY());
            grounds.Add(newGround4.transform);
        }
        void SpawnGround5()
        {

            GameObject newGround5 = Instantiate(Resources.Load<GameObject>("conveyor_right"));
            newGround5.transform.position = new Vector2(newGroundPosotionX(), newGroundPosotionY());
            grounds.Add(newGround5.transform);
        }
    void SpawnGround6()
    {

        GameObject newGround6 = Instantiate(Resources.Load<GameObject>("fake"));
        newGround6.transform.position = new Vector2(newGroundPosotionX(), newGroundPosotionY());
        grounds.Add(newGround6.transform);
    }


    void ControlGroundsCount()
    {
        if (grounds.Count > Max_Ground_Count)
        {
            Destroy(grounds[0].gameObject);
            grounds.RemoveAt(0);
        }
    }

    void DisplayCountFloor()
    {
        
        displayCountFloor.text = "地下" +b.ToString("0000") + "樓";
    }
    void DisplayCounthp()
    {

        displayCounthp.text = "生命:"+Player.HP.ToString("00");
    }
    void Update()
        {
        ControlSpawnGround();
        DisplayCountFloor();
        DisplayCounthp();
    }
    }

