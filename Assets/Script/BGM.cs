using UnityEngine;

public class BGMManager : MonoBehaviour
{
    // Menggunakan konsep Singleton agar BGM tidak menumpuk/double
    private static BGMManager instance;

    void Awake()
    {
        // Cek apakah sudah ada BGMManager yang berjalan di scene sebelumnya
        if (instance != null && instance != this)
        {
            // Jika sudah ada, hancurkan objek yang baru ini agar tidak double
            Destroy(gameObject);
            return;
        }

        // Jika belum ada, jadikan objek ini sebagai instance utama
        instance = this;

        // Perintah keramat agar objek ini TIDAK hancur saat pindah scene
        DontDestroyOnLoad(gameObject);
    }
}