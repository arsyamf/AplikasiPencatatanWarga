# 🏡 Aplikasi Pencatatan Warga

Aplikasi desktop sederhana berbasis **C# (.NET WinForms)** dan **SQLite**, yang digunakan untuk mencatat dan mengelola data warga secara lokal. Cocok untuk pengurus RT/RW, dusun, kelurahan, atau komunitas lainnya.

<img src="https://github.com/user-attachments/assets/57da3c0f-5bdb-462f-bbef-9fabf3567368" alt="Tampilan Aplikasi" width="600"/>

---

## ✨ Fitur Utama

- 📋 Tambah, ubah, dan hapus data warga
- 🔍 Navigasi data mudah dengan DataGridView
- 🗃️ Database lokal menggunakan SQLite (tidak butuh koneksi internet)
- 📌 Data yang dicatat meliputi:
  - NIK
  - Nama Lengkap
  - Tanggal Lahir
  - Jenis Kelamin
  - Alamat
  - Pekerjaan
  - Status Perkawinan

---

## 🛠️ Teknologi yang Digunakan

- **Bahasa Pemrograman:** C#
- **Framework:** .NET WinForms
- **Database:** SQLite
- **IDE:** Visual Studio Community Edition

---

## 🚀 Cara Menjalankan Aplikasi

Berikut langkah-langkah untuk menjalankan aplikasi setelah mengunduh file `.zip` dari [Releases](https://github.com/arsyamf/AplikasiPencatatanWarga/releases):

### 1. **Klik file ZIP yang telah diunduh**
<img src="https://github.com/user-attachments/assets/b05768f0-cbb7-4d32-9afe-2ecce0031e77" width="600"/>

---

### 2. **Klik kanan pada file ZIP**
<img src="https://github.com/user-attachments/assets/b19ef0ae-4d7c-4cf7-8990-2c84e232f4a0" width="400"/>

---

### 3. **Pilih "Extract Here"**
<img src="https://github.com/user-attachments/assets/71a79ea3-7d94-4fc0-8bc2-44ab387d7aac" width="600"/>

---

### 4. **Buka folder hasil ekstrak**
<img src="https://github.com/user-attachments/assets/38f3804a-b1da-46fa-8600-b8bf497e8cfd" width="500"/>
<br/>
<img src="https://github.com/user-attachments/assets/e30504b2-55a6-4992-9045-ec7431b08955" width="500"/>

---

### 5. **Jalankan aplikasi**
Klik dua kali pada file `.exe` untuk membuka aplikasi:

<img src="https://github.com/user-attachments/assets/3e435d4e-b96a-4724-a11b-3d9438914abe" width="500"/>

---

## ✅ Validasi Form Input

Aplikasi ini memiliki sistem validasi otomatis untuk memastikan data yang dimasukkan benar dan lengkap:

| Field               | Validasi                                                                 | Pesan yang Ditampilkan               |
|--------------------|--------------------------------------------------------------------------|--------------------------------------|
| **NIK**             | Harus 16 digit & unik                                                    | `NIK harus 16 karakter.`<br>`NIK sudah terdaftar.` |
| **Nama Lengkap**    | Tidak boleh kosong                                                       | `Nama Lengkap harus diisi.`          |
| **Jenis Kelamin**   | Harus dipilih dari daftar                                                | `Pilih Jenis Kelamin.`               |
| **Alamat**          | Tidak boleh kosong                                                       | `Alamat harus diisi.`                |
| **Status Perkawinan** | Harus dipilih dari daftar                                              | `Pilih Status Perkawinan.`           |
| **Pekerjaan**       | Jika kosong, otomatis diisi dengan "belum bekerja"                       | *(otomatis, tanpa pesan)*            |



