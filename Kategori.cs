
using System.Security.Cryptography.X509Certificates;

namespace Inventaris;

public class Kategori
{
    public string Nama { get; }
    private readonly IPenyimpanan _penyimpanan; 
    private readonly List<Barang> _daftarBarang;
    public Kategori(string nama, IPenyimpanan penyimpanan)
    {
        Nama = nama;
        _penyimpanan = penyimpanan;
        _daftarBarang = penyimpanan.Muat().ToList();
    }


    public bool Tambah(Barang barang)
    {
        if (_daftarBarang.Any(x => x.Id == barang.Id))
        {
            return false;
        }

        try
        {
                _daftarBarang.Add(barang);
                _penyimpanan.Simpan(_daftarBarang);
        }
        catch(Exception)
        {

            if (barang != null)
            {
                _daftarBarang.Remove(barang);                
            }
        throw; 

        }

            return true;
    }
    public IEnumerable<Barang> CariByNama(string kataKunci)
    {
        if (string.IsNullOrWhiteSpace(kataKunci))
        {
            return SemuaBarang();
        }

        return _daftarBarang.Where(b => b.Nama.Contains(kataKunci, StringComparison.OrdinalIgnoreCase));
    }

    public bool Hapus(int target)
    {
        if(_daftarBarang.Any(x => x.Id != target))
        {
            return false;
        }
        try
        {
            _daftarBarang.RemoveAll(x => x.Id == target);
            _penyimpanan.Simpan(_daftarBarang);
        }
        catch(Exception)
        {

            throw;
        }
        return true;

    } 


    public decimal TotalNilaiStok()
    {

        return _daftarBarang.Sum(x => x.Stok * x.Harga);
    }


    public IReadOnlyList<Barang> SemuaBarang()
    {
        return _daftarBarang.AsReadOnly();
    }
}