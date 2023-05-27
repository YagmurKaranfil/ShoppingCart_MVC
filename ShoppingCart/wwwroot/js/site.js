$(function () {
    //$(function () { ... }); kısmı, belge yüklendiğinde çalıştırılacak olan bir jQuery işlevi tanımlar.
    //Bu işlev, belgenin hazır olduğunda içerisindeki kodu çalıştırmak için kullanılır.

// sayfadaki "confirmDeletion" adında bir CSS sınıfına sahip olan tüm < a > etiketlerini seçer.
//Eğer bu sınıfa sahip en az bir öğe bulunursa, bir tıklama olayı dinleyicisi ekler.Tıklama olayı tetiklendiğinde,
//        kullanıcıya "Confirm deletion"(Silme işlemini onaylayın) mesajı görüntülenir ve onaylanmazsa işlem durdurulur.


        if ($("a.confirmDeletion").length) {
                $("a.confirmDeletion").click(() => {
                        if (!confirm("Confirm deletion")) return false;
                });
        }

// sayfadaki "alert" sınıfına ve "notification" sınıfına sahip bir < div > öğesinin 
//varlığını kontrol eder.Bu öğe mevcutsa, setTimeout() işlevi kullanılarak 2000 milisaniye(2 saniye) 
//sonra bu öğenin solması(fadeOut) işlemi gerçekleştirilir.Bu genellikle bildirimleri otomatik olarak gizlemek için kullanılır.


        if ($("div.alert.notification").length) {
                setTimeout(() => {
                        $("div.alert.notification").fadeOut();
                }, 2000);
        }

});

//readURL(input) fonksiyonu, bir resim dosyası yüklendiğinde çağrılan bir işlevi temsil eder.
//Bu fonksiyon, bir < input type = "file" > elemanından seçilen dosyanın önizlemesini yapar.
//input parametresi, dosya seçme alanını temsil eder.


//readURL(input) işlevi içinde, seçilen dosyanın varlığı kontrol edilir(input.files && input.files[0]).Ardından,
//    bir FileReader nesnesi oluşturulur ve dosya yükleme işlemi başlatılır.Dosya yükleme tamamlandığında, onload olayı
// tetiklenir ve seçilen dosyanın veri URL'si kullanılarak bir <img> öğesinin src özelliği güncellenir.
//Böylece, seçilen resim önizlemesi sayfada görüntülenir ve boyutu 200x200 piksel olarak ayarlanır.


function readURL(input) {
        if (input.files && input.files[0]) {
                let reader = new FileReader();

                reader.onload = function (e) {
                        $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
                };

                reader.readAsDataURL(input.files[0]);
        }
}





