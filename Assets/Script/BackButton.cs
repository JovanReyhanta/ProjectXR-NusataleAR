using UnityEngine;
using UnityEngine.SceneManagement; // Penting untuk perpindahan scene

public class Gantiscene : MonoBehaviour
{
    public void KeHome()
    {
        // Ganti "SampleScene" dengan nama Scene AR kamu
        SceneManager.LoadScene("Homescene");
    }
}