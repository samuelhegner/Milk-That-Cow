using System.Collections;
using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class MilkSystem : MonoBehaviour
{
    public int p1Score = 0;
    public int p2Score = 0;
    public float delayTimer;
    private float player1timerRight;
    private float player1timerLeft;
    private float player2timerRight;
    private float player2timerLeft;

    private bool p1Clicked;
    private bool p2Clicked;
    int player1PreviousButton = 1;
    int player2PreviousButton = 1;

    public int milkSpawnAmount = 4;
    public MilkSpawner milkSpawner;
    public float scoreModifier = 1.0f;
    [SerializeField] public TeamInfo team1TeamInfo;
    [SerializeField] public TeamInfo team2TeamInfo;


    
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.RegisterTeam(team1TeamInfo.teamTag, 0);
        ScoreManager.RegisterTeam(team2TeamInfo.teamTag, 1);

        StartCoroutine(MilkClickedP1());
        StartCoroutine(MilkClickedP2());
        
        /*player1timerRight = delayTimer;
        player1timerLeft = delayTimer;
        player2timerRight = delayTimer;
        player2timerLeft = delayTimer;*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void AddOrRemoveMilk(string teamTag, bool addingMilk)
    //{
    //    if (teamTag == team1TeamInfo.teamTag)
    //    {
    //        team1TeamInfo.scoreData.milkCaughtInBucket += (addingMilk) ? 1 : -1;

    //        //RecalulateScore(team1TeamInfo);
    //        ScoreManager.UpdateScoreData(team1TeamInfo.scoreData);
    //    }
    //    else
    //    {
    //        team2TeamInfo.scoreData.milkCaughtInBucket += (addingMilk) ? 1 : -1;

    //        ScoreManager.UpdateScoreData(team2TeamInfo.scoreData);
    //        //RecalulateScore(team2TeamInfo);
    //    }
    //}

    //private void RecalulateScore(TeamInfo teamInfo)
    //{
    //    teamInfo.score = teamInfo.milkCount * scoreModifier;
    //    //Debug.Log(teamInfo.teamTag + " score is: " + teamInfo.score);
    //}


    private IEnumerator MilkClickedP1()
    {
        while (true)
        {
            

            float waitTime;
            
            if (p1Clicked)
            {
                waitTime = delayTimer;
            }
            else
            {
                waitTime = 0;
            }
            

            yield return new WaitForSeconds(waitTime);
            p1Clicked = false;
            if (Input.GetButtonDown("Milk1Right") && player1PreviousButton == 2 && Game_Manager.GameIsActive)
            {

                milkSpawner.SpawnBurst(
                    team1TeamInfo.udderRight,
                    team1TeamInfo.teamTag,
                    milkSpawnAmount
                    );

                ScoreManager.UpdateScoreData(team1TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);

                p1Clicked = true;
                player1PreviousButton = 1;
            }

            if (Input.GetButtonDown("Milk1_Left")&& player1PreviousButton == 1 && p1Clicked == false && Game_Manager.GameIsActive)
            {

                milkSpawner.SpawnBurst(
                    team1TeamInfo.udderLeft,
                    team1TeamInfo.teamTag,
                    milkSpawnAmount
                );

                ScoreManager.UpdateScoreData(team1TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);

                
                p1Clicked = true;
                player1PreviousButton = 2;
            }


        }
    }
    private IEnumerator MilkClickedP2()
    {
        while (true)
        {


            float waitTime;
            
            if (p2Clicked)
            {
                waitTime = delayTimer;
            }
            else
            {
                waitTime = 0;
            }

            yield return new WaitForSeconds(waitTime);
            p2Clicked = false;
            if (Input.GetButtonDown("Milk2_Right") && player2PreviousButton == 2 && Game_Manager.GameIsActive)
            {

                milkSpawner.SpawnBurst(
                    team2TeamInfo.udderRight,
                    team2TeamInfo.teamTag,
                    milkSpawnAmount
                );

                ScoreManager.UpdateScoreData(team2TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);

                p2Clicked = true;
                player2PreviousButton = 1;
            }

            if (Input.GetButtonDown("Milk2_Left")&& player2PreviousButton == 1 && p2Clicked == false && Game_Manager.GameIsActive)
            {

                milkSpawner.SpawnBurst(
                    team2TeamInfo.udderLeft,
                    team2TeamInfo.teamTag,
                    milkSpawnAmount
                );


                ScoreManager.UpdateScoreData(team2TeamInfo.teamTag, ScoreType.milkProduced, milkSpawnAmount);

                p2Clicked = true;
                player2PreviousButton = 2;
            }


        }
    }

    [Serializable]
    public struct TeamInfo
    {
        //public MilkSpawner milkSpawner;
        public Transform udderLeft;
        public Transform udderRight;
        public string teamTag;
        //[HideInInspector] public int milkCount;
        //[HideInInspector] public float score;
        //public ScoreData scoreData;
    }
}
