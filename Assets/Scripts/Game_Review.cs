using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Review : MonoBehaviour
{
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
        }
        else
        {
            ShowbadReviews();
            bankmanager.Addmoney(100);
        }
          
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
}

