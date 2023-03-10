using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace kinjo{
    public class TitleController : MonoBehaviour
    {
        // Start is called before the first frame update
        public void OnStartButtonClicked(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
