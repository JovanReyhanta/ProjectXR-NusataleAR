using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BumperTransition : MonoBehaviour
{
    public float waktuTunggu = 3.0f; // Bumper muncul selama 3 detik

    void Start()
    {
        // Menjalankan fungsi pindah setelah waktu tunggu selesai
        StartCoroutine(PindahKeHome());
    }

    IEnumerator PindahKeHome()
    {
        yield return new WaitForSeconds(waktuTunggu);

        // Pindah ke Homescene (Index 1)
        SceneManager.LoadScene(1);
    }
}