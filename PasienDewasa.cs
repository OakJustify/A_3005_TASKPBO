namespace tugas_praktikum
{
    // Mewarisi Pasien, memiliki method Konsultasi()
    public class PasienDewasa : Pasien
    {
        public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
        {
        }

        public void Konsultasi()
        {
            Console.WriteLine($"    {Nama} berkonsultasi tentang keluhan: {Keluhan}.");
            Console.WriteLine($"    Tenang, keluhan {Nama} bisa membaik dengan istirahat dan obat.");
        }

        // Override versi PasienDewasa
        public override void Aktivitas()
        {
            Console.WriteLine($"  [PasienDewasa] {Nama} ({Umur} th) - berkonsultasi dengan dokter.");
        }
    }
}