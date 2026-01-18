Spring Boot + jOOQ Tutorial 

Razvoj baze podataka i rad sa upitima pomoću Spring Boot i jOOQ 

1. Uvod – problem koji se rešava 

Rad sa relacionim bazama podataka predstavlja jedan od ključnih aspekata razvoja serverskih aplikacija. Tradicionalni pristupi često podrazumevaju ručno pisanje SQL upita u vidu stringova unutar aplikacionog koda. Iako je ovaj pristup fleksibilan, on nosi niz problema: greške u nazivima tabela ili kolona otkrivaju se tek u runtime-u, refaktorisanje šeme baze zahteva ručno pronalaženje i izmenu SQL stringova u celom projektu, a podrška razvojnih alata (autocomplete, statička analiza) je veoma ograničena. Dodatni problem predstavlja činjenica da se SQL upiti često konstruišu konkatenacijom stringova, što povećava rizik od sintaksnih grešaka i smanjuje čitljivost koda. 

Sa druge strane, ORM rešenja poput JPA/Hibernate-a nude visok nivo apstrakcije i pojednostavljuju osnovne CRUD operacije, ali često postaju kompleksna i neefikasna kada je potrebno implementirati složenije SQL upite, kao što su višestruki JOIN-ovi, agregacije ili specifični filteri. U takvim slučajevima, generisani SQL može biti nepredvidiv i gubi se kontrola nad upitima koji se izvršavaju nad bazom podataka. 

Ovaj projekat ima za cilj da prikaže kako se korišćenjem Spring Boot framework-a u kombinaciji sa jOOQ bibliotekom može postići balans između kontrole nad SQL-om i sigurnosti koju pruža statički tipiziran programski jezik. jOOQ omogućava definisanje SQL upita kroz type-safe Java API, pri čemu se struktura baze koristi za automatsko generisanje Java klasa. Na ovaj način, greške vezane za promene šeme baze otkrivaju se već u fazi kompajliranja, a upiti postaju čitljiviji, pouzdaniji i lakši za održavanje. Projekat demonstrira ovaj pristup kroz praktične primere rada sa PostgreSQL bazom podataka, bez potrebe za ručnim pisanjem SQL stringova u aplikaciji. 

2. Spring Boot – kratak pregled 

Spring Boot je okvir zasnovan na Spring ekosistemu, namenjen brzom razvoju Java aplikacija. 

Ključne karakteristike Spring Boot-a 

automatska konfiguracija (auto-configuration), 

ugrađen web server (Tomcat/Jetty), 

konvencija ispred konfiguracije, 

laka integracija sa bazama podataka i eksternim bibliotekama. 

Spring Boot omogućava da se fokus prebaci sa infrastrukture na poslovnu logiku, što ga čini pogodnim za razvoj REST API aplikacija. 

3. jOOQ – šta je i koji problem rešava 

jOOQ (Java Object Oriented Querying) je Java biblioteka koja omogućava pisanje SQL upita kroz type-safe Java API, uz zadržavanje potpune kontrole nad SQL sintaksom i izvršavanjem. Za razliku od klasičnih ORM rešenja, jOOQ ne pokušava da sakrije SQL, već ga formalizuje i integriše u statički tipiziran programski jezik. 

Tok izvršavanja jednog SQL upita u aplikaciji koja koristi jOOQ može se opisati sledećim koracima: 

Poziv metode u servisnom sloju aplikacije 
Aplikacija u servisnoj klasi koristi DSLContext, centralni jOOQ objekat koji predstavlja ulaznu tačku za kreiranje SQL upita. 

Kreiranje SQL izraza putem jOOQ DSL-a 
Umesto ručnog pisanja SQL stringa, upit se gradi korišćenjem jOOQ API-ja, npr. select(), from(), where(), join(). 

Prevođenje DSL izraza u SQL 
jOOQ interno prevodi Java DSL izraz u SQL dijalekat koji odgovara konkretnoj bazi podataka (u ovom slučaju PostgreSQL). 

