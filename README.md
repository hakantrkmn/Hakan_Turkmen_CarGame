# Hakan_Turkmen_CarGame

 oyunda 2 adet level bulunuyor. her levelda 8 tane araç var. Yeni bir level oluşturmak için şuanki levellardan biri duplicate edilebilir.
 Daha sonra Path Creator objesinde bulunan Path Manager scriptinden pathler oluşturulabilir.Clear Paths diyerek oluşturulmuş tüm pathlar silinebilir. Instantiate Paths 
 butonu ile sıfır bir path oluşturulabilir. Her araba için oluşturacağımız giriş ve çıkış konumlarını tutan objeye path dedim. Oluşan path objesinin 2 adet child objesi var. Entrance ve Target. İkiside sürüklenip bırakılarak konumları ayarlanabilir.Path objesindeki thickness değerini değiştirerek çubuğu daha kalın yapabiliriz.
 Editorde entrancenin üstünde mavi çizgi ve "car direction" yazısı ile entrancede spawnlanacak arabanın yönü gösteriliyor. Path oluşturmak bu kadar. Oyun başlatıldığında kod
 otomatik olarak pathları algılıyor ve sırayla arabalar oynanıyor.

 Obstacle ayarlamak için istediğimiz şekli koyabiliriz. collider olması ve Obstacle Scripti olması yeterli.

kamerayı doğrudan bakacak şekilde ayarladım. o kısım istenmediği için uğraşmadım. oyun hoşuma gittiği için ilerde daha güzel bir kamera mekaniği ekleyeceğim.

assigmentta yazılan her şey projede eksiksiz bulunuyor. ben masaüstü 1080x1920 ölçülerinde çalıştım. Mobilde de çalışıyor. kamera açısı problem olabilir. assigmentta olmadığı için ek olarak uğraşmadım. 

 Son olarak GameData Scriptableındaki değerleri değiştirerek istediğimiz ileri hız, dönme hızı ve hareketten örnek olma süresini ayarlayabiliriz. Sample Time olarak adlandırdığım değer arabayı oynattığımızda kaç saniyede bir örnek olacağının değeridir. 0.2 değeri beni memnun etti. istediğe göre değiştirilebilir. 

 odin ve dotween assetlerini ekledim. odin editor için dotween de path için
