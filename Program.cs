namespace tugas_praktikum
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            // 1. Membuat objek
            RumahSakit rumahSakit = new("RS Sehat Bersama");
            Dokter dokter = new("Dr. Budi", 35, "Penyakit Dalam");
            Perawat perawat = new("Siti", 28, "Keperawatan Umum");
            PasienAnak pasienAnak = new("Andi", 8, "Demam");
            PasienDewasa pasienDewasa = new("Rina", 25, "Sakit kepala");

            // 2. Mendaftarkan objek ke rumah sakit
            DaftarkanOrang(rumahSakit, dokter, perawat, pasienAnak, pasienDewasa);

            // 3. Daftar orang dan aktivitas tiap orang (polimorfisme)
            TampilkanDaftarOrang(rumahSakit);

            // 4. Method khusus tiap kelas
            TampilkanMethodKhusus(dokter, perawat, pasienAnak, pasienDewasa);

            // 5. Rekam medis pasien dewasa (diisi oleh dokter pada langkah 4)
            Judul("REKAM MEDIS PASIEN DEWASA");
            TampilkanRekamMedis(pasienDewasa);

            // 6. Variabel bertipe Orang yang berisi objek Perawat
            Judul("VARIABEL ORANG BERISI PERAWAT");
            TampilkanPolimorfisme(perawat);

            Judul("PROGRAM SELESAI");
            Console.ReadKey();
        }

        // Mendaftarkan setiap orang ke dalam rumah sakit
        private static void DaftarkanOrang(RumahSakit rumahSakit, params Orang[] daftarOrang)
        {
            foreach (Orang o in daftarOrang)
            {
                rumahSakit.TambahOrang(o);
            }
        }

        // Menampilkan seluruh orang di rumah sakit beserta aktivitasnya
        private static void TampilkanDaftarOrang(RumahSakit rumahSakit)
        {
            rumahSakit.DaftarOrang();
            rumahSakit.JalankanAktivitas();
        }

        // Menampilkan method yang hanya dimiliki kelas tertentu
        private static void TampilkanMethodKhusus(
            Dokter dokter,
            Perawat perawat,
            PasienAnak pasienAnak,
            PasienDewasa pasienDewasa)
        {
            Judul("METHOD KHUSUS");

            // Dokter
            Kelompok(dokter);
            dokter.CekSpesialis();
            dokter.TugasUtama();

            // Hasil diagnosa dokter terhadap pasien dewasa
            Judul("DIAGNOSA DOKTER");
            dokter.Diagnosa(pasienDewasa);

            // Perawat
            Kelompok(perawat);
            perawat.CekSpesialis();
            perawat.TugasUtama();

            // Pemeriksaan vital oleh perawat terhadap pasien anak
            Judul("PEMERIKSAAN VITAL PERAWAT");
            perawat.CekPasien(pasienAnak);

            // Pasien anak
            Kelompok(pasienAnak);
            pasienAnak.CekKeluhan();
            pasienAnak.Menangis();

            // Pasien dewasa
            Kelompok(pasienDewasa);
            pasienDewasa.CekKeluhan();
            pasienDewasa.Konsultasi();
        }

        // Menampilkan rekam medis seorang pasien
        private static void TampilkanRekamMedis(Pasien pasien)
        {
            Console.WriteLine();
            Console.WriteLine("  " + pasien.Nama + " (" + pasien.Umur + " th)");
            pasien.RekamMedis.TampilkanRekamMedis();
        }

        // Menunjukkan bahwa variabel Orang bisa menampung objek apa pun
        private static void TampilkanPolimorfisme(Orang orang)
        {
            Console.WriteLine($"    Tipe variabel : {nameof(Orang)}");
            Console.WriteLine($"    Isi variabel  : {orang.GetType().Name}");
            Console.WriteLine();
            orang.Aktivitas();
        }

        // Mencetak judul utama, indent 2 spasi
        private static void Judul(string teks)
        {
            Console.WriteLine();
            Console.WriteLine("  ===== " + teks + " =====");
        }

        // Mencetak judul kelompok objek, indent 2 spasi
        private static void Kelompok(Orang orang)
        {
            Console.WriteLine();
            Console.WriteLine("  [" + orang.GetType().Name + "] " + orang.Nama + " (" + orang.Umur + " th)");
        }
    }
}