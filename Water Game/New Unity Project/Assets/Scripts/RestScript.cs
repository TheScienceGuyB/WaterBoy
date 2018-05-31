using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Com.LuisPedroFonseca.ProCamera2D
{
    public class RestScript : MonoBehaviour
    {
        public bool resetSize;
        // Use this for initialization
        void Start()
        {

        }

        public void ResetCam()
        {
            if (resetSize == true)
            {
                ProCamera2D.Instance.ResetSize();
            }
        }
    }
}
