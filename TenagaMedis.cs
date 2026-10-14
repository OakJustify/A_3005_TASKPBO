namespace tugas_praktikum
{
    // Mewarisi Orang, menambah spesialisasi.
    // Abstract karena TugasUtama() wajib dijelaskan oleh
    // kelas anak (Dokter dan Perawat).
    public abstract class TenagaMedis : Orang
    {
        public string Spesialisasi { get; set; }

        public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
        {
            Spesialisasi = spesialisasi;
        }

        public void CekSpesialis()
        {
            Console.WriteLine($"    Spesialisasi  : {Spesialisasi}");
        }

        // Wajib diimplementasikan oleh setiap turunan
        public abstract void TugasUtama();

        // Override versi TenagaMedis
        public override void Aktivitas()
        {
            Console.WriteLine($"  [TenagaMedis] {Nama} ({Umur} th) - berkedudukan sebagai tenaga medis {Spesialisasi}.");
        }
    }
}