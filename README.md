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
> Opsiyonel olarak buraya ekran görüntüleri veya canlı demo linkleri eklenebilir.  

---

