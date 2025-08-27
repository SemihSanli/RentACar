# 🚗 AI Destekli Araç Kiralama Projesi - .NET Core 8.0 🏎️✨

---

## 🔹 Proje Hakkında

Bu proje, **.NET Core 8.0**, **Entity Framework** ve modern yazılım tasarım desenleri kullanılarak geliştirilmiş **AI destekli bir araç kiralama sistemi**dir.  
Proje tamamen **katmanlı mimari** üzerine kurulmuş, **SOLID prensiplerine sadık kalınmış** ve **Clean Code** yaklaşımı ile yazılmıştır.  

Kullanılan tasarım desenleri:  
- **Generic Repository Design Pattern**  
- **MediatR & CQRS**  

Proje, kullanıcı deneyimini artırmak ve yönetimsel süreçleri kolaylaştırmak için **AI entegrasyonu**, **dinamik filtreleme**, **raporlar**, **rezervasyon yönetimi** ve **gelişmiş API tüketimi** ile donatılmıştır.

---

## 🛠️ Kullanılan Teknolojiler

- **Backend:** .NET Core 8.0  
- **ORM:** Entity Framework Core  
- **Tasarım Desenleri:** Generic Repository, CQRS, MediatR  
- **Mail Otomasyonu:** MailKit + SMTP  
- **AI Entegrasyonu:** OpenAI GPT-4-o-mini  
- **Harita / Yakıt / Havaalanı API’leri:** RapidAPI üzerinden (GasPrice, Airports API, Country State City)  
- **Frontend:** Razor Pages / ViewComponents ile dinamik ve temiz yapı  

---

## 🤖 AI Destekli Özellikler

### 1️⃣ Mail Otomasyonu
- Kullanıcı, **anasayfadaki iletişim kısmından** mesaj gönderir.  
- Mesaj veritabanına düştüğü anda, **OpenAI GPT-4-o-mini** modeli devreye girer.  
- Kullanıcının mesajına **gönderdiği dilde yanıt** verilir. (Dil algılama AI tarafından otomatik yapılır)  

### 2️⃣ Araç Öneri Asistanı
- Kullanıcı araç kiralamak istediğinde veya kararsız kaldığında, **prompt alanına isteklerini detaylıca yazar**.  
- "AI'DAN 3 FARKLI ÖNERİ AL" butonuna tıklayınca GPT-4-o-mini modeli şu şekilde öneriler üretir:
  1. **Pratik Uzman:** Bütçe dostu ve günlük kullanıma uygun araçlar  
  2. **Premium Uzman:** Lüks ve deneyim odaklı araç seçenekleri  
  3. **Güvenlik Uzmanı:** Maksimum güvenlik ve konfor odaklı araçlar  

---

## 🚗 Araç Rezervasyon Sistemi

1. Kullanıcı **dropdown listeden araç markasını seçer** ve listelenen araçları görür.  
2. Araçların bulunduğu **havaalanlarını filtreleyebilir**.  
3. **Yakıt Hesaplama:**  
   - Başlangıç ve varış lokasyonunu seçer  
   - Yakıt türünü seçer  
   - Tahmini mesafe sistem tarafından hesaplanır  
   - RapidAPI üzerinden **Gas Price API** ile güncel yakıt fiyatları alınır  
   - Hesaplanan değerler: `Toplam Mesafe`, `Toplam Yakıt`, `Toplam Maliyet`, `Varış Süresi`  
4. Kullanıcı, **teslim ve alım tarihlerini seçerek araç kiralayabilir**  

> Not: Yakıt ve maliyet hesaplamaları tahminidir.  

---

## 📊 Kullanıcı Paneli

Kullanıcı admin panelinde şunları yönetebilir:  
- **Dashboard:** İstatistikler, araç ve rezervasyon özetleri  
- **Araçlar & AI Araç Öneri Asistanı**  
- **Rezervasyonlar**  
- **Referanslar, Personeller, Slider, Hizmetler**  

Özellikler:  
- CRUD işlemleri (Create, Read, Update, Delete)  
- Resim gerektiren alanlarda **ön izleme**  
- Filtreleme işlemleri: araç, referans, çalışan, şehir listeleri  

---

## 🌐 RapidAPI Kullanımı

- **GasPrice API** – Anlık yakıt fiyatları  
  Endpoint: `https://gas-price.p.rapidapi.com/europeanCountries`  

- **Country State City API** – Türkiye şehirleri  
  Endpoint: `https://country-state-city-search-rest-api.p.rapidapi.com/cities-by-countrycode?countrycode=TR`  

- **Airports API** – Havaalanları  
  Endpoint: `https://airports-api2.p.rapidapi.com/airports/country/`  

> DTO ve ViewModels kullanılarak API verileri işlenir ve kullanıcıya sunulur.  

