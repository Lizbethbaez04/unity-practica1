using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{ 

   
   TextMeshProUGUI txtScore;
   int currentPoints = 0;

   void Awake()
   {
       txtScore = GetComponent<TextMeshProUGUI>();
   }

   public void AddPoints(int points)
   {
       currentPoints += points;
       txtScore.text = $"Score:{currentPoints} points";
   }
}
