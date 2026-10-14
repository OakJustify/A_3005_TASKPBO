namespace tugas_praktikum
{
    // Mewarisi Orang, menambah keluhan dan memiliki objek RekamMedis
    public class Pasien : Orang
    {
        public string Keluhan { get; set; }
        public RekamMedis RekamMedis { get; set; }

        public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
        {
            Keluhan = keluhan;
            RekamMedis = new RekamMedis();
            RekamMedis.RiwayatKeluhan = keluhan;
        }

        public void CekKeluhan()
        {
            Console.WriteLine($"    Keluhan       : {Keluhan}");
        }

        // Override versi Pasien
        public override void Aktivitas()
        {
            Console.WriteLine($"  [Pasien] {Nama} ({Umur} th) - menunggu giliran berobat, keluhan: {Keluhan}.");
        }

        // InfoOrang versi Pasien, ditambah data keluhan
        public override void InfoOrang()
        {
            base.InfoOrang();
            Console.WriteLine("  Keluhan: " + Keluhan);
        }
    }
}