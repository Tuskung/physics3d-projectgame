using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        // เมื่อวัตถุแตะกับกล่อง
        if (collision.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("End Credit");
        }

    }
}
