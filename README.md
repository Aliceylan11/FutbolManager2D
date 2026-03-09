# Futbol Manager 2D (WinForms Sürümü)

Futbol Manager 2D, C# ve .NET Windows Forms (WinForms) kullanılarak geliştirilmiş, nesne yönelimli programlama (OOP) prensiplerini temel alan bir futbol menajerlik simülasyonudur. 
Proje, dinamik bir maç motoru ve canlı grafik çizim yeteneklerini bir araya getirir.

## 🚀 Öne Çıkan Özellikler

* **Dinamik Maç Motoru:** Oyuncuların yeteneklerine (hız, teknik, pas, bitiricilik vb.) göre karar verdiği gerçek zamanlı simülasyon.
* **Görsel Saha Simülasyonu:** `SahaCizici` sınıfı ile maçın gidişatını görsel bir panel üzerinde takip etme imkanı.
* **Gelişmiş OOP Yapısı:** Polimorfizm ve kalıtım prensipleri kullanılarak tasarlanmış futbolcu sınıfları.
* **Kadro Yönetimi:** Takım kurma, oyuncu seçimi ve taktiksel dizilim yönetimi.

## 🛠️ Teknik Mimari

Proje, sürdürülebilir ve geliştirilebilir bir yapı için modüler sınıflardan oluşmaktadır:

* **Futbolcu (Base Class):** Tüm oyuncuların temel özelliklerini (ad, soyad, dayanıklılık, hız vb.) ve ortak davranışlarını içerir.
* **Mevki Sınıfları:** `Kaleci`, `Defans`, `OrtaSaha` ve `Forvet` sınıfları, temel sınıftan türetilerek mevkiye özel yetenek skorları ve mantıklarını barındırır.
* **MacMotoru:** Maçın senaryosunu, pozisyon olasılıklarını ve gol/kart mekaniklerini yöneten merkezi mantık birimi.
* **SahaCizici:** WinForms grafik kütüphanelerini kullanarak saha ve oyuncu hareketlerini simüle eden görselleştirme motoru.
* **Veritabani:** Oyuncu ve takım verilerini yöneten veri yönetim katmanı.

## 💻 Kullanılan Teknolojiler

* **Dil:** C#
* **Framework:** .NET Framework / .NET (WinForms)
* **IDE:** Visual Studio

## ⚙️ Kurulum ve Çalıştırma

1.  Depoyu bilgisayarınıza klonlayın.
2.  `Futbol.slnx` veya `Futbol.csproj` dosyasını Visual Studio ile açın.
3.  Gerekli bağımlılıkların yüklenmesi için projeyi derleyin (Build).
4.  `F5` tuşuna basarak uygulamayı çalıştırın.

---