Izvršavanje SQL upita putem JDBC protokola 
Generisani SQL se izvršava preko standardnog JDBC protokola koristeći postojeću konekciju ka bazi podataka. 

Obrada rezultata 
Rezultat upita se mapira u jOOQ Record objekte ili direktno u DTO klase, u zavisnosti od načina korišćenja. 

DSLContext predstavlja glavnu ulaznu tačku za rad sa jOOQ bibliotekom u okviru Java aplikacije. On je odgovoran za kreiranje, konfiguraciju i izvršavanje svih SQL upita koji se definišu pomoću jOOQ DSL-a. U Spring Boot aplikaciji, DSLContext se automatski konfiguriše i registruje kao Spring bean, na osnovu podataka o konekciji ka bazi i SQL dijalekta. Za razliku od klasičnih ORM pristupa gde se nad entitetima izvršavaju apstraktne operacije, jOOQ koristi DSLContext kao objekat koji eksplicitno predstavlja vezu između aplikacionog koda i baze podataka. 

DSLContext u arhitekturi aplikacije ima sledeće ključne uloge: 

Factory za SQL upite - Sve jOOQ DSL operacije započinju pozivom metode nad DSLContext objektom, kao što su select(), insertInto(), update() i deleteFrom(). On služi kao fabrika koja kreira objekte koji predstavljaju SQL upite. 

Centralna tačka konfiguracije - DSLContext sadrži konfiguraciju: 

JDBC konekcije (DataSource), 

SQL dijalekta (npr. PostgreSQL), 

transakcionog konteksta, 

podešavanja mapiranja i izvršavanja upita. 

Veza između generisanih jOOQ klasa i baze - Generisane klase (tabele, polja, ključevi) same po sebi ne izvršavaju SQL., DSLContext je komponenta koja te klase “oživljava” i omogućava njihovu upotrebu u realnim SQL operacijama. 

Primer: 

dsl.select(AUTHOR.ID, AUTHOR.FIRST_NAME, AUTHOR.LAST_NAME) 
   .from(AUTHOR) 
   .where(AUTHOR.LAST_NAME.eq("Andric")) 
   .fetch(); 

 

Odnos DSLContext-a i generisanih jOOQ klasa 

Generisane klase su pasivne i čuvaju podatke o tabelama, kljuečevima i indeksima, dok DSLContext predstavlja aktivnu komponentu i koristi te klase da bi proverio ispravnost upita i generisao i izvršio SQL upit nad bazom. Bez DSLContext objekta, generisane jOOQ klase ne mogu da izvrše nijedan SQL upit. 

Još jedna bitna stvar je da je DSLContext u potpunosti integrisan sa Spring transakcionim mehanizmom. 

Prednosti centralizovanog DslContext sistema je jedinstvena konfiguracija za sve SQL upite, kontrolisano izvršavanje SQL-a, kao i testabilnost (Testcontainers). 

Generisanje jOOQ koda (Code Generation) 

Jedna od ključnih karakteristika jOOQ-a je automatsko generisanje Java koda na osnovu šeme baze podataka. Kod se generiše tokom build procesa (npr. Maven generate-sources faza), a generisanje se ponavlja svaki put kada se promeni struktura baze. jOOQ Code Generator čita metapodatke baze (tabele, kolone, ključeve, relacije), i koristi JDBC konekciju ka bazi. 

Struktura generisanih jOOQ klasa: 

 

Za svaku tabelu u bazi generiše se Tables klasa sa referencama na kolone, informacijama o primarnim i stranim ključevima,metadata o tabeli. Takođe, generiše se i odgovarajući Record, koji predstavlja jedan red iz baze i omogućava čitanje i izmenu vrednosti kolona, direktno insert/update operacije. Svaka kolona u tabeli predstavlja se kao Field<T> objekat, što omogućava type-safe poređenja (eq, like, between) i sprečava greške u nazivima kolona. Takođe, za sve indekse kreiraće se objekat u klasi Indexes, dok će klasa Keys sadržati sve primarne, strane i unique ključeve. 

