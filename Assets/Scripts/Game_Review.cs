using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Review : MonoBehaviour
{
    public Scenes_Manager scene_manage;
    private bool isGoodreviews = false;

    public Bank_Manager bankmanager;
    public GameObject Review_panel;
    


    public TextMeshProUGUI ReviewText;
    public TextMeshProUGUI ReviewText1;
    public TextMeshProUGUI ReviewText2;
    public TextMeshProUGUI RatingText;
    public TextMeshProUGUI RatingText1;
    public TextMeshProUGUI RatingText2;
    

    // GOOD REVIEWS
    string[] goodRatings =
    {
        "5/5",
        "4/5",
        "5/5",
        "4/5",
        "5/5",
        "4/5"
    };

    string[] goodReviews =
    {
        "Good game! I really enjoyed it.",
        "Nice game! I really enjoyed it.",
        "Awesome game! Really fun to play.",
        "Really enjoyed this game!",
        "Great game! I liked the concept.",
        "This game was surprisingly fun."
    };


    // BAD REVIEWS
    string[] badRatings =
    {
        "2/5",
        "1/5",
        "3/5",
        "2/5",
        "1/5",
        "2/5"
    };

    string[] badReviews =
    {
        "Bad game! Felt like a waste of time.",
        "I didn't really enjoy this game.",
        "The game needs a lot of work.",
        "The idea was interesting but execution was poor.",
        "Not a very enjoyable experience.",
        "Lots of problems with this game."
    };


    public void Panel_review()
    {
        Review_panel.SetActive(true);

        int slectedid = PlayerPrefs.GetInt("SelectedId", 0);

       if(slectedid == 1 || slectedid == 2)
        {
            ShowgoodReviews();
            bankmanager.Addmoney(10000);
            isGoodreviews = true;
        }
        else
        {
            string genre = PlayerPrefs.GetString("SaveGameGenere", " ").ToLower();
            string idea = PlayerPrefs.GetString("SaveGameIdea", " ").ToLower();

            if(IsIdeaMatchingGenere(genre , idea))
            {
                ShowgoodReviews();
                bankmanager.Addmoney(10000);
                isGoodreviews = true;
            }
            else
            {
                ShowbadReviews();
                isGoodreviews = false;
            }
               
        }
          
    }

    bool IsIdeaMatchingGenere(string genre, string idea)
    {
        // ACTION / SHOOTER
        if (genre.Contains("action") || genre.Contains("shooter"))
        {
            return idea.Contains("fight") ||
                   idea.Contains("war") ||
                   idea.Contains("soldier") ||
                   idea.Contains("gun") ||
                   idea.Contains("enemy") ||
                   idea.Contains("mission") ||
                   idea.Contains("battle") ||
                   idea.Contains("combat") ||
                   idea.Contains("shoot") ||
                   idea.Contains("weapon");
        }

        // RPG
        if (genre.Contains("rpg"))
        {
            return idea.Contains("quest") ||
                   idea.Contains("adventure") ||
                   idea.Contains("character") ||
                   idea.Contains("kingdom") ||
                   idea.Contains("magic") ||
                   idea.Contains("hero") ||
                   idea.Contains("level") ||
                   idea.Contains("dungeon") ||
                   idea.Contains("explore");
        }

        // SIMULATION
        if (genre.Contains("simulation"))
        {
            return idea.Contains("build") ||
                   idea.Contains("manage") ||
                   idea.Contains("city") ||
                   idea.Contains("farm") ||
                   idea.Contains("business") ||
                   idea.Contains("life") ||
                   idea.Contains("restaurant") ||
                   idea.Contains("hospital") ||
                   idea.Contains("school");
        }

        // STRATEGY / TYCOON
        if (genre.Contains("strategy") || genre.Contains("tycoon"))
        {
            return idea.Contains("strategy") ||
                   idea.Contains("manage") ||
                   idea.Contains("build") ||
                   idea.Contains("empire") ||
                   idea.Contains("army") ||
                   idea.Contains("business") ||
                   idea.Contains("city") ||
                   idea.Contains("resources") ||
                   idea.Contains("money");
        }

        // PUZZLE / CASUAL
        if (genre.Contains("puzzle") || genre.Contains("casual"))
        {
            return idea.Contains("puzzle") ||
                   idea.Contains("match") ||
                   idea.Contains("solve") ||
                   idea.Contains("block") ||
                   idea.Contains("tile") ||
                   idea.Contains("brain") ||
                   idea.Contains("memory") ||
                   idea.Contains("quiz") ||
                   idea.Contains("challenge");
        }

        // HORROR / SURVIVAL
        if (genre.Contains("horror") || genre.Contains("survival"))
        {
            return idea.Contains("ghost") ||
                   idea.Contains("monster") ||
                   idea.Contains("haunted") ||
                   idea.Contains("zombie") ||
                   idea.Contains("scary") ||
                   idea.Contains("survive") ||
                   idea.Contains("dark") ||
                   idea.Contains("dead") ||
                   idea.Contains("night") ||
                   idea.Contains("island");
        }

        // RACING / SPORTS
        if (genre.Contains("racing") || genre.Contains("sports"))
        {
            return idea.Contains("car") ||
                   idea.Contains("race") ||
                   idea.Contains("racing") ||
                   idea.Contains("driver") ||
                   idea.Contains("track") ||
                   idea.Contains("football") ||
                   idea.Contains("soccer") ||
                   idea.Contains("basketball") ||
                   idea.Contains("tennis") ||
                   idea.Contains("cricket");
        }

        // ENDLESS RUNNER / ARCADE
        if (genre.Contains("endlessrunner") || genre.Contains("arcade"))
        {
            return idea.Contains("run") ||
                   idea.Contains("runner") ||
                   idea.Contains("jump") ||
                   idea.Contains("obstacle") ||
                   idea.Contains("endless") ||
                   idea.Contains("collect") ||
                   idea.Contains("score") ||
                   idea.Contains("coin") ||
                   idea.Contains("survive");
        }

        return false;
    }

    public void ShowgoodReviews()
    {
        int index1 = Random.Range(0, goodReviews.Length);
        int index2= Random.Range(0, goodReviews.Length);

        while(index2 == index1)
        {
             index2 = Random.Range(0, goodReviews.Length);
        }

        int index3 = Random.Range(0, goodReviews.Length);

        while( index3 == index1 || index3 == index2)
        {
            index3 = Random.Range(0, goodReviews.Length);
        }

        ReviewText.text = goodReviews[index1];
        RatingText.text = goodRatings[index1];

        ReviewText1.text = goodReviews[index2];
        RatingText1.text = goodRatings[index2];

        ReviewText2.text = goodReviews[index3];
        RatingText2.text = goodRatings[index3];
    }

    public void ShowbadReviews()
    {
        int index1 = Random.Range(0, badReviews.Length);
        int index2 = Random.Range(0, badReviews.Length);

        while (index2 == index1)
        {
            index2 = Random.Range(0, badReviews.Length);
        }

        int index3 = Random.Range(0, badReviews.Length);

        while (index3 == index1 || index3 == index2)
        {
            index3 = Random.Range(0, badReviews.Length);
        }

        ReviewText.text = badReviews[index1];
        RatingText.text = badRatings[index1];

        ReviewText1.text = badReviews[index2];
        RatingText1.text = badRatings[index2];

        ReviewText2.text = badReviews[index3];
        RatingText2.text = badRatings[index3];
    }

   public void CutScene_manage()
    {
        if (isGoodreviews)
        {
            scene_manage.Cut2_CutSuccess();
        }
        else
        {
            scene_manage.Cut2_Cutfllop();
        }
    }
    
}

