<div style="text-align: center;">

## Univerzitet u Banjoj Luci
## Elektrotehnički fakultet





# Semafor za fudbalske utakmice







### Korisničko uputstvo

</div>

---

## Sadržaj

1. [Uvod](#uvod)
2. [Korišćenje aplikacije](#korisćenje-aplikacije)
    - [Pregled menija](#pregled-menija)
    - [Upravljanje tabelama](#upravljanje-tabelama)
    - [Opcije](#opcije)
    - [Praćenje utakmice](#praćenje-utakmice)
    - [Nalozi](#nalozi)
    - [Pregled statistike](#pregled-statistike)
4. [Tehnologije](#tehnologije)
5. [Kontakt](#kontakt)

---

## Uvod

Dobrodošli u korisničko uputstvo za aplikaciju **Semafor za fudbalske utakmice**. Ova aplikacija je razvijena kao dio projekta na Elektrotehničkom fakultetu Univerziteta u Banjoj Luci. Osnovna namjena aplikacije je omogućavanje prikaza značajnih događaja na fudbalskoj utakmici. Pored elemenata prikaza, postoji i aplikativni prikaz statistike i informacija o već odigranim utakmicama.

---

## Korišćenje aplikacije

### Pregled menija

![image](https://github.com/user-attachments/assets/e9941f4a-7bdf-484e-899f-43910d166946)

![image](https://github.com/user-attachments/assets/58515481-428e-484e-a902-8307ff8045bb)

Kao što je vidljivo na slikama, meni se sastoji od sljedećih polja:

- Igrači (Prikaz svih igrača i osnovne operacije nad njima)
- Klubovi (Prikaz svih klubova i osnovne operacije nad njima)
- Stadioni (Prikaz svih stadiona i osnovne operacije nad njima)
- Utakmice (Prikaz svih utakmica i osnovne operacije nad njima, kao i otvaranje izabrane utakmice)
- Šifarnici
  - Tip kartona (Prikaz svih tipova kartona i dodavanje)
  - Pozicija (Prikaz svih fudbalskih pozicija i osnovne operacije nad njima)
- Korisnici (Prikaz svih korisnika i osnovne operacije nad njima (bez mogućnosti dodavanja))
- Statistika (Pregled statistike igrača i klubova)
- Opcije (Osnovne vizuelne i jezičke opcije aplikacije)


### Upravljanje tabelama

Jedan od osnovnih načina upotrebe aplikacije je upravljanje tabelama. Korisnik ima mogućnost pregleda, dodavanja, izmjene i brisanja zapisa u tabelama. Sam prozor je napravljen da bude jednostavan za sve korisnike. Polja koja su obavezna prilikom unosa su naznačena.

Tabele čijim je sadržajem u potpunosti moguće upravljati:
- Igrač
- Klub
- Stadion
- Pozicija
- Utakmica

Tabele čijim je sadržajem moguće djelimično upravljati:
- Tip kartona
- Korisnik

Stadioni:
![image](https://github.com/user-attachments/assets/c84d4d99-5963-423d-9725-7bb0468038b7)

Klubovi:
![image](https://github.com/user-attachments/assets/61812ab2-5a1e-4139-9592-41fac3cffcf5)


1. Otvorite aplikaciju i kliknite na opciju iz menija.
2. Za dodavanje novog zapisa, neophodno je popuniti lijevu formu (sva obavezna polja su označena crvenom bojom) i nakon toga kliknuti na dugme **Dodaj**.
3. Za izmjenu nekog zapisa, neophodno je isti izabrati u tabeli, napraviti izmjene i kliknuti na dugme **Izmjeni**.
4. Za brisanje nekog zapisa, neophodno je isti izabrati u tabeli i nakon toga kliknuti na dugme **Obriši**

### Opcije

Aplikacija nudi različite opcije podešavanja korisničkog prikaza kako bi se postigao maksimalan komfor korisnika prilikom korišćenja aplikacije. Opcije koje su podržane u aplikaciji:
- Promjena teme (Dvije tamne teme sa različitim primarnim bojama i jedna svijetla)
- Promjena veličine fonta za lica sa oštećenjem vida (sitni, srednji i krupni font)
- Promjena fonta (Aplikacija podržava dva stila font)
- Srpski i engleski jezik

Sve promjene se čuvaju i učitavaju prilikom sljedećeg pokretanja aplikacije. Izabrani korisnički prikaz je sačuvan na nivou aplikacije, a ne na nivou naloga

![image](https://github.com/user-attachments/assets/ecfd504d-4ebe-461a-920c-d479bd277099)


### Praćenje utakmice

Glavna funkcionalnost aplikacije je praćenje utakmice. Da bi se otvorio prozor za praćenje utakmice, neophodno je u meniju izabrati opciju **Utakmice**, zatim selektovati u tabeli izabranu utakmicu i kliknuti na komandu **Otvori**.

![image](https://github.com/user-attachments/assets/d0e5f9fc-c901-407f-a494-03173f25e2ea)

Nakon toga otvori se novi prozor sa utakmicom

![image](https://github.com/user-attachments/assets/41449341-f65c-4983-9197-80b32effd024)

Kao što vidimo na slici, prozor se sastoji od: grbova domaćeg i gostujućeg tima, naziva domaćeg i gostujućeg tima, rezultata, sata (kada se utakmica započne, minute se automatski mjere), tabela koje reprezentuju startnu postavu i igrače na klupi oba tima, središnjeg dijela gdje se ispisuju golovi i kartoni i komandnog dijela gdje se prave unosi događaja na meču. Prije početka utakmice, neophodno je unijeti sve igrače koji će biti dio startne postave. Unos se vrši klikom na dugme **Ubaci** koje se nalazi pored informacija svakog igrača na klupi. Ukoliko se pogrešan igrač označi kao starter, moguće ga je izbaciti klikom na dugme **Izbaci**. Nakon što se korisnik uvjerio da je sve učesnike unio u sistem, pritišće se dugme sa **Play** ikonicom koje započinje utakmicu i mjerenje vremena. Kada je utakmica započeta, dostupne postanu opcije za unos događaja. Za svaku opciju je neophodno selektovati jednog od igrača u igri (Postupak se ostvaruje klikom na igrača u jednoj od dvije tabele). Nakon što je igrač selektovan, trebamo se uvjeriti da je ispisano njegovo prezime lijevo od komandne table i  tada možemo započeti jednu od dostupnih akcija:

1. Gol - Po difoltu, gol se upisuje automatski timu selektovanog igrača i rezultat se inkrementuje a poruka se ispisuje na sredini prozora. Ukoliko je u pitanju autogol, potrebno je čekirati opciju Autogol/Owngoal da bi se rezultat pravilno inkrementovao.
2. Izmjena - Pored toga što je jedan igrač selektovan, potrebno je i selektovati igrača koji ulazi u igru. Igrač koji izlazi više nije dostupan na utakmici, dok se igrač koji ulazi ubacuje u postavu.
3. Žuti karton - Selektovanom igraču se dodjeljuje žuti karton i događaj ispisuje na ekranu. Ukoliko igrač dobije drugi žuti karton, automatski dobija i crveni karton i izbacuje se sa utakmice.
4. Crveni karton - Selektovani igrač se izbacuje sa utakmice i događaj ispisuje na ekranu.

Vrijeme se automatski unosi, te je na taj način posao operatera minimalizovan. Tajmer će stati u 45. minutu, te se svi događaji u sidujskoj nadoknadi bilježe da su se desili u 45. minuti što je prihvatljivo i česta praksa kod zapisnika fudbalskih utakmica. Nakon što počne drugo poluvrijeme, potrebno je kliknuti na komandu **2. pol** nakon čega kreće računanje vremena od 45. do 90. minuta. Sam proces unosa događaja je identičan kao za prvo poluvrijeme.

Ukoliko dođe do greške prilikom unosa gola ili kartona, istu je moguće ispraviti klikom na **X** pored pogrešno unesenog događaja. Promjena rezultata će se sama zabilježiti.

![image](https://github.com/user-attachments/assets/76538abb-4e0b-423c-9d50-2cac7a68b031)

### Nalozi

Aplikacija prepoznaje dva tipa naloga: administrator i operater. Operater ima pristup opcijama, statistici i praćenju utakmice, dok administrator pored toga ima puno pravo za uređivanje svih tabela. Administrator takođe ima pristup svim korisničkim nalozima, nad kojima može izvršiti promjenu uloge (može nekom nalogu oduzeti ili dodati administratorska prava) i samo brisanje naloga.

![image](https://github.com/user-attachments/assets/ffa1b01c-ec85-4917-992c-a39132e877a3)


### Pregled statistike

Statistika je jedan od osnovnih koncepata u sportu. Njena uloga je velika. Zbog realne mogućnosti upotrebe aplikacije na turnirima, velika je prednost automatizacija izrade statistike. Bilježe se podaci o pojedinačnim igračima (golovi, kartoni), kao i podaci o klubovima (broj pobjeda, poraza i neriješenih). Pored tabelarnog prikaza, prisutan je i grafički prikaz odnosa žutih i crvenih kartona, kao i broja igrača koji su postigli golove i onih koje se nisu upisivali na listu strijelaca.

![image](https://github.com/user-attachments/assets/b5369a18-afac-4d41-a55e-574cb4fde5d4)


---

## Tehnologije

Za izradu ove aplikacije, korišćene su sljedeće tehnologije

- WPF (Windows Presentation Foundation) - Za kreiranje korisničkog interfejsa aplikacije.
- Material Design in XAML Toolkit - Za primenu Material Design stilova i ikonica.
- C# - Kao programski jezik za implementaciju logike aplikacije.
- XAML (Extensible Application Markup Language) - Za definisanje korisničkog interfejsa.
- MySQL - Baza podataka

---


## Kontakt

Za dodatne informacije ili tehničku podršku, kontaktirajte me na:

- **Email:** mica.ignjatic01@gmail.com

---


