namespace tugas_praktikum
{
    // Kelas dasar: memiliki data nama dan umur
    public class Orang
    {
        public string Nama { get; set; }
        public int Umur { get; set; }

        public Orang(string nama, int umur)
        {
            Nama = nama;
            Umur = umur;
        }

        // Virtual: boleh ditulis ulang oleh kelas anak
        public virtual void Aktivitas()
        {
            Console.WriteLine($"  [Orang] {Nama} ({Umur} th) - melakukan kegiatan umum.");
        }

        public virtual void InfoOrang()
        {
            Console.WriteLine("  Nama   : " + Nama);
            Console.WriteLine("  Umur   : " + Umur + " tahun");
            Console.WriteLine("  Kelas  : " + GetType().Name);
        }
    }
}