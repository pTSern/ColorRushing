using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace pTS
{
    public abstract class pTSBehaviour : MonoBehaviour
    {
        protected string _name => typeof(pTSBehaviour).Name;

        protected void Log(string msg)
        {
            Debug.Log($"[{this._name}] Log: {msg}");
        }
    }
}
