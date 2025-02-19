using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingoPointCounter : MonoBehaviour
{
   public delegate void AddPointAction();
   public static AddPointAction AddPointEvent;
   public delegate void SubstractPointAction();
   public static AddPointAction SubstractPointEvent;
   private void OnTriggerEnter(Collider other) {
    if (other.tag == "Ringo")
    {
      AddPointEvent?.Invoke();
    }
   }
   private void OnTriggerExit(Collider other) {
    if (other.tag == "Ringo")
    {
      SubstractPointEvent?.Invoke();
    }
   }
  void Update()
  {
   if(AddPointEvent != null)
   {
   }
  }
}
