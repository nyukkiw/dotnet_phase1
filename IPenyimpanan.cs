namespace Inventaris;

public interface IPenyimpanan
{
    IEnumerable<Barang> Muat();

    void Simpan(IEnumerable<Barang> daftarBarang);
}
