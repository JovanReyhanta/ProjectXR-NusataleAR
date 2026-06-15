using UnityEngine;
using TMPro; // Wajib untuk TextMeshPro
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    // Komponen Teks TMP
    public TMP_Text komponenTeks;
    // Teks utuh yang ingin ditampilkan
    public string teksLengkap = "Tangkuban Perahu";
    // Kecepatan muncul (detik per huruf)
    public float kecepatanWaktu = 0.2f;
    // Suara ketikan (opsional)
    public AudioSource suaraKetik;

    void Start()
    {
        // Pastikan teks awalnya kosong
        komponenTeks.text = "";
        // Memulai efek mesin tik
        StartCoroutine(TampilkanTeks());
    }

    IEnumerator TampilkanTeks()
    {
        // Loop setiap huruf dalam teks lengkap
        foreach (char huruf in teksLengkap.ToCharArray())
        {
            // Tambahkan satu huruf ke teks TMP
            komponenTeks.text += huruf;

            // Mainkan suara jika ada
            if (suaraKetik != null)
            {
                suaraKetik.Play();
            }

            // Tunggu sebentar sebelum huruf berikutnya
            yield return new WaitForSeconds(kecepatanWaktu);
        }
    }
}