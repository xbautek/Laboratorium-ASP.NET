Projekt dotyczy Photo  wraz z polami - data i godzina, opis, aparat, autor, rozdzielczość, format.

Wykorzystane technologie:
1.	ASP.NET 6.0
2.	Entity Framework Core 6.0
3.	Microsoft.AspNetCore.Identity.UI 6.0.25
4.	Microsoft.EntityFrameworkCore.SqlServer 6.0.23 
5.	Microsoft.EntityFrameworkCore.Tools 6.0.23
6.	Microsoft.VisualStudio.Web.CodeGeneration.Design 6.0.16
7.	Microsoft.EntityFrameworkCore.Design 6.0.23
8.	Baza danych w Sqllite

Dane przykładowych użytkowników:
1.Admin – rola admin
Email: admin@wsei.edu.pl
Hasło: 1234Ab!

2.User – rola user
Email: user@wsei.edu.pl
Hasło: 1928@AB

3.Guest – rola guest
Email: guest@wsei.edu.pl
Hasło: Abc123#

4. Adamk01 – rola user
Email: adamk01@gmail.com
Hasło: Adam123@

Proces uruchomienia:
Po sklonowaniu projektu należy najechać na „Laboratorium 3 – Homework” w sekcji solution explorer, nacisnąć prawy przycisk myszy i wybrać opcje „set as startup project”. Potem należy kliknąć prawy przyciskiem na „ProjectData” i wybrać „Open in terminal”. Następnie wpisać poniższe komendy w celu wykonania migracji.

Dotnet ef migrations add Init
Dotnet ef database update

W przypadku problemów usunąć migrację za pomocą komendy:
dotnet ef migrations remove

Pomocne również może okazać się usunięcie bazy w %appdata% - >local

Własne funkcje aplikacji:
- Możliwość wyszukiwania zdjęć danego autora. W sekcji głównej Zdjęcia dodane pole typu select z przyciskiem do filtrowania pod nim.
- Możliwość przeszukiwania historii usuniętych zdjęć w czasie trwania sesji, wraz z możliwością ich przywrócenia
- Możliwość dodawania komentarzy do zdjęcia. Utworzona nowa tabela w bazie z powiązaniem z tabelą photos. Utworzono nowy kontroler CommentController z serwisem.
- Utworzony także kontroler WebApi do udostępniania zdjęć danego autora. Przyciski do przekierowania do api znajdują się pod polem typu select(tym samym, które służy do filtrowania) w sekcji głównej Zdjęcia.

Link do repozytorium
https://github.com/xbautek/Laboratorium-ASP.NET


