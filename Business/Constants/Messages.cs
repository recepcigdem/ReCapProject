
using Entities.Dtos;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Get = "Getirildi";
        public static string Add = "Eklendi";
        public static string Update = "Güncellendi";
        public static string Delete = "Silindi";

        public static string MinCharacter = "Açıklama minimum 2 karakter olmalı";
        public static string MinPrice = "Fiyat 0 dan büyük olmalıdır";
        public static string ReturnDate = "Araç teslim tarihi hatalı";
        public static string CarImageLimitExceeded = "En fazla beş resim eklenebilir";

        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı Kayıt Başarılı!";
        public static string UserNotFound = "Kullanıcı Bulunamadı!";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";

        public static string AddCarImageMessage = "Araç resmi başarıyla eklendi";
        public static string EditCarImageMessage = "Araç resmi başarıyla güncellendi";
        public static string DeleteCarImageMessage = "Araç resmi başarıyla silindi";
        public static string AboveImageAddingLimit = "Araç maksimum resim sayısına ulaştı. Resim ekleyemezsiniz";
        public static string IncorrectFileExtension = "Kabul edilmeyen dosya uzantısı";
        public static string ImageNotFound = "Resim dosyası bulunamadı.";
        public static string CarImageNotFound = "Değiştirilmek istenen resim bulunamadı.";


    }
}
