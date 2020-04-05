Feature: CalculatorManagerTests
	Bir matemetik dahisi olarak
	Projemde matematiksel hatalar yapmamak için
	Bütün sistemi test etmek istiyorum


Background: Sisteme Giriş Senaryosu
	Given Loginmanager kullanılarak Login Fonksiyonuna <username>,<password> paramereleri verilerek çağrılır
		| username | password |
		| aaa      | 123      |
	Then  Login işleminin sonucunun başarılı olduğu true değeri ile anlaşılır


@RakamEklemeToplama
Scenario: Calculatora Rakam Ekleyerek Toplama Yapma Senaryosu
	Given Addnumber fonksiyonuna <number> parametresi int array olarak girilir çağrılır
	Then Sonucun true dondugu gorulur
	And   SumAllMemories fonksiyonu çağrılır
	Then  Sonucun verilen sayıların toplamı olduğu görülür
	And Tüm rakamlar silinir
	Then Rakamların silindiğin Memories kontol edilerek eminolunur

Examples: 
| numbers |
| 1,2,3,4 |


@RakamCikartma
Scenario: Calculatora rakam çıkartma senaryosu
	Given Addnumber fonksiyonuna <number> parametresi int array olarak girilir çağrılır
	Then Sonucun true dondugu gorulur
	And   RemoveNumber fonksiyonuna bir rakam paramertre olaraka girilerek çağrılır
	Then  Memories de silinen rakam kontrol edilerek siliniğinden eminolounur
	And Tüm rakamlar silinir
	Then Rakamların silindiğin Memories kontol edilerek eminolunur

Examples: 
| numbers |
| 1,2,3,4 |