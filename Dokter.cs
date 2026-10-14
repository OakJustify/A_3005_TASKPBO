namespace tugas_praktikum
{
    // Mewarisi TenagaMedis, memiliki method Diagnosa()
    public class Dokter : TenagaMedis
    {
        public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
        {
        }

        // Menerima objek Pasien sebagai parameter
        public void Diagnosa(Pasien pasien)
        {
            Console.WriteLine($"  Pemeriksaan oleh {Nama} atas pasien {pasien.Nama} ({pasien.Umur} th)");
            Console.WriteLine($"    Keluhan       : {pasien.Keluhan}");
            Console.WriteLine($"    Diagnosis     : ditangani oleh spesialis {Spesialisasi}.");

            // Hasil disimpan ke rekam medis pasien
            pasien.RekamMedis.HasilDiagnosa = "Dicegah oleh spesialis " + Spesialisasi + ".";
        }

        public override void TugasUtama()
        {
            Console.WriteLine("    Tugas utama   : memeriksa pasien dan menetapkan diagnosis.");
        }

        // Override versi Dokter
        public override void Aktivitas()
        {
            Console.WriteLine($"  [Dokter] {Nama} ({Umur} th) - memeriksa pasien sebagai spesialis {Spesialisasi}.");
        }
    }
}