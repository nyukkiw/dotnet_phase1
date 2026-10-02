# Inventaris Console (C#)

Aplikasi console sederhana untuk mengelola inventaris barang toko, dibuat sebagai latihan belajar C# dan .NET untuk backend. Ini Level 1 dari rencana belajar bertahap menuju ASP.NET Core.

Data masih disimpan di memori, jadi hilang saat program ditutup.

## Fitur

- Tampilkan semua barang
- Tambah barang (ID, nama, harga, stok), ID duplikat ditolak
- Cari barang berdasarkan nama (sebagian kata, tidak peka huruf besar/kecil)
- Hapus barang berdasarkan ID
- Hitung total nilai stok

## Struktur

- `Barang.cs`: `record Barang(Id, Nama, Harga, Stok)`, harga bertipe `decimal`
- `Kategori.cs`: mengelola daftar barang. List internal bersifat private dan hanya diekspos read-only
- `Program.cs`: menu console dan validasi input

## Yang dipelajari

- `record`, properties, LINQ, dan enkapsulasi koleksi
- Nullable reference types dan `TryParse` untuk input pengguna
- Temuan bug: `decimal.TryParse` bergantung pada locale. Di komputer ber-locale Indonesia, input `12.5` terbaca `125` tanpa error. Solusinya parsing eksplisit dengan `CultureInfo.InvariantCulture`, sehingga harga hanya menerima angka bulat.

## Rencana berikutnya

Persistensi JSON, `async/await`, lalu EF Core.

Tujuan akhir: REST API dengan ASP.NET Core.
