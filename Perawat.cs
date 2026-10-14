namespace tugas_praktikum
{
    // Mewarisi TenagaMedis, memiliki method CekPasien()
    public class Perawat : TenagaMedis
    {
        public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
        {
        }

        // Menerima objek Pasien sebagai parameter
        public void CekPasien(Pasien pasien)
        {
            Console.WriteLine($"  Pemeriksaan vital oleh {Nama} atas pasien {pasien.Nama} ({pasien.Umur} th)");
            Console.WriteLine($"    Yang dipantau : tensi, nadi, suhu, dan keluhan {pasien.Keluhan}.");
        }

        public override void TugasUtama()
        {
            Console.WriteLine("    Tugas utama   : memeriksa dan memantau kondisi pasien.");
        }

        // Override versi Perawat
        public override void Aktivitas()
        {
            Console.WriteLine($"  [Perawat] {Nama} ({Umur} th) - memantau kondisi pasien dan membantu dokter.");
        }
    }
}