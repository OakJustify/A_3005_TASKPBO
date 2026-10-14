namespace tugas_praktikum
{
    // Mewarisi Pasien, memiliki method Menangis()
    public class PasienAnak : Pasien
    {
        public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
        {
        }

        public void Menangis()
        {
            Console.WriteLine($"    {Nama} menangis terus karena keluhan: {Keluhan}.");
            Console.WriteLine($"    Perlu dihibur orang tua agar {Nama} mau diperiksa.");
        }

        // Override versi PasienAnak
        public override void Aktivitas()
        {
            Console.WriteLine($"  [PasienAnak] {Nama} ({Umur} th) - menangis dan perlu dihibur orang tua.");
        }
    }
}