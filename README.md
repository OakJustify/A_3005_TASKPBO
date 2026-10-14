# Week 8 - Inheritance & Polymorphism (Sistem Rumah Sakit)

Program C# console sederhana yang mengimplementasikan **inheritance** dan
**polymorphism** (override) sesuai UML class diagram rumah sakit.

Jawaban lengkap untuk 6 soal pada lembar tugas ada di **[JAWABAN.md](JAWABAN.md)**.

---

## Class hierarchy

```text
RumahSakit  o--->  Orang                       (composition)
                            |
            +---------------+---------------+
            |                               |
         Pasien                       TenagaMedis
       /        \                     /           \
  PasienAnak   PasienDewasa       Dokter        Perawat
```

| Class | Parent | Properties | Methods |
|---|---|---|---|
| `Orang` | - | `Nama`, `Umur` | `Aktivitas()`, `InfoOrang()` |
| `Pasien` | `Orang` | `Keluhan`, `RekamMedis` | `CekKeluhan()`, override `Aktivitas()` dan `InfoOrang()` |
| `PasienAnak` | `Pasien` | - | `Menangis()`, override `Aktivitas()` |
| `PasienDewasa` | `Pasien` | - | `Konsultasi()`, override `Aktivitas()` |
| `TenagaMedis` | `Orang` | `Spesialisasi` | `CekSpesialis()`, abstract `TugasUtama()`, override `Aktivitas()` |
| `Dokter` | `TenagaMedis` | - | `Diagnosa(Pasien)`, `TugasUtama()`, override `Aktivitas()` |
| `Perawat` | `TenagaMedis` | - | `CekPasien(Pasien)`, `TugasUtama()`, override `Aktivitas()` |
| `RekamMedis` | - | `RiwayatKeluhan`, `HasilDiagnosa` | `TampilkanRekamMedis()` |
| `RumahSakit` | - | `NamaRumahSakit`, `daftarOrang : List<Orang>` | `TambahOrang(Orang)`, `DaftarOrang()`, `JalankanAktivitas()` |

`Aktivitas()` ditulis `virtual` di `Orang` dan di-override di **setiap** subclass,
termasuk pada tingkat kedua (`PasienAnak`, `PasienDewasa`, `Dokter`, `Perawat`).

---

## Project structure

```text
A_3005_TASKPBO/
├── Week8.csproj          # console project, net10.0, implicit usings
├── Orang.cs              # kelas dasar
├── Pasien.cs             # turunan Orang
├── PasienAnak.cs         # turunan Pasien
├── PasienDewasa.cs       # turunan Pasien
├── TenagaMedis.cs         # turunan Orang
├── Dokter.cs             # turunan TenagaMedis
├── Perawat.cs            # turunan TenagaMedis
├── RekamMedis.cs         # rekam medis, dimiliki setiap Pasien
├── RumahSakit.cs         # composition: memiliki List<Orang>
├── Program.cs            # Main(): instruksi tugas + 6 soal
├── JAWABAN.md            # jawaban lengkap 6 soal
└── README.md
```

Semua kelas berada pada namespace `tugas_praktikum`, begitu juga `Program`
(`internal class Program`).

---

## How to run

```bash
dotnet run
```

Requirements: .NET SDK 10.0 atau lebih baru.

---

## Isi Main()

### Bagian A - Penyiapan data (instruksi 1, 2, 3)

Membuat objek `RumahSakit`, membuat 6 objek orang dari setiap kelas, lalu
menambahkannya dengan `TambahOrang()`.

### Bagian B - Tampilkan semua data (instruksi 4)

Memanggil `DaftarOrang()` yang menampilkan seluruh data lewat `InfoOrang()`.

### Bagian C - Demonstrasi polymorphism (instruksi 5)

Memanggil `rs.JalankanAktivitas()`, yang memanggil `Aktivitas()` pada setiap objek
di dalam daftar. Satu method tersebut menghasilkan perilaku berbeda sesuai tipe
aslinya.

```text
[Orang]         -> melakukan kegiatan umum.
[Pasien]        -> menunggu giliran berobat, keluhan: Batuk kering.
[PasienAnak]    -> menangis dan perlu dihibur orang tua.
[PasienDewasa]  -> berkonsultasi dengan dokter.
[Dokter]        -> memeriksa pasien sebagai spesialis Penyakit Dalam.
[Perawat]       -> memantau kondisi pasien dan membantu dokter.
```

### Bagian D - Panggil method khusus (instruksi 6)

Menggunakan pattern matching (`if (o is PasienAnak pa)`) untuk memanggil
`Menangis()`, `Konsultasi()`, `CekKeluhan()`, `Diagnosa(Pasien)`,
`CekPasien(Pasien)`, dan `CekSpesialis()` sesuai tipe objeknya.

`Diagnosa()` dan `CekPasien()` menerima objek `Pasien` sebagai parameter,
sehingga dokter dan perawat benar-benar memeriksa data pasien (nama, umur,
keluhan) tanpa perlu menyimpannya di dalam class masing-masing.

### SOAL 1 - SOAL 6

Implementasi langsung dari 6 soal pada lembar tugas. Penjelasan jawabannya
tertulis sebagai komentar ringkas di atas tiap bagian, sedangkan jawaban lengkap
versi panjang ada di `JAWABAN.md`.

| Soal | Isi |
|---|---|
| 1 | `Aktivitas()` pada objek Dokter dan Pasien |
| 2 | `Diagnosa(Pasien)` pada objek Dokter |
| 3 | Informasi lengkap (nama, umur, spesialisasi) dari objek Dokter |
| 4 | `Menangis()` pada objek PasienAnak |
| 5 | Variabel bertipe `Orang` diisi objek `Perawat`, lalu `Aktivitas()` |
| 6 | Kesimpulan |

---

## Konsep yang dipakai

| Konsep | penjelasan | Contoh kode |
|---|---|---|
| Inheritance | Kelas anak mewarisi data & method induk | `class Dokter : TenagaMedis` |
| Virtual | Method yang boleh ditulis ulang anak | `public virtual void Aktivitas()` |
| Override | Menulis ulang method virtual induk | `public override void Aktivitas()` |
| Polymorphism | Satu pemanggilan, banyak perilaku | `o.Aktivitas()` untuk 6 tipe |
| Upcasting | Objek anak disimpan pada variabel induk | `Orang oPerawat = rina;` |
| Downcasting | Mengambil kembali tipe asli objek | `if (o is Perawat p) p.CekPasien(hendra);` |
| Dependency | Objek diberikan sebagai parameter | `d.Diagnosa(sari)` |
| Abstraction | Class abstract dengan method abstract | `TenagaMedis` abstract, wajib `TugasUtama()` |