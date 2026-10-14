namespace tugas_praktikum
{
    // RumahSakit memiliki (composition) kumpulan Orang
    public class RumahSakit
    {
        public string NamaRumahSakit { get; set; }
        public List<Orang> daftarOrang = new List<Orang>();

        public RumahSakit(string namaRumahSakit)
        {
            NamaRumahSakit = namaRumahSakit;
        }

        public void TambahOrang(Orang orang)
        {
            daftarOrang.Add(orang);
            Console.WriteLine($"    [Tambah] {orang.Nama} ({orang.GetType().Name})");
        }

        public void DaftarOrang()
        {
            string judul = "  ===== DAFTAR ORANG DI " + NamaRumahSakit.ToUpperInvariant() + " =====";

            Console.WriteLine();
            Console.WriteLine(judul);
            Console.WriteLine(new string('=', judul.Length));

            foreach (Orang o in daftarOrang)
            {
                o.InfoOrang();
            }

            Console.WriteLine(new string('=', judul.Length));
            Console.WriteLine("  Total orang: " + daftarOrang.Count);
        }

        // Memanggil Aktivitas() setiap objek di dalam daftar
        public void JalankanAktivitas()
        {
            Console.WriteLine();
            Console.WriteLine("  ===== AKTIVITAS SELURUH ORANG =====");

            foreach (Orang o in daftarOrang)
            {
                o.Aktivitas();
            }
        }
    }
}