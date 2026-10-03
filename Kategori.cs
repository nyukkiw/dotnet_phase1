
namespace Inventaris;
public class Kategori
{
    public string Nama{get;}
    private readonly List<Barang> _daftarBarang = new();
    public Kategori(string nama)
    {
        this.Nama = nama;
    }
    
    
    public bool Tambah(Barang barang)
    {
        if (_daftarBarang.Any(x => x.Id == barang.Id))
        {
            return false;
        }

        _daftarBarang.Add(barang);
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

    public bool Hapus(int target) => _daftarBarang.RemoveAll(x => x.Id == target) > 0;


    public decimal TotalNilaiStok()
    {

        return _daftarBarang.Sum(x => x.Stok * x.Harga);
    }


    public IReadOnlyList<Barang> SemuaBarang()
    {
        return _daftarBarang.AsReadOnly();
    }
}