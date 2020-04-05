Feature: IdentityManagerTests
	Bir güvenlik uzmanı olarak
	Güvenlik problemi yaşamamak için
	Güvenlikle ilgili senaryoları test etmek istiyorum

@SistemeGirisCikisTesti
Scenario: Kullanıcının Sisteme Giriş ve Çıkış Senaryosu
	Given Login fonsiyonuna "username" ve "password" girilerek çağrılır
	Then Login işlemi sonucunun true olduğu görülür 
	And Logout fonksiyonu çağrılır
	Then Logout işleriminin sonucunun true olduğu görülür

	Examples: 
| username | password |
| aaa      | 123      |
