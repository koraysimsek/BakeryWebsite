# 🍞 Bakery – Dinamik / Unlu Mamüller Web Uygulaması & Yönetim Paneli
Bu proje; fırın, pastane veya cafe işletmelerinin dijital varlıklarını yönetebilmesi için geliştirilmiş, n-tier arayüz mimarisine (Web API ve Web UI katmanlı) sahip, dinamik ve modern bir web uygulamasıdır.

Uygulama, sadece bir tanıtım sitesi olmanın ötesinde; şef kadrosu, ürün katalogu, hizmetler, müşteri geri bildirimleri ve abone yönetimi gibi tüm süreçlerin merkezi bir Yönetim Paneli (PurpleAdmin) üzerinden kontrol edilmesine olanak tanır.

# 🛠 Kullanılan Teknolojiler & Mimari Yapı

💻 ASP.NET Core 6.0 (Web API & Web UI)
Proje, veriyi sağlayan bir Web API katmanı ve bu veriyi kullanıcıya sunan Web UI katmanı olmak üzere iki ana parçadan oluşur. Bu ayrım, uygulamanın gelecekte mobil veya farklı platformlara kolayca entegre edilmesini sağlar.

🧩 DTO (Data Transfer Object) Kullanımı
Veri güvenliği ve performans için katmanlar arası veri transferleri DTO nesneleri ile yönetilir. Gereksiz veri yükünden kaçınılarak sadece ihtiyaç duyulan alanlar transfer edilir.

📊 Web API Tüketimi (HttpClient)
Web UI katmanı, verileri doğrudan veritabanından çekmek yerine, Web API üzerinden IHttpClientFactory kullanarak alır. Bu, gerçek dünya kurumsal mimarilerine uygun bir yaklaşımdır.

🛡️ Entity Framework Core 6.0 (Code First)
Veritabanı tabloları ve ilişkileri C# sınıfları ile tanımlanmış, Migration mekanizması ile SQL Server üzerinde otomatik olarak oluşturulmuştur.

🧱 View Components & Layout Mimari
Web sitesinin her bir bölümü (Hakkımızda, Hizmetler, Slider vb.) kendi iş mantığına sahip bağımsız ViewComponent yapıları olarak tasarlanmıştır. Bu sayede kod tekrarı önlenmiş ve modüler bir yapı elde edilmiştir.

⚙️ PurpleAdmin Yönetim Paneli
İşletme sahibinin ürünleri, kategorileri ve gelen mesajları anlık olarak takip edebilmesi için istatistiksel verilerle zenginleştirilmiş, kullanıcı dostu bir dashboard entegresi yapılmıştır.

# 🔍 Öne Çıkan Özellikler

🚀 Multi-Layer Architecture: Web API ve Web UI katmanlarının decoupled (bağımsız) çalışması.

📊 Dinamik Dashboard: Ürün sayıları, müşteri sayısı ve aboneliklerin anlık istatistiksel gösterimi.

🗂️ Kategori & Ürün Yönetimi: Ürünlerin kategorize edilerek tam yetkili CRUD (Ekle/Sil/Güncelle/Listele) işlemleri.

📩 İletişim & Abone Yönetimi: Müşterilerden gelen mesajların takibi ve bülten aboneliklerinin veritabanında saklanması.

🌙 Modern UI: Bootstrap tabanlı, karanlık mod destekli ve tüm cihazlara (Mobil/Tablet/Desktop) uyumlu responsive tasarım.

# 📸 Projeden Kareler (Web Sitesi)

<img width="1902" height="1068" alt="image" src="https://github.com/user-attachments/assets/75262fdf-2469-467f-aadb-89d06b32ca6a" />

<img width="1901" height="1074" alt="image" src="https://github.com/user-attachments/assets/e55dcb3d-765e-47bc-876e-9ea68b7970c9" />

<img width="1904" height="1074" alt="image" src="https://github.com/user-attachments/assets/885040ec-195a-4dcc-96c2-222c3bec0d8b" />

<img width="1898" height="1071" alt="image" src="https://github.com/user-attachments/assets/3e057560-2fdc-4d59-8958-a9d1a213713c" />

<img width="1900" height="1075" alt="image" src="https://github.com/user-attachments/assets/84656a36-e9c5-469a-bdfd-15ba3d687828" />

<img width="1907" height="1077" alt="image" src="https://github.com/user-attachments/assets/7fc14a2f-997e-4c1e-89f6-a5606a7781e0" />

<img width="1918" height="1078" alt="image" src="https://github.com/user-attachments/assets/54fdd5fd-f0f9-45e4-a289-961f8fcbe02b" />

# 🔑 Yönetim Paneli (PurpleAdmin)

<img width="1905" height="1079" alt="image" src="https://github.com/user-attachments/assets/42b12a44-24c3-4813-ac74-3dbe8ace1a87" />

<img width="1905" height="1077" alt="image" src="https://github.com/user-attachments/assets/7b16181f-9a6f-4f72-8191-a4e52fbeea0c" />

<img width="1903" height="1079" alt="image" src="https://github.com/user-attachments/assets/1c82a689-158f-41fc-ab7a-7d2f281e11bb" />

<img width="1899" height="1076" alt="image" src="https://github.com/user-attachments/assets/9fbb75ab-32ad-406f-9841-d5d74aa9797b" />

# 🚀 Kurulum Önerisi
Bakery.WebApi projesindeki appsettings.json veya 
BakeryContext
 içindeki bağlantı dizesini (Connection String) kendi local SQL Server'ınıza göre güncelleyin.
Package Manager Console üzerinden Update-Database komutunu çalıştırarak veritabanını oluşturun.
Önce API projesini, ardından Web UI projesini başlatarak uygulamayı test edebilirsiniz.