---

## 🏗️ Mimari ve Tasarım Desenleri

### Generic Repository Design Pattern
- CRUD işlemlerini **standart ve tekrar kullanılabilir** hale getirir  
- Farklı entityler için aynı repository altyapısı kullanılabilir  
- Kod tekrarını minimize ederek **bakımı kolay ve okunabilir yapı** sağlar  
- Örnek kullanım:
``csharp
public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}
- Bu pattern ile Entity Framework sorgularını ve veritabanı işlemlerini tek tip bir yapı üzerinden yönetiyoruz

### CQRS & MediatR Design Pattern

  - Veritabanı işlemleri Query (okuma) ve Command (yazma) olarak ayrılır

- MediatR, uygulama içinde dekaratif bir mesajlaşma ve handler yönetimi sağlar

- Servisleri tek tek değil, Service Registration üzerinden topluca kaydediyoruz:

- services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));


- Bu yapı ile:

- Kod daha modüler ve test edilebilir hale gelir

- Komut ve sorgular ayrı handler’lar tarafından işlenir

- CQRS prensibi ile okuma ve yazma operasyonları ayrıştırılır

### ViewComponents
- Dinamik içerik ve ön izleme gerektiren alanlarda kullanılır

- Kod kirliliğini azaltır ve tekrar kullanılabilir bileşenler oluşturur
---

## ✉️ Mail Otomasyonu

- **MailKit** paketi ile SMTP üzerinden gönderim  
- Kullanıcı mesajına AI tabanlı yanıt  
- Çok dilli destek  

---

## ⚡ Temel Özellikler

- **Anasayfa:** Öne çıkanlar, hakkımızda, hizmetlerimiz, sevilen araçlarımız, güçlü ekibimiz, kullanıcı yorumları, iletişim  
- **Araç Listesi:** Markaya göre filtreleme, havaalanı filtreleme, yakıt ve maliyet tahmini  
- **Admin Paneli:** Dashboard, araçlar, rezervasyonlar, referanslar, personeller, slider, hizmetler, AI araç öneri asistanı  
- **Filtreleme ve Önizleme:** Resim URL’si girildiğinde anlık ön izleme  

---

## 🔧 Entity Framework Kullanımı

- Özel şartlı sorgular ve filtrelemeler  
- Rezervasyonları isimleri ile birlikte getirme  
- İstatistikler: Referans, araç sayısı, son 5 araç, vs.  

---

## 📌 Özet

Bu proje; **AI destekli**, **katmanlı mimari**, **Clean Code**, **SOLID prensipleri**, **CQRS + MediatR** ve **Generic Repository** desenleriyle geliştirilmiş, kullanıcı ve admin deneyimini öncelikli tutan modern bir araç kiralama platformudur.  

---

## 💡 Ekran Görüntüleri & Demo




https://github.com/user-attachments/assets/3b86d656-d132-4ea3-b813-eddf3cc4fb12




<img width="2537" height="913" alt="Ekran görüntüsü 2025-08-27 180612" src="https://github.com/user-attachments/assets/aa3f86e2-d726-46bf-9be6-1467719d7c1a" />
<img width="2528" height="1199" alt="Ekran görüntüsü 2025-08-27 180755" src="https://github.com/user-attachments/assets/17596da0-6790-41c4-a369-19936a6e6738" />
<img width="2543" height="1210" alt="Ekran görüntüsü 2025-08-27 180807" src="https://github.com/user-attachments/assets/d56fa0cb-5c3c-4690-9065-5b7a62abd247" />
<img width="2535" height="825" alt="Ekran görüntüsü 2025-08-27 175002" src="https://github.com/user-attachments/assets/22b11fc4-b70f-498b-99e9-cfb1e771ca62" />
<img width="2537" height="1264" alt="Ekran görüntüsü 2025-08-27 175009" src="https://github.com/user-attachments/assets/67cfd1ad-90c7-4e46-99c3-27c836f75585" />
<img width="2531" height="1262" alt="Ekran görüntüsü 2025-08-27 180322" src="https://github.com/user-attachments/assets/a9bfffed-9f04-4865-b7cb-b70b3cdfeeb7" />
<img width="2542" height="1158" alt="Ekran görüntüsü 2025-08-27 191117" src="https://github.com/user-attachments/assets/228ef062-e314-4e20-94d2-ab9edd9a56f7" />
<img width="2542" height="847" alt="Ekran görüntüsü 2025-08-27 191126" src="https://github.com/user-attachments/assets/36c943a0-d3fe-4a2b-8ddf-1168ad71cecb" />
<img width="2542" height="793" alt="Ekran görüntüsü 2025-08-27 191140" src="https://github.com/user-attachments/assets/74cba3d8-9d98-4ae9-847a-8d9b54d22c34" />
<img width="680" height="692" alt="Ekran görüntüsü 2025-08-25 185032" src="https://github.com/user-attachments/assets/d3c70f4c-15f4-469b-92c1-4502104cd592 " />


