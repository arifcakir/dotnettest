Feature: OgrenciYonetimModulu
	Yazlımcı olarak
	Öğrenci Yönetim Sisteminde Öğrenci ile ilgili bölümleri yönetebilmek amacıyla 
	ekleme, silme, güncelleme ve listleme işlemlerini yapabilceğim bir modul istiyorum

Background: Ön hazırlıkları yap
	Given "http://localhost:5000" adresi açılır
	Then  Açılan sayfanın anasayfa olduğu görülür

@OgrenciEkleme
Scenario: Öğrenci Ekle
	Given Menüden öğrenci ekle linkine tıklanır
	And   Ekleme ekranında yer alan <Firstname>, <Lastname>, <Birthdate>, <Age>, <Gender> ve <StudentId> bilgileri girilir
	When  Kaydet butonuna tıklanılır
	Then  Öğrenci ekleme işleminin başarılı olduğu görülür

Examples: 
| Firstname | Lastname | Birthdate  | Age | Gender | StudentId |
| Murat     | Cabuk    | 10.10.1960 | 45  | Male   | 234567    |
| Murat2    | Cabuk    | 10.10.1960 | 45  | Male   | 234567    |
| Murat3    | Cabuk    | 10.10.1960 | 45  | Male   | 234567    |

@OgrenciListeleme
Scenario: Öğrenci Listele
	Given Menüden öğreci listele linkine tıklanır
	And   Listeleme ekranında yer alan <Firstname>, <Lastname>, <Birthdate>, <Age> ve <Gender> bilgileri girilir
	When  Ara butonuna tıklanır
	Then  Öğrenci listeleme işleminin başarılı olduğu görülür

Examples: 
| Firstname | Lastname | Birthdate  | Age | Gender |
| Murat     | Cabuk    | 10.10.1960 | 45  | Male   |

@OgrenciSilme
Scenario: Öğrenci Sil
	Given Menüden öğreci listele linkine tıklanır
	And   Listeleme ekranında yer alan <Firstname>, <Lastname>, <Birthdate>, <Age> ve <Gender> bilgileri girilir
	When  Ara butonuna tıklanır
	Then  Öğrenci listeleme işleminin başarılı olduğu görülür
	When  Listede yer alan sil linklerinden birine tıklanır
	Then  Öğrenci silme işleminin başarılı olduğu görülür

| Firstname | Lastname | Birthdate  | Age | Gender |
| Murat     | Cabuk    | 10.10.1960 | 45  | Male   |
