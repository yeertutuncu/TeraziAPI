# TeraziAPI
DENSI FS8000 Terazi için üretilen, masaüstünde systemTray'da çalışan, WebApi yardımıyla veri yayınlayan bir yazılımdır

## Özellikler

- DENSI FS8000 Modeli terazi üzerinden veri okumaya yarar
- Masaüstüne yüklenen bu uygulama Api servisi kullanarak Json formatında sonuç döndürür
- Cihaz tanıtımında yer alan veri formatına uygun kodlanmıştır. İstenildiği takdirde WeightData.GetValues() metodunda gerekli düzenlemeler yapılabilir.
- localhost üzerinde bir port üzerinden yayın yapar, ilgili porta GET isteği yapılarak veri elde edilir

> Not: Tüm bağlantı `Program.cs` altında `SerialObject` nesnesi üzerinden sağlanmaktadır.


## Servis Bilgileri
```sh
Servis http://localhost:6161/ üzerinden yayın yapmaktadır
```
```sh
İstenildiği takdirde 'setting.json' dosyasından port değişikliği yapılabilir
```
# Ürün

##### DENSI FS8000
![N|fff](http://densipanel.kmk.net.tr/resimler/resimlerim/1_20111223145120.jpg)
