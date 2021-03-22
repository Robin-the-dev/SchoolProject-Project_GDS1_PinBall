﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
   #region Singleton
   private static DontDestroyOnLoad _instance; 
   public static DontDestroyOnLoad Instance { get { return _instance; } }
    
   private void Awake()
   {
      if (_instance != null && _instance != this)
      {
         Destroy(this.gameObject);
      } else {
         _instance = this;
         DontDestroyOnLoad(gameObject);
      }
   }
   #endregion
}
