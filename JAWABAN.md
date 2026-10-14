# Jawaban Praktikum — Inheritance & Polymorphism

## Soal 1
Soal	: Jalankan method Aktivitas() pada objek Dokter dan Pasien. Apa yang terjadi? Mengapa demikian?
Jawaban	: Ketika method Aktivitas() dijalankan pada objek Dokter dan Pasien, masing-masing objek menampilkan 
		  aktivitas yang berbeda sesuai dengan kelasnya. Meskipun nama method yang dipanggil sama, hasilnya 
		  menyesuaikan jenis objek yang menjalankannya.
		  
		  Hal ini terjadi karena method Aktivitas() pada kelas Orang menggunakan kata kunci virtual, sehingga 
		  dapat di-override oleh kelas turunannya. Kelas Dokter dan Pasien kemudian memiliki implementasi 
		  Aktivitas() masing-masing menggunakan kata kunci override.
		  
		  Dengan demikian, ketika method tersebut dipanggil, program akan menjalankan implementasi yang 
		  sesuai dengan tipe asli objek saat program berjalan. Mekanisme ini disebut polymorphism, yang 
		  memungkinkan satu method memiliki perilaku berbeda pada objek yang berbeda.

---

## Soal 2
Soal	: Jalankan method Diagnosa() pada objek Dokter. Apa yang terjadi? Mengapa demikian?
Jawaban	: Ketika method Diagnosa() dijalankan pada objek Dokter, program akan menampilkan informasi 
		  pemeriksaan pasien dan menentukan hasil diagnosis berdasarkan spesialisasi dokter. Hasil diagnosis 
		  tersebut kemudian disimpan ke dalam property HasilDiagnosa pada objek RekamMedis milik pasien.

		  Sebelum pemeriksaan dilakukan, hasil diagnosis masih berisi nilai awal, yaitu "Belum ada". Setelah 
		  method Diagnosa() dijalankan, nilai tersebut berubah sesuai dengan hasil pemeriksaan. Method 
		  Diagnosa() hanya dimiliki oleh kelas Dokter, sehingga tidak dapat dipanggil secara langsung melalui 
		  variabel yang bertipe Orang, meskipun variabel tersebut menyimpan objek Dokter. Hal ini karena 
		  compiler memeriksa method berdasarkan tipe variabel yang digunakan.

		  Selain itu, method ini menerima objek Pasien sebagai parameter. Dengan begitu, dokter dapat 
		  memeriksa pasien yang diberikan saat method dipanggil, termasuk objek PasienAnak maupun 
		  PasienDewasa, karena keduanya merupakan turunan dari kelas Pasien.
---

## Soal 3
Soal	: Apakah Anda dapat menampilkan informasi lengkap (nama, umur, spesialisasi) dari objek Dokter? 
		  Bagaimana caranya?
Jawaban	: Bisa. Informasi tersebut berasal dari dua tingkat kelas yang berbeda, sehingga harus digabungkan: 
		  nama dan umur diwarisi dari kelas Orang dan dibaca memakai InfoOrang(), sedangkan spesialisasi 
		  diwarisi dari kelas TenagaMedis dan dibaca memakai CekSpesialis(). InfoOrang() saja tidak 
		  cukup karena method itu didefinisikan di Orang yang tidak mengenal property Spesialisasi, dan 
		  CekSpesialis() saja juga tidak cukup karena tidak memuat nama dan umur. Ada dua cara untuk 
		  menampilkannya:
			1. Memanggil dua method pada objek yang sama, lalu hasilnya berurutan.
			2. Membaca property langsung (Nama, Umur, Spesialisasi), lalu mencetaknya satu per satu 
			   dalam satu blok.

		  Tapi, di dalam InfoOrang() dipakai GetType().Name untuk mencetak kolom "Kelas". Artinya 
		  meskipun method itu hanya didefinisikan sekali di Orang, hasilnya tetap menyesuaikan tipe asli 
		  objek.

---

