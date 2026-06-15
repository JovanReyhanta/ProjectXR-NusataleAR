using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Animator fadeAnimator; // Tarik FadePanel yang punya Animator ke sini
    public string namaSceneTujuan = "MainMenu";

    void Start()
    {
        // Jalankan transisi setelah bumper selesai (misal 3 detik)
        StartCoroutine(MulaiTransisi());
    }

    IEnumerator MulaiTransisi()
    {
        // Tunggu durasi bumper tampil
        yield return new WaitForSeconds(3f);

        // Jalankan animasi Fade Out (Layar jadi gelap)
        fadeAnimator.SetTrigger("StartFadeOut");

        // Tunggu animasi selesai (misal 1 detik)
        yield return new WaitForSeconds(1f);

        // Pindah Scene
        SceneManager.LoadScene(namaSceneTujuan);
    }
}