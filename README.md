# Inventaris Console (C#)

Aplikasi console sederhana untuk mengelola inventaris barang toko, dibuat sebagai latihan belajar C# dan .NET untuk backend.

Data tersimpan di file `data.json`, jadi tidak hilang saat program ditutup.

## Fitur

- Tampilkan, tambah, cari, dan hapus barang
- Cari berdasarkan nama (sebagian kata, tidak peka huruf besar/kecil)
- Hitung total nilai stok
- ID duplikat ditolak
- Harga hanya menerima angka bulat positif

## Struktur

- `Barang.cs`: data satu barang (`record`)
- `Kategori.cs`: mengelola daftar barang, tidak tahu cara menyimpan ke file
- `IPenyimpanan.cs`: aturan penyimpanan (muat dan simpan)
- `JsonPenyimpanan.cs`: penyimpanan ke file JSON
- `Program.cs`: menu console dan validasi input

## Yang dipelajari

- Memisahkan logika dari penyimpanan lewat interface
- File JSON yang rusak ditolak dan tidak ditimpa
- Kalau menyimpan gagal, perubahan di memori dibatalkan lagi
- `decimal.TryParse` bergantung pada pengaturan bahasa komputer. Di komputer saya, `12.5` sempat terbaca `125`. Solusinya parsing dengan `CultureInfo.InvariantCulture`.

## Rencana berikutnya

`async/await`, lalu EF Core.

Tujuan akhir: REST API dengan ASP.NET Core.

