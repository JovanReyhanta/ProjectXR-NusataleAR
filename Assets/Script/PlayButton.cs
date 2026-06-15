using UnityEngine;
using UnityEngine.SceneManagement; // Penting untuk perpindahan scene

public class PindahScene : MonoBehaviour
{
    public void KeKameraAR()
    {
        // Ganti "SampleScene" dengan nama Scene AR kamu
        SceneManager.LoadScene("SampleScene");
    }
}