using System.Globalization;
namespace Inventaris;
class Program
{
    static void Main(string[] args)
    {
    
        Kategori kategori = new Kategori("Makanan");

        bool aplikasiBerjalan = true;

        while (aplikasiBerjalan)
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine("    SISTEM MANAJEMEN INVENTARIS TOKO   ");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Tampilkan Semua Barang");
            Console.WriteLine("2. Tambah Barang Baru");
            Console.WriteLine("3. Cari Barang Berdasarkan Nama");
            Console.WriteLine("4. Hapus Barang");
            Console.WriteLine("5. Hitung Total Nilai Aset Toko");
            Console.WriteLine("6. Keluar Aplikasi");
            Console.Write("Pilih menu (1-6): ");

            string? inputMenu = Console.ReadLine();

            if (!int.TryParse(inputMenu, out int pilihanMenu))
            {
                Console.WriteLine("Input salah! Silakan masukkan angka 1 sampai 6.");
                continue; 
            }

            Console.WriteLine();

            switch (pilihanMenu)
            {
                case 1: 

                    IEnumerable<Barang> hasil = kategori.SemuaBarang();
                    foreach (var b in hasil)
                    {
                        CetakBarang(b);
                    }
                    break;

                case 2: 
                    Console.WriteLine("--- MENU TAMBAH BARANG ---");
                    Console.Write("Masukkan ID Barang (Angka): ");
                    string? inputId = Console.ReadLine();
                    if (!int.TryParse(inputId, out int id) || id <= 0)
                    {
                        Console.WriteLine("ID harus berupa angka positif!");
                        break;
                    }
                    

                    Console.Write("Masukkan Nama Barang: ");
                    string? nama = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nama))
                    {
                        Console.WriteLine("Nama barang tidak boleh kosong!");
                        
                        break;
                    }

                    Console.Write("Masukkan Harga Barang (Rp): ");
                    string? inputHarga = Console.ReadLine();
                    if (!decimal.TryParse(inputHarga?.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out decimal harga) || harga<=0)
                    {
                        Console.WriteLine("Harga harus berupa angka bulat positif, tanpa titik, koma, atau tanda minus.");
                        break;
                    }

   
                    Console.Write("Masukkan Jumlah Stok: ");
                    string? inputStok = Console.ReadLine();
                    if (!int.TryParse(inputStok, out int stok) || stok < 0)
                    {
                        Console.WriteLine("Jumlah stok tidak valid atau bernilai negatif!");
                        break;
                    }
                    nama = nama.Trim();
                    Barang barangBaru = new Barang(id, nama, harga, stok);
                    Console.WriteLine(kategori.Tambah(barangBaru) ? "Berhasil ditambah" : "Gagal menambah");
                    break;

                case 3: 
                    Console.WriteLine("--- MENU CARI BARANG ---");
                    Console.Write("Masukkan kata kunci nama barang: ");
                    string? kataKunci = Console.ReadLine();
                    
                    IEnumerable<Barang> hasilCari = kategori.CariByNama(kataKunci ?? "");
                    
                    Console.WriteLine("\nHasil Pencarian:");
                    int jumlahKetemu = 0;
                    foreach (var b in hasilCari)
                    {
                        CetakBarang(b);
                        jumlahKetemu++;
                    }
                    if (jumlahKetemu == 0) Console.WriteLine("Tidak ada barang yang cocok.");
                    break;

                case 4: 
                    Console.WriteLine("--- MENU HAPUS BARANG ---");
                    Console.Write("Masukkan ID Barang yang ingin dihapus: ");
                    string? inputIdHapus = Console.ReadLine();
                    if (!int.TryParse(inputIdHapus, out int idHapus))
                    {
                        Console.WriteLine("ID harus berupa angka!");
                        break;
                    }
                    
                    Console.WriteLine(kategori.Hapus(idHapus) ? "Berhasil dihapus" : "Gagal menghapus");
                    break;

                case 5: 
                    decimal totalAset = kategori.TotalNilaiStok();
                    Console.WriteLine("--- TOTAL ASET TOKO ---");
                    Console.WriteLine($"Total nilai uang dari seluruh stok di gudang: Rp{totalAset}");
                    break;

                case 6: 
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi inventaris!");
                    aplikasiBerjalan = false;
                    break;

                default:
                    Console.WriteLine("Pilihan menu tidak tersedia (harus 1-6).");
                    break;
            }
        }
    }

    static void CetakBarang(Barang b)
    {
        Console.WriteLine($"- [ID: {b.Id}] {b.Nama} | Harga: Rp{b.Harga} | Stok: {b.Stok}");
    }

}