Po želji, jOOQ može generisati i DAO klase koje omogućavaju jednostavne CRUD operacije. U ovom projektu fokus je na korišćenju DSL API-ja, kako bi se zadržala puna kontrola nad SQL upitima. 

jOOQ upiti 

jOOQ omogućava praktično kompletan SQL standard kroz Java API, uključujući: 

select, insert, update, delete 

join (inner, left, right) 

podupite (subqueries) 

agregacione funkcije (count, sum, avg) 

sortiranje i paginaciju 

transakcije 

returning klauzule (podržane u PostgreSQL) 

Primer jOOQ upita: 

dsl.select(AUTHOR.FIRST_NAME, AUTHOR.LAST_NAME) 
   .from(AUTHOR) 
   .join(BOOK).on(BOOK.AUTHOR_ID.eq(AUTHOR.ID)) 
   .where(BOOK.PUBLISHED_YEAR.gt(2000)) 
   .orderBy(AUTHOR.LAST_NAME.asc()) 
   .fetch(); 
 

4. Integracija Spring Boot i jOOQ 

Integracija se zasniva na sledećem procesu: 

Definisanje šeme baze (PostgreSQL) pomoću SQL skripte 

jOOQ Code Generation – generisanje Java klasa na osnovu postojeće baze 

Spring Boot konfiguracija koja obezbeđuje DSLContext bean 

Korišćenje DSLContext za izvršavanje upita u servisnom sloju aplikacije 

Ova kombinacija je posebno pogodna kada aplikacija često zahteva pozive kompleksnih SQL upita, postoji potreba za većom kontrolom na SQL-om i važna je čitljivost koda. 

5. Prednosti korišćenja Spring Boot + jOOQ 

precizna kontrola nad SQL upitima, 

manja verovatnoća grešaka u radu sa bazom, 

odlična podrška IDE-a (autocomplete, refactoring), 

lako održavanje koda kod promena šeme baze, 

pogodno za aplikacije sa kompleksnim upitima i izveštajima. 

6. Mane i ograničenja 

veća količina generisanog koda, 

dodatni korak code-generation procesa, 

nije pogodan za aplikacije koje zahtevaju potpunu apstrakciju baze, 

zahteva dobro poznavanje SQL-a. 

7. Konkurentna rešenja 

JPA / Hibernate 

Omogućava jednostavne CRUD operacije, ali pisanje složenijih upita postaje kompleksno. Visoka apstrakcija baze može pojednostaviti pisanje koda, ali time dobijamo gubimo sliku o tome šta se dešava na nivou repozitorijuma i generisanje SQL-a postaje nepredvidivo. 

MyBatis 

Omogućava lak rad sa SQL-om i custom podacima, može da pamti procedure i omogućava napredno mapiranje. Ali koristi ručno pisanje SQL stringova i zbog toga mu je slabija provera validnosti tipova podataka. 

QueryDSL 

Upiti su type-safe, ali su podžani upiti skromni i dosta udaljeni od pravog SQL-a. 

8. Opis projekta 

U okviru ovog projekta implementirana je jednostavna Library aplikacija koja omogućava: 

rad sa autorima i knjigama, 

izvršavanje SQL upita korišćenjem jOOQ biblioteke, 

demonstraciju jOOQ API-ja u praksi, 

Korišćenje testConteiners-a 

Baza podataka je PostgreSQL i pokreće se pomoću Docker-a, pozivom komande: 
docker compose up –d 

Za kreiranje tabela i ostalog sadržaja baze koristila sam DBeaber preko koga sam se povezala sa Postgres bazom i taj skript se nalazi na ovom git repozitoriumu. 

