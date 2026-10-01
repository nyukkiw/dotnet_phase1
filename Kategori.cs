// Kategori.cs

// Menyimpan Nama kategori dan daftar barang.
// Daftar barang harus private. Dari luar tidak boleh ada kategori.Daftar.Clear() atau .Add() langsung.
// Method yang wajib ada:

// Tambah(Barang)	Id yang sudah ada tidak boleh masuk diam-diam. Pilih sendiri: tolak (return bool) atau lempar exception, lalu jelaskan alasannya.
// CariByNama(string)	Tidak sensitif huruf besar/kecil, pakai LINQ. Bisa partial match (contains).
// Hapus(int id)	Putuskan apa yang dikembalikan kalau Id tidak ketemu.
// TotalNilaiStok()	Harga * Stok dijumlahkan dengan LINQ Sum.
// Semua()	Untuk menampilkan daftar. Jangan mengembalikan List aslinya. Cari tahu IReadOnlyList atau IEnumerable dan kenapa itu penting.
// Tidak ada Console.WriteLine di dalam Kategori.

class Kategori
{
    private string nama 
    {
        get;
        set;
    }
    private List<int> daftarBarang
    {
        get;
        set;   
    }

    

    public void tambah()
    {
        
    }



}