# AgentSmith

Kapılardan silah alıp düşmanları ve varilleri vurarak bitiş çizgisine ulaşılan bir mobil koşu oyunu.

![Düşmanı vurma](Images/Shoot%20Enemy.png)

## Neden?

Mobil koşu oyunlarında sık görülen iki mekaniği, parmağı sağa sola kaydırarak yön verme (swerve) ile içinden geçilen kapılardan güç alma mekaniğini bir arada denemek için yapıldı.

## Oynanış

- Karakter bitiş çizgisine doğru koşuyor, parmak sağa sola kaydırılarak yön veriliyor.
- İçinden geçilen kapılar silah veriyor.
- Silahla düşmanlar ve engeller vuruluyor. Vurulan variller patlıyor.
- Ölen her düşman bir mermi düşürüyor. Mermi kapılardan, yerden ve ölen düşmanlardan toplanabiliyor.

## Ekranlar

| Başlangıç | Çatışma |
|---|---|
| ![Başlangıç](Images/Game%20Start.png) | ![Çatışma](Images/Battle.png) |
| **Düşmanın ölmesi** | **Varili vurma** |
| ![Düşmanın ölmesi](Images/Enemy%20Death.png) | ![Varili vurma](Images/Shoot%20Barrel.png) |
| **Varil patlaması** | **Bitiş çizgisi** |
| ![Varil patlaması](Images/Barrel%20Explosion.png) | ![Bitiş çizgisi](Images/Finish%20Line.png) |
| **Kazanma** | **Kaybetme** |
| ![Kazanma](Images/Win.png) | ![Kaybetme](Images/Fail%20Soldier.png) |

## Teknik

| | |
|---|---|
| **Motor** | Unity |
| **Kullanılanlar** | Swerve kontrolü, kapı mekaniği |
| **Bu repoda** | Yalnızca oyunun scriptleri (`Codes`) ve ekran görüntüleri (`Images`); Unity projesinin tamamı yok |
| **GitHub'a yükleme** | Mart 2023 |
