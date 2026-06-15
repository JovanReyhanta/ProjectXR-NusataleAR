using UnityEngine;
using TMPro; // Wajib ditambahkan

public class TeksAnimasiHuruf : MonoBehaviour
{
    private TMP_Text m_TextComponent; // Komponen TMP kita
    public float kecepatanBergerak = 1.0f; // Kecepatan gerak huruf
    public float jarakGuncangan = 1.5f; // Jarak guncangan huruf

    void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>(); // Ambil komponen TMP
    }

    void Update()
    {
        // Pastikan teksnya tidak kosong
        if (m_TextComponent == null || m_TextComponent.textInfo.characterCount == 0) return;

        // Beri tahu TMP bahwa kita akan mengubah datanya
        m_TextComponent.ForceMeshUpdate();

        // Ambil informasi teks
        TMP_TextInfo textInfo = m_TextComponent.textInfo;

        // Looping untuk setiap huruf
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            // Ambil informasi karakter ke-i
            TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

            // Jika karakter adalah spasi, lewati
            if (!charInfo.isVisible) continue;

            // Ambil index untuk warna dan vertex (sudut huruf)
            int materialIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            // Ambil vertex (posisi 4 sudut huruf)
            Vector3[] sourceVertices = textInfo.meshInfo[materialIndex].vertices;

            // Buat guncangan acak untuk setiap sudut
            Vector3 offset = new Vector3(
                Random.Range(-jarakGuncangan, jarakGuncangan),
                Random.Range(-jarakGuncangan, jarakGuncangan),
                0
            );

            // Terapkan guncangan acak ke ke-4 sudut huruf
            sourceVertices[vertexIndex + 0] += offset;
            sourceVertices[vertexIndex + 1] += offset;
            sourceVertices[vertexIndex + 2] += offset;
            sourceVertices[vertexIndex + 3] += offset;
        }

        // Terapkan perubahan ke mesh teks agar terlihat di layar
        m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
    }
}