![1](https://github.com/user-attachments/assets/80f49bb8-e6e1-4840-853f-624f8e1836be)

<img width="689" height="698" alt="Ekran görüntüsü 2025-08-25 184954" src="https://github.com/user-attachments/assets/f4a98628-40e3-4b33-b0b9-64eec887d45c" />

![2](https://github.com/user-attachments/assets/8c69d55a-e4ae-45b0-b580-7397f0f8589c)

<img width="684" height="694" alt="Ekran görüntüsü 2025-08-25 185124" src="https://github.com/user-attachments/assets/1bf90f48-7ce1-4a16-a9e2-f98abc144d20" />

![3](https://github.com/user-attachments/assets/d325af32-4bea-4768-a63b-23950c57f332)


<img width="2535" height="1260" alt="Ekran görüntüsü 2025-08-27 183206" src="https://github.com/user-attachments/assets/719c7a32-abd7-42bd-b25f-15079668f354" />
<img width="2536" height="1265" alt="Ekran görüntüsü 2025-08-27 183130" src="https://github.com/user-attachments/assets/b0f87fbf-daa9-47f6-9245-9aaea1a7bae2" />
<img width="2302" height="1178" alt="Ekran görüntüsü 2025-08-27 183143" src="https://github.com/user-attachments/assets/8e4bdb46-9ba6-4bd1-a889-db78ae86fb85" />

<img width="2536" height="1231" alt="Ekran görüntüsü 2025-08-27 182950" src="https://github.com/user-attachments/assets/b24be930-2ab5-4ce9-81d4-663882e40b9b" />
<img width="2544" height="1265" alt="Ekran görüntüsü 2025-08-27 182956" src="https://github.com/user-attachments/assets/2d3f5acd-0b32-4c6e-8e33-90bef86eb7b5" />
<img width="2542" height="1256" alt="Ekran görüntüsü 2025-08-27 183010" src="https://github.com/user-attachments/assets/168e90fe-b9e6-4b2a-b123-7d5e5af76101" />
<img width="2544" height="1265" alt="Ekran görüntüsü 2025-08-27 183025" src="https://github.com/user-attachments/assets/e8a65f9e-6359-49da-b28e-043a56dec074" />
<img width="2541" height="1268" alt="Ekran görüntüsü 2025-08-27 183032" src="https://github.com/user-attachments/assets/6fc8dcde-abeb-4728-8c55-00f9a49105d2" />
<img width="2555" height="1260" alt="Ekran görüntüsü 2025-08-27 183046" src="https://github.com/user-attachments/assets/31ff9b77-ffcb-4fa4-9d9d-1c53fc1775f4" />
<img width="2549" height="1252" alt="Ekran görüntüsü 2025-08-27 183303" src="https://github.com/user-attachments/assets/462d9dcb-9a97-414a-aa72-96c76a33fa3d" />

<img width="2550" height="294" alt="Ekran görüntüsü 2025-08-27 183234" src="https://github.com/user-attachments/assets/1a0d0ccd-630b-4bf0-9bb2-fd6c83a20f31" />
<img width="2546" height="1264" alt="Ekran görüntüsü 2025-08-27 183242" src="https://github.com/user-attachments/assets/c246838a-b8b4-47c6-83b3-20616cc07f67" />
<img width="2551" height="1257" alt="Ekran görüntüsü 2025-08-27 183251" src="https://github.com/user-attachments/assets/22975805-2efd-4a2d-8cdb-7a5d2760d171" />

<img width="2550" height="1243" alt="Ekran görüntüsü 2025-08-27 183311" src="https://github.com/user-attachments/assets/dd590528-d82e-480b-a39d-fd8191472cf0" />
<img width="2546" height="1213" alt="Ekran görüntüsü 2025-08-27 183317" src="https://github.com/user-attachments/assets/47adba21-e968-4adb-98a3-5360891777c9" />
<img width="2548" height="1201" alt="Ekran görüntüsü 2025-08-27 183324" src="https://github.com/user-attachments/assets/4f6a96a2-5db9-4c4e-ac85-b89d6953d83a" />

<img width="2544" height="1193" alt="Ekran görüntüsü 2025-08-27 183330" src="https://github.com/user-attachments/assets/b04476ee-bc4e-447a-9ef1-28199684cc80" />
<img width="2547" height="1202" alt="Ekran görüntüsü 2025-08-27 183336" src="https://github.com/user-attachments/assets/4ad15e61-1d9d-4973-b3e7-083c4ed40a7a" />

---

