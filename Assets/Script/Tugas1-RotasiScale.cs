using UnityEngine;
using UnityEngine.InputSystem; // Wajib untuk New Input System

public class ARObjectInteract : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Kecepatan rotasi saat digeser dengan 1 jari")]
    public float rotationSpeed = 0.5f;

    [Header("Scale (Zoom/Pinch) Settings")]
    [Tooltip("Kecepatan membesar/mengecil saat di-pinch 2 jari")]
    public float scaleSpeed = 0.01f;
    public float minScale = 0.1f;  // Batas ukuran terkecil
    public float maxScale = 5.0f;  // Batas ukuran terbesar

    void Update()
    {
        int activeTouches = GetActiveTouchCount();

        // Jika hanya 1 jari menempel -> Lakukan Rotasi
        if (activeTouches == 1)
        {
            HandleRotation();
        }
        // Jika 2 jari menempel -> Lakukan Skala (Pinch/Zoom)
        else if (activeTouches == 2)
        {
            HandleScale();
        }
    }

    // Fungsi untuk menghitung jari yang benar-benar menempel di layar
    int GetActiveTouchCount()
    {
        if (Touchscreen.current == null) return 0;

        int count = 0;
        foreach (var touch in Touchscreen.current.touches)
        {
            if (touch.phase.ReadValue() != UnityEngine.InputSystem.TouchPhase.None &&
                touch.phase.ReadValue() != UnityEngine.InputSystem.TouchPhase.Canceled &&
                touch.phase.ReadValue() != UnityEngine.InputSystem.TouchPhase.Ended)
            {
                count++;
            }
        }
        return count;
    }

    void HandleRotation()
    {
        if (Touchscreen.current == null) return;

        var touch = Touchscreen.current.touches[0];
        Vector2 delta = touch.delta.ReadValue();

        // Rotasi berdasarkan input jari
        // Menggunakan Space.World agar rotasi tetap stabil dari sudut pandang kamera AR
        transform.Rotate(Vector3.up, -delta.x * rotationSpeed, Space.World);
        transform.Rotate(Vector3.right, delta.y * rotationSpeed, Space.World);
    }

    void HandleScale()
    {
        if (Touchscreen.current == null) return;

        var t1 = Touchscreen.current.touches[0];
        var t2 = Touchscreen.current.touches[1];

        // Cari posisi kedua jari di frame sebelumnya
        Vector2 prevPos1 = t1.position.ReadValue() - t1.delta.ReadValue();
        Vector2 prevPos2 = t2.position.ReadValue() - t2.delta.ReadValue();

        // Hitung jarak (magnitudo) antara dua jari
        float prevDist = Vector2.Distance(prevPos1, prevPos2);
        float currentDist = Vector2.Distance(t1.position.ReadValue(), t2.position.ReadValue());

        // Selisih jarak menentukan apakah jari merenggang (Scale Up) atau mencubit (Scale Down)
        float deltaDist = currentDist - prevDist;

        // Terapkan perubahan pada skala objek
        if (Mathf.Abs(deltaDist) > 0)
        {
            // Ambil skala sumbu X saat ini sebagai patokan (asumsi skala X, Y, Z sama besar)
            float currentScale = transform.localScale.x;
            float newScale = currentScale + (deltaDist * scaleSpeed);

            // Batasi skala agar objek tidak terlalu kecil hingga hilang atau terlalu raksasa
            newScale = Mathf.Clamp(newScale, minScale, maxScale);

            // Terapkan skala baru ke objek
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}