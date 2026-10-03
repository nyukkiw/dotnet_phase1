using System.Text.Json;

namespace Inventaris;

public class JsonPenyimpanan : IPenyimpanan
{
    private readonly string _filePath;
    public JsonPenyimpanan(String Filepath)
    {
        if (string.IsNullOrWhiteSpace(Filepath))
            {
                throw new ArgumentException("Alamat file tidak boleh kosong!", nameof(Filepath));
            }
            _filePath = Filepath;
    }
    public IEnumerable<Barang> Muat()
    {
            if (!File.Exists(_filePath))
            {
                return new List<Barang>();
            }

            try
            {
                string jsonString = File.ReadAllText(_filePath);
                
                var daftar = JsonSerializer.Deserialize<List<Barang>>(jsonString);
                
                return daftar ?? new List<Barang>();
            }
            catch (JsonException ex)
            {
                
                throw new InvalidDataException($"BAHAYA: Format teks di file '{_filePath}' rusak! Jangan menimpa file ini. Perbaiki dulu. Detail: {ex.Message}", ex);
            }
    }

    public void Simpan(IEnumerable<Barang> daftarBarang)
    {
        
            string fileSementara = _filePath + ".tmp"; 

            try
            {
                
                var opsiJson = new JsonSerializerOptions { WriteIndented = true };
                string teksJson = JsonSerializer.Serialize(daftarBarang, opsiJson);

                File.WriteAllText(fileSementara, teksJson);

                
                if (File.Exists(_filePath))
                {
                    
                    File.Replace(fileSementara, _filePath, null);
                }
                else
                {
                    
                    File.Move(fileSementara, _filePath, overwrite: true);
                }
            }
            catch (Exception)
            {
                
                if (File.Exists(fileSementara))
                {
                    File.Delete(fileSementara);
                }
                throw; 
            }
        
    }
}
