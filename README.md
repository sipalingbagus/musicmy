![alt text](https://github.com/sipalingbagus/musicmy/blob/main/mockup%20aplikasi%20bagus.jpg?raw=true)

Aplikasi MyMusic adalah sebuah aplikasi berbasis Windows Forms yang dirancang untuk mengelola koleksi file musik dengan pendekatan event-driven programming. Aplikasi ini memungkinkan pengguna untuk menambahkan, mengedit, menghapus, serta memutar file audio langsung dari antarmuka pengguna. Selain itu, aplikasi ini terhubung dengan database MySQL, yang digunakan untuk menyimpan metadata lagu, seperti nama file dan lokasi file di sistem, sehingga data tetap terkelola meskipun aplikasi ditutup.

Alur aplikasi dimulai ketika pengguna membuka program, di mana antarmuka utama akan menampilkan daftar lagu yang telah tersimpan dalam database. Proses ini melibatkan koneksi ke database MySQL, pengambilan data, dan pemuatan data tersebut ke dalam komponen ListView. ListView ini menjadi pusat interaksi utama, memungkinkan pengguna untuk memilih file audio tertentu yang akan diedit, dihapus, atau diputar.

Fitur penambahan lagu bekerja melalui dialog file yang memungkinkan pengguna untuk memilih file audio dari penyimpanan lokal. Setelah file dipilih, aplikasi akan menyimpan informasi file tersebut ke dalam database dan menambahkan item baru ke dalam ListView. Proses ini memastikan bahwa daftar lagu dalam aplikasi selalu mencerminkan data yang ada di database.

Fitur pengeditan memberikan fleksibilitas bagi pengguna untuk mengganti file audio yang ada dengan file baru. Ketika pengguna memilih sebuah lagu dalam daftar dan memilih opsi edit, dialog file akan kembali muncul untuk memilih file pengganti. Setelah file baru dipilih, aplikasi akan memperbarui database dengan jalur file baru tersebut dan memperbarui tampilan ListView untuk mencerminkan perubahan.

Penghapusan lagu memungkinkan pengguna untuk menghapus data lagu baik dari database maupun dari antarmuka ListView. Ketika sebuah lagu dihapus, aplikasi akan memastikan bahwa data terkait di database juga dihapus, sehingga tidak ada data usang yang tertinggal.

Pemutaran file audio adalah fitur inti lain dari aplikasi ini. Ketika pengguna memilih sebuah lagu dan menekan tombol play, aplikasi menggunakan pustaka NAudio untuk memuat dan memutar file audio tersebut. Jika lagu lain diputar, aplikasi akan menghentikan pemutaran lagu saat ini sebelum memutar lagu yang baru, memastikan pengalaman mendengarkan yang lancar. Pengguna juga dapat menghentikan pemutaran kapan saja dengan menggunakan tombol stop.

Keunggulan aplikasi ini terletak pada sinkronisasi antara komponen antarmuka pengguna dan operasi di latar belakang, seperti manipulasi data dalam database dan pemutaran audio. Semua fitur ini dirancang untuk bekerja dengan cara yang responsif terhadap tindakan pengguna, menciptakan pengalaman yang efisien dan intuitif. Kombinasi antara pengelolaan data dan fungsi multimedia menjadikan MyMusic sebagai aplikasi yang serbaguna untuk kebutuhan manajemen koleksi musik pribadi.