Nakon kreiranja baze potrebno je kreirati projekat u Intelij-u koji koristi Javu i Maven i to je najlakše uraditi korišćenjem spring initilizr-a.  

Da bi projekat mogao da koristi jOOQ biblioteke i Postgres bazu potrebno je setovati dependency-e u pom.xml: 
<dependency> 
   <groupId>org.springframework.boot</groupId> 
   <artifactId>spring-boot-starter-jooq</artifactId> 
</dependency> 
 
<dependency> 
   <groupId>org.jooq</groupId> 
   <artifactId>jooq</artifactId> 
   <version>${jooq.version}</version> 
</dependency> 
 
<dependency> 
   <groupId>org.postgresql</groupId> 
   <artifactId>postgresql</artifactId> 
   <version>${postgres.version}</version> 
   <scope>runtime</scope> 
</dependency> 
 

<dependency> 
   <groupId>org.springframework.boot</groupId> 
   <artifactId>spring-boot-starter-jooq</artifactId> 
</dependency> 
 
<dependency> 
   <groupId>org.jooq</groupId> 
   <artifactId>jooq</artifactId> 
   <version>${jooq.version}</version> 
</dependency> 
 
<dependency> 
   <groupId>org.postgresql</groupId> 
   <artifactId>postgresql</artifactId> 
   <version>${postgres.version}</version> 
   <scope>runtime</scope> 
</dependency> 
 

Aplikacija se povezuje na bazu setovanjem parametara kao što su: 
spring.datasource.url=jdbc:postgresql://localhost:5432/demo 
spring.datasource.username=postgres 
spring.datasource.password=postgres 
spring.jooq.sql-dialect=POSTGRES 

Nakon povezivanja na bazu, potrebno je generisati jOOQ klase, kako bi rad sa podacima bio moguć. Dakle prvo se poziva naredba u terminalu: 

. /mvnw -DskipTests generate-sources 
Nakon izvršenja te komande, kreiraće se struktura jOOQ klasa u demo/target/generate-sources/jooq. Nakon toga je moguće direktno pozivati jOOQ api, korišćenjem dslContexta i generisanih klasa kao preslikanog modela baze podataka. 

U projekat sam dodala kontroler, koji će pozivati servis, i servis koji će izvršavati jOOQ pozive. Pokretanje aplikacije se vrši iz terminala naredbom: 

./mvnw spring-boot:run 

Ili jednostavnije, pritiskom na run dugme. Nakon podizanja aplikacije, moguće je lokalno pozvati endpoint definisan u kontroleru i testirati ispravnost koda. Primer poziva endpointa za pribavljanje svih autora: 
http://localhost:8080/authors 

[ 
 "Ivo Andric", 
 "Danilo Kis", 
 "Mesa Selimovic" 
] 

što odgovara i situaciji iz baze: 

select * from library.author; 

 

 
 

Testiranje je moguće vršiti i korištenjem tesnih kontejnera, koji mogu da mockupuju konekciju ka bazi. Za to je potrebno dodati depencenciy u pom.xml: 
<dependency> 
   <groupId>org.testcontainers</groupId> 
   <artifactId>testcontainers-bom</artifactId> 
   <version>${testcontainers.version}</version> 
   <type>pom</type> 
   <scope>import</scope> 
</dependency> 

<dependency> 
   <groupId>org.springframework.boot</groupId> 
   <artifactId>spring-boot-starter-test</artifactId> 
   <scope>test</scope> 
</dependency> 
 
<dependency> 
   <groupId>org.testcontainers</groupId> 
   <artifactId>junit-jupiter</artifactId> 
   <scope>test</scope> 
</dependency> 
 
<dependency> 
   <groupId>org.testcontainers</groupId> 
   <artifactId>postgresql</artifactId> 
   <scope>test</scope> 
</dependency> 

Takođe potrebno je mockup-ovati konekciju ka bazi, što sam u projektu izvrsila u schema.sql fajlu, koji se takođe nalazi u ovom repozitorijumu. 
