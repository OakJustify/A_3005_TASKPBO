namespace tugas_praktikum
{
    // Rekaman kesehatan seorang pasien
    public class RekamMedis
    {
        public string RiwayatKeluhan { get; set; }
        public string HasilDiagnosa { get; set; }

        public RekamMedis()
        {
            RiwayatKeluhan = "Belum ada";
            HasilDiagnosa = "Belum ada";
        }

        public void TampilkanRekamMedis()
        {
            Console.WriteLine($"    Riwayat     : {RiwayatKeluhan}");
            Console.WriteLine($"    Diagnosis   : {HasilDiagnosa}");
        }
    }
}