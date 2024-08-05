# Wykup_Pieniadza_Elektronicznego_z_Karty_Miejskiej
Projekt umożliwiający składanie zleceń wykupu Pieniądza Elektronicznego zgromadzonego na Karcie Miejskiej. 

Założenia:
- na stronie www klient będzie wpisywał zestaw danych potrzebnych do identyfikacji czy to jest rzeczywiście posiadacz karty
- po wpisaniu danych będą one porównywane z bazą danych i zależnie od wyniku porównania klient dostanie informację, że dane są błędne, że saldo jest "0" lub, że wniosek o wykup został już złożony
- jeśli dane będą prawidłowe i saldo będzie większe od "0", to klient będzie przenoszony do strony, gdzie będzie wpisywał dane do przelewu
- dane do przelewu będą zapisywane w bazie danych przelewów
- "pracownik operacyjny" będzie pobierał zlecenia z bazy danych i wprowadzał je do systemu rozliczeniowego Banku 
- dwie role użytkowników: "admin" z dostepem do całości aplikacji oraz "pracownik operacji" z dostępem do drugiej bazy danych, tej z przelewami

Must Have:
- baza danych (posiadaczy kart, kart, płatności): 3 SP
- modele danych: 3 SP
- repozytoria: 3 SP
- serwisy: 3 SP
- WebAPI: 5 SP
- React: 5 SP

Should Have:
- formularz do składania reklamacji: 3 SP
- połączenie bazy danych z przelewami z systmem rozliczeniowym Banku (żeby przelewy mogły się generować automatycznie): 3 SP

Could Have:
- stylowanie formularza na stronie www - w kolorach Banku: 5 SP
- baza danych z logami dla "admina": 3 SP

