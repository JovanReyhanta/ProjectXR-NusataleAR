using UnityEngine;
using UnityEngine.SceneManagement;
// Tambahkan baris ini di paling atas
using UnityEngine.InputSystem;

public class AndroidBackHandler : MonoBehaviour
{
    public string namaSceneKembali;
    public bool isKeluarAplikasi = false;

    void Update()
    {
        // Cara baru mendeteksi tombol Back (Escape)
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isKeluarAplikasi)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(namaSceneKembali);
            }
        }
    }
}