## Soal 4
Soal	: Jalankan method Menangis() pada objek PasienAnak. Apa yang terjadi? Mengapa demikian?
Jawaban	: Ketika method Menangis() dijalankan pada objek PasienAnak, program menampilkan pesan bahwa pasien 
		  anak menangis selama berobat karena mengalami demam dan membutuhkan hiburan dari orang tuanya agar 
		  lebih tenang saat diperiksa.

		  Hal ini terjadi karena method Menangis() secara khusus dibuat di dalam kelas PasienAnak. Oleh 
		  karena itu, method tersebut dapat dipanggil secara langsung melalui objek atau variabel yang 
		  bertipe PasienAnak, tetapi tidak dapat dipanggil langsung melalui variabel bertipe Pasien tanpa 
		  melakukan pengecekan atau konversi tipe terlebih dahulu.

		  Meskipun demikian, objek PasienAnak tetap dapat menggunakan property Keluhan karena property 
		  tersebut diwarisi dari kelas Pasien. Selain itu, ketika method Aktivitas() dipanggil, program dapat
		  menampilkan nama kelas PasienAnak karena implementasi method tersebut menggunakan GetType().Name 
		  untuk mengetahui tipe asli objek.

		  Hal ini menunjukkan bahwa pewarisan memungkinkan kelas anak menggunakan anggota kelas induknya 
		  sekaligus memiliki perilaku khusus sesuai kebutuhan.
---

## Soal 5
Soal	: Buatlah variabel bertipe Orang, lalu isi dengan objek Perawat. Jalankan method Aktivitas(). Apa 
		  yang terjadi? Mengapa demikian?
Jawaban	: Setelah variabel bertipe Orang diisi objek Perawat, lalu Aktivitas() dijalankan, yang tercetak 
		  adalah versi Perawat, yaitu memantau kondisi pasien dan membantu dokter, bukan versi Orang yaitu 
		  melakukan kegiatan umum. Hal tersebut terjadi karena:
			1. Pengisiannya adalah proses upcasting, yaitu mengubah arah tipe dari kelas anak ke kelas induk
			   (Perawat menjadi Orang). Proses ini dilakukan secara implisit karena selalu aman, sebab objek
			   Perawat memang memiliki seluruh anggota Orang. Sebaliknya, downcasting dari induk ke anak 
			   tidak boleh dilakukan secara implisit.
			2. Walaupun variabelnya bertipe Orang, objek yang tersimpan di dalamnya tetap Perawat. Compiler 
			   hanya menghasilkan kode untuk memanggil versi virtual Aktivitas(), lalu ketika program 
			   berjalan runtime memanggil versi yang cocok dengan tipe asli objek.
			3. Method khas anak tidak bisa dipanggil, karena CekPasien(Pasien) hanya ada di kelas Perawat 
			   sehingga tidak dikenal oleh variabel bertipe Orang. Agar bisa dipanggil, harus downcasting 
			   lebih dulu memakai operator 'is' (paling aman), 'as' (menghasilkan null bila gagal), atau 
			   casting klasik (Tipe) yang bisa menyebabkan runtime error bila tipenya keliru.

		  Kesimpulan: tipe deklarasi menentukan method apa yang boleh dipanggil saat compile, sedangkan tipe
		  runtime menentukan method mana yang benar-benar dieksekusi.

---

## Soal 6
Soal	: Kesimpulan apa yang dapat Anda ambil?
Jawaban	: Berdasarkan program yang telah dijalankan, dapat disimpulkan bahwa konsep inheritance memungkinkan
		  kelas turunan menggunakan property dan method dari kelas induknya tanpa perlu menulis ulang kode 
		  yang sama. Sebagai contoh, property Nama dan Umur yang terdapat pada kelas Orang dapat digunakan 
		  oleh kelas Dokter, Perawat, dan kelas turunan lainnya.

		  Selain itu, konsep polymorphism memungkinkan method dengan nama yang sama menghasilkan perilaku 
		  berbeda sesuai dengan objek yang menjalankannya. Hal ini terlihat pada method Aktivitas() yang 
		  dapat menampilkan aktivitas berbeda untuk objek Dokter, Perawat, dan pasien.

		  Program ini juga menunjukkan bahwa tipe variabel dan tipe asli objek memiliki fungsi yang 
		  berbeda. Tipe variabel menentukan anggota apa saja yang dapat diakses saat penulisan kode, 
		  sedangkan tipe asli objek menentukan implementasi method virtual yang dijalankan ketika program 
		  berjalan.

		  Dengan menerapkan konsep-konsep tersebut, program menjadi lebih terstruktur, mengurangi 
		  pengulangan kode, dan memudahkan penambahan kelas baru. Setiap kelas dapat memiliki karakteristik 
		  dan perilaku masing-masing tanpa harus mengubah seluruh bagian program yang sudah ada